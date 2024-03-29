﻿using PdfiumViewer;
using SharpGED_client.Forms;
using SharpGED_lib;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SharpGED_lib.GedFile;

namespace SharpGED_client
{
    public partial class formMain : Form
    {

        private string lastClickedHash = "";
        private string lastClickedNode = "";
        private PdfDocument currentPdfDocument;
        private string currentDocumentUri;

        public formMain()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Ajoute le nom du serveur
            Text = Text + "@" + Program.serverHostname;

            // Initialise l'affichage
            if (Program.isDatabaseInitialized)
            {
                RefreshFilesList();
            }
            else
            {
                if (MessageBox.Show("La base de données du serveur n'est pas encore initialisée. Souhaitez-vous le faire maintenant ?", "Base de données manquante", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    formInput inputDialog = new formInput();
                    inputDialog.title = "Entrez le nom souhaité pour la base";
                    inputDialog.value = "Base par défaut";

                    if (inputDialog.ShowDialog() == DialogResult.OK)
                    {
                        InitializeDatabase(inputDialog.value);
                    }
                }
            }
            listViewFiles_SelectedIndexChanged(null, null);

            treeViewCategories.Font = new Font(treeViewCategories.Font, FontStyle.Bold); // Contournement d'un bug de Windows
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Déconnecte du serveur
            if (Program.IsConnectionUp())
            {
                Program.ServerDisconnect();
            }

            // Purge les fichiers temporaires
            if (currentPdfDocument != null)
            {
                currentPdfDocument.Dispose();
            }
            Program.CleanTempFiles();

            // Réaffiche la fenêtre de connexion
            Program.loginForm.Show();
        }

        private void RefreshFilesList(string filter = "")
        {
            if (!Program.isDatabaseInitialized)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;

            EmptyViewers();
            listViewFiles.Items.Clear();
            treeViewCategories.Nodes.Clear();

            foreach (GedFolder currentGedFolder in Program.ServerListFolders(filter))
            {
                treeViewCategories.Nodes.Add(BuildNode(currentGedFolder));
            }
            treeViewCategories.Sort();
            treeViewCategories.ExpandAll();

            // Re-sélectionne le dernier noeud actif
            if (treeViewCategories.Nodes.Count > 0)
            {
                if (!lastClickedNode.Equals(""))
                {
                    TreeNode[] searchResult = treeViewCategories.Nodes.Find(lastClickedNode, true);
                    if (searchResult.Length > 0)
                    {
                        treeViewCategories.SelectedNode = treeViewCategories.Nodes.Find(lastClickedNode, true)[0];
                    }
                    else
                    {
                        treeViewCategories.SelectedNode = treeViewCategories.Nodes[0];
                    }
                }
                else
                {
                    treeViewCategories.SelectedNode = treeViewCategories.Nodes[0];
                }

            }

            Cursor = Cursors.Default;
        }

        private TreeNode BuildNode(GedFolder folder)
        {
            TreeNode node = new TreeNode(folder.title);
            node.Tag = folder;
            node.Name = folder.id.ToString();

            foreach (GedFolder subFolder in folder.folders)
            {
                if (subFolder.folders.Count == 0 && subFolder.files.Count == 0 && toolButtonFilter.Checked) continue;
                TreeNode subNode = BuildNode(subFolder);
                subNode.Tag = subFolder;
                node.Nodes.Add(subNode);
            }

            // Image spéciale pour le(s) noeud(s) racine
            if (folder.idParent == null)
            {
                node.NodeFont = new Font(treeViewCategories.Font, FontStyle.Bold);
                node.SelectedImageIndex = 0;
                node.ImageIndex = 0;
                node.EnsureVisible();
            }
            else
            {
                node.NodeFont = new Font(treeViewCategories.Font, FontStyle.Regular);
                if (folder.files.Count == 0)
                {
                    node.SelectedImageIndex = 2;
                    node.ImageIndex = 2;
                }
                else
                {
                    node.SelectedImageIndex = 1;
                    node.ImageIndex = 1;
                }

            }

            return node;
        }

        private void EmptyViewers()
        {
            groupBoxProperties.Visible = false;
            pdfViewer.Visible = false;
            imageViewer.Visible = false;
            officeViewer.Visible = false;

            labelPdfName.Text = "";
            labelFileType.Text = "";
            labelNbPages.Text = "";
            labelOriginalName.Text = "";

            if (currentPdfDocument != null)
            {
                currentPdfDocument.Dispose();
            }
            pdfViewer.Load(PdfDocument.Load("BLANK.pdf"));
        }

        private void FillViewer(GedFile selectedFile)
        {
            if (selectedFile.hash.Equals(lastClickedHash))
            {
                return;
            }
            else
            {
                lastClickedHash = selectedFile.hash;
            }

            Cursor = Cursors.WaitCursor;

            RemoteGedFile file = Program.ServerReciveFile(selectedFile);

            // Ecris le fichier dans un fichier temporaire sur le disque
            string localFilename;
            if (file.type == GedFileType.PDF)
            {
                localFilename = Program.NewTempFile();
            }
            else
            {
                localFilename = Program.NewTempFile(file.originalname.Substring(file.originalname.LastIndexOf(".") + 1));
            }
            FileStream outStream = new FileStream(localFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 1024, FileOptions.None);
            outStream.Write(file.bytes, 0, file.size);
            outStream.Close();

            // Masque tous les viewers
            EmptyViewers();

            // Affiche le document dans le viewer correspondant à son type, avec ses méta-données
            switch (file.type)
            {
                case GedFileType.PDF:
                    currentPdfDocument = PdfDocument.Load(localFilename);
                    pdfViewer.Load(currentPdfDocument);
                    pdfViewer.Visible = true;
                    break;

                case GedFileType.Image:
                    imageViewer.Image = Image.FromFile(localFilename);
                    imageViewer.Visible = true;
                    break;

                case GedFileType.Office:
                    officeViewer.URI = localFilename;
                    officeViewer.Visible = true;
                    break;
            }
            labelPdfName.Text = file.title;
            labelOriginalName.Text = file.originalname;
            labelNbPages.Text = file.pages.ToString();
            labelFileType.Text = file.TypeName();
            groupBoxProperties.Visible = true;

            // Mémorise le fichier temporaire et son URI
            currentDocumentUri = localFilename;

            Cursor = Cursors.Default;
        }

        private void InitializeDatabase(string databaseName)
        {
            Cursor = Cursors.WaitCursor;
            EmptyViewers();
            Program.ServerInitialize(databaseName);
            RefreshFilesList();
            treeViewCategories.Nodes[0].Text = databaseName;
            Cursor = Cursors.Default;
        }

        private void toolButtonFilter_Click(object sender, EventArgs e)
        {
            if (toolButtonFilter.Checked)
            {
                formInput inputDialog = new formInput();
                inputDialog.title = "Filtre de nom de fichier";

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    RefreshFilesList(inputDialog.value);
                    toolButtonFilter.Image = imageListToolbar.Images[1];
                }
                else
                {
                    RefreshFilesList();
                    toolButtonFilter.Checked = false;
                    toolButtonFilter.Image = imageListToolbar.Images[0];
                }
            }
            else
            {
                RefreshFilesList();
                toolButtonFilter.Image = imageListToolbar.Images[0];
            }

        }

        private void toolButtonFileNew_Click(object sender, EventArgs e)
        {
            if (treeViewCategories.SelectedNode == null)
            {
                MessageBox.Show("Merci de sélectionner le dossier où le fichier sera déposé.", "Précision requise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            formAddFile addFileDialog = new formAddFile();
            addFileDialog.folder = (GedFolder)treeViewCategories.SelectedNode.Tag;

            if (addFileDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshFilesList();
            }
        }

        private void toolButtonFileDelete_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer les documents sélectionnés ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EmptyViewers();
                    foreach (ListViewItem currentGedFile in listViewFiles.SelectedItems)
                    {
                        Program.ServerDeleteFile((GedFile)currentGedFile.Tag);
                    }
                    RefreshFilesList();
                }
            }
        }

        private void toolButtonFileRename_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                formInput inputDialog = new formInput();
                inputDialog.title = "Entrez le nom souhaité pour le document";
                inputDialog.value = ((GedFile)listViewFiles.SelectedItems[0].Tag).title;

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    Program.ServerRenameFile(((GedFile)listViewFiles.SelectedItems[0].Tag), inputDialog.value);
                    RefreshFilesList();
                }
            }
        }

        private void toolButtonFileEdit_Click(object sender, EventArgs e)
        {
            if (Program.isDatabaseInitialized)
            {
                string originalTitle = labelPdfName.Text;
                string originalName = labelOriginalName.Text;

                formEditPdf edit = new formEditPdf();
                edit.documentUri = currentDocumentUri;

                if (edit.ShowDialog() == DialogResult.OK)
                {
                    currentDocumentUri = edit.documentUri;

                    // Lit le fichier PDF et place son contenu dans un tableau
                    byte[] fileBytes;
                    int size;
                    using (FileStream inStream = File.OpenRead(currentDocumentUri))
                    {
                        size = (int)inStream.Length;
                        fileBytes = new byte[size];
                        inStream.Read(fileBytes, 0, size);
                    }

                    // Crée un GedFile et l'envoie au serveur
                    RemoteGedFile file = new RemoteGedFile();
                    file.folderId = ((GedFolder)treeViewCategories.SelectedNode.Tag).id;
                    file.size = size;
                    file.title = originalTitle + " (édité)";
                    file.originalname = originalName;
                    file.bytes = fileBytes;
                    Program.ServerSendFile(file);

                    RefreshFilesList();
                }
            }
        }

        private void toolButtonFolderAdd_Click(object sender, EventArgs e)
        {
            if (Program.isDatabaseInitialized)
            {
                GedFolder folder = new GedFolder();

                formInput inputDialog = new formInput();
                inputDialog.title = "Entrez le nom souhaité pour le dossier";
                inputDialog.value = "Nouveau dossier";

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;

                    folder.title = inputDialog.value;

                    if (treeViewCategories.SelectedNode != null)
                    {
                        folder.idParent = ((GedFolder)treeViewCategories.SelectedNode.Tag).id;
                    }

                    Program.ServerCreateFolder(folder);

                    Cursor = Cursors.Default;
                    RefreshFilesList();
                }
            }
        }

        private void toolButtonFolderDelete_Click(object sender, EventArgs e)
        {
            if (treeViewCategories.SelectedNode != null)
            {
                // Interdis de supprimer un noeud racine
                if (((GedFolder)treeViewCategories.SelectedNode.Tag).idParent != null)
                {
                    if (MessageBox.Show("Etes-vous sûr(e) de vouloir supprimer ce dossier ? (les sous-dossiers et fichiers inclus seront déplacés à la racine)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor = Cursors.WaitCursor;
                        Program.ServerDeleteFolder((GedFolder)treeViewCategories.SelectedNode.Tag);
                        Cursor = Cursors.Default;
                        lastClickedNode = "";
                        RefreshFilesList();
                    }
                }
            }
        }

        private void toolButtonFolderRename_Click(object sender, EventArgs e)
        {
            if (treeViewCategories.SelectedNode != null)
            {
                formInput inputDialog = new formInput();
                inputDialog.title = "Entrez le nom souhaité pour le dossier";
                inputDialog.value = ((GedFolder)treeViewCategories.SelectedNode.Tag).title;

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    Program.ServerRenameFolder((GedFolder)treeViewCategories.SelectedNode.Tag, inputDialog.value);
                    Cursor = Cursors.Default;
                    RefreshFilesList();
                }
            }
        }

        private void toolButtonPrint_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {

                printPdf = pdfViewer.Document.CreatePrintDocument();
                printDialog.Document = printPdf;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printPdf.PrinterSettings = printDialog.PrinterSettings;
                    printPdf.Print();
                }
                else
                {
                    printPdf = null;
                }

            }
        }

        private void toolButtonFileExtract_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems != null)
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string currentFilename;
                    foreach (ListViewItem currentGedFile in listViewFiles.SelectedItems)
                    {
                        FillViewer((GedFile)currentGedFile.Tag);
                        currentFilename = ((GedFile)currentGedFile.Tag).title + "_" + DateTime.Now.ToFileTime() + currentDocumentUri.Substring(currentDocumentUri.LastIndexOf("."));
                        File.Copy(currentDocumentUri, folderBrowserDialog.SelectedPath + "\\" + currentFilename);
                    }
                    EmptyViewers();
                    MessageBox.Show("Les documents sélectionnés ont été extraits dans le dossier " + folderBrowserDialog.SelectedPath, "Terminé avec succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshFilesList();
            lastClickedNode = "";
        }

        private void toolButtonInitDatabase_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Etes-vous sûr(e) de vouloir (ré-)initialiser la base de données ?\nSi cette dernière existe déjà, l'ensemble des documents sera supprimé du serveur.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                formInput inputDialog = new formInput();
                inputDialog.title = "Entrez le nom souhaité pour la base";
                inputDialog.value = "Base par défaut";

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    InitializeDatabase(inputDialog.value);
                }
            }
        }

        private void toolButtonStopServer_Click(object sender, EventArgs e)
        {
            Program.ServerHalt();
            Close();
        }

        private void toolButtonDisconnect_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeViewCategories_Click(object sender, EventArgs e)
        {
            // Nécessaire pour rafraichir _AfterSelect si on reclique sur le même élément
            treeViewCategories.SelectedNode = null;
        }

        private void treeViewCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            lastClickedHash = "";
            listViewFiles.SelectedItems.Clear();
            listViewFiles.Items.Clear();
            ListViewItem currentItem;
            foreach (GedFile currentGedFile in ((GedFolder)treeViewCategories.SelectedNode.Tag).files)
            {
                currentItem = new ListViewItem();
                currentItem.Text = currentGedFile.title;
                currentItem.Tag = currentGedFile;
                currentItem.ImageIndex = (int)currentGedFile.type;
                listViewFiles.Items.Add(currentItem);
            }
            lastClickedNode = treeViewCategories.SelectedNode.Name;

            Cursor = Cursors.Default;
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
            {
                toolButtonFileEdit.Enabled = false;
                toolButtonFileRename.Enabled = false;
                toolButtonFileDelete.Enabled = false;
                toolButtonPrint.Enabled = false;
                toolButtonFileExtract.Enabled = false;
                EmptyViewers();
            }
            else if (listViewFiles.SelectedItems.Count == 1)
            {
                if (((GedFile)listViewFiles.SelectedItems[0].Tag).type == GedFileType.PDF)
                {
                    toolButtonFileEdit.Enabled = true;
                    toolButtonPrint.Enabled = true;
                }
                else
                {
                    toolButtonFileEdit.Enabled = false;
                    toolButtonPrint.Enabled = false;
                }
                toolButtonFileRename.Enabled = true;
                toolButtonFileDelete.Enabled = true;
                toolButtonFileExtract.Enabled = true;

                FillViewer((GedFile)listViewFiles.SelectedItems[0].Tag);
            }
            else
            {
                toolButtonFileEdit.Enabled = false;
                toolButtonFileRename.Enabled = false;
                toolButtonFileDelete.Enabled = true;
                toolButtonPrint.Enabled = false;
                toolButtonFileExtract.Enabled = true;
                EmptyViewers();
            }
        }

        private void treeViewCategories_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    if (e.Control)
                    {
                        toolButtonFolderAdd_Click(null, null);
                    }
                    break;

                case Keys.F2:
                    toolButtonFolderRename_Click(null, null);
                    break;

                case Keys.F5:
                    toolButtonRefresh_Click(null, null);
                    break;

                case Keys.Delete:
                    toolButtonFolderDelete_Click(null, null);
                    break;
            }
        }

        private void listViewFiles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Control)
                    {
                        listViewFiles.Visible = false;
                        for (int i = 0; i < listViewFiles.Items.Count; i++)
                        {
                            listViewFiles.Items[i].Selected = true;
                        }
                        listViewFiles.Visible = true;
                    }
                    listViewFiles.Select();
                    break;

                case Keys.N:
                    if (e.Control)
                    {
                        toolButtonFileNew_Click(null, null);
                    }
                    break;

                case Keys.F2:
                    toolButtonFileRename_Click(null, null);
                    break;

                case Keys.F5:
                    toolButtonRefresh_Click(null, null);
                    break;

                case Keys.Delete:
                    toolButtonFileDelete_Click(null, null);
                    break;
            }
        }

        private void treeViewCategories_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (treeViewCategories.SelectedNode != null)
            {
                DataObject data = new DataObject();
                data.SetData(typeof(TreeNode), treeViewCategories.SelectedNode);

                listViewFiles.DoDragDrop(data, DragDropEffects.Move);
            }
        }

        private void listViewFiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DataObject data = new DataObject();
            GedList<GedFile> moveableGedList = new GedList<GedFile>();

            foreach (ListViewItem currentGedFile in listViewFiles.SelectedItems)
            {
                moveableGedList.Add((GedFile)currentGedFile.Tag);
            }
            data.SetData(typeof(GedList<GedFile>), moveableGedList);

            listViewFiles.DoDragDrop(data, DragDropEffects.Move);
        }

        private void treeViewCategories_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)) || e.Data.GetDataPresent(typeof(GedList<GedFile>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void treeViewCategories_DragOver(object sender, DragEventArgs e)
        {
            treeViewCategories.SelectedNode = treeViewCategories.GetNodeAt(treeViewCategories.PointToClient(new Point(e.X, e.Y)));
        }

        private void treeViewCategories_DragDrop(object sender, DragEventArgs e)
        {
            EmptyViewers();

            TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            TreeNode targetNode = treeViewCategories.GetNodeAt(treeViewCategories.PointToClient(new Point(e.X, e.Y)));
            if (targetNode != null)
            {
                GedFolder sourceFolder;
                GedFolder targetFolder = (GedFolder)targetNode.Tag;

                if (e.Data.GetDataPresent(typeof(TreeNode)))
                {
                    sourceFolder = (GedFolder)((TreeNode)e.Data.GetData(typeof(TreeNode))).Tag;

                    // Interdis de déplacer dossier racine, un dossier sur lui-même ou un parent sur son enfant
                    if (!sourceNode.Equals(targetNode) && !ContainsNode(sourceNode, targetNode))
                    {
                        if (sourceFolder.idParent != null)
                        {
                            Program.ServerMoveFolder(sourceFolder, targetFolder);
                        }
                    }
                }
                else if (e.Data.GetDataPresent(typeof(GedList<GedFile>)))
                {
                    sourceFolder = (GedFolder)treeViewCategories.SelectedNode.Tag;

                    foreach (GedFile currentGedFile in (GedList<GedFile>)e.Data.GetData(typeof(GedList<GedFile>)))
                    {
                        Program.ServerMoveFile(currentGedFile, targetFolder);
                    }
                }

                RefreshFilesList();
                treeViewCategories.SelectedNode = targetNode;
                treeViewCategories.Select();
            }
        }

        // Determine whether one node is a parent or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            return ContainsNode(node1, node2.Parent);
        }

    }
}
