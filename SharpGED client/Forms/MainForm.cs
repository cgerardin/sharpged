using PdfiumViewer;
using SharpGED_client.Forms;
using SharpGED_lib;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class MainForm : Form
    {

        private string lastClickedHash = "";
        private string lastClickedNode = "";
        private PdfDocument currentDocument;
        private string currentDocumentUri;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Déconnecte du serveur
            if (Program.IsConnectionUp())
            {
                Program.ServerDisconnect();
            }

            // Purge les fichiers temporaires
            if (currentDocument != null)
            {
                currentDocument.Dispose();
            }

            foreach (string tmpFile in Program.tempFiles)
            {
                try
                {
                    File.Delete(tmpFile);
                }
                catch (IOException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }

            // Réaffiche la fenêtre de connexion
            Program.loginForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshFilesList();
            EmptyViewer();

            // HiDPI trick
            MainToolbar.AutoSize = false;
            MainToolbar.ImageScalingSize = new System.Drawing.Size(32 * ((int)CreateGraphics().DpiX / 96), 32 * ((int)CreateGraphics().DpiY / 96));
            MainToolbar.AutoSize = true;

            // Contournement bug de Windows
            TreeViewCategories.Font = new Font(TreeViewCategories.Font, FontStyle.Bold);
        }

        private void RefreshFilesList()
        {
            EmptyViewer();
            ListBoxFiles.Items.Clear();
            TreeViewCategories.Nodes.Clear();

            foreach (GedFolder currentGedFolder in Program.ServerListFolders())
            {
                TreeViewCategories.Nodes.Add(BuildNode(currentGedFolder));
            }
            TreeViewCategories.Sort();
            TreeViewCategories.ExpandAll();

            // Re-sélectionne le dernier noeud actif
            if (TreeViewCategories.Nodes.Count > 0)
            {
                if (!lastClickedNode.Equals(""))
                {
                    TreeNode[] searchResult = TreeViewCategories.Nodes.Find(lastClickedNode, true);
                    if (searchResult.Length > 0)
                    {
                        TreeViewCategories.SelectedNode = TreeViewCategories.Nodes.Find(lastClickedNode, true)[0];
                    }
                    else
                    {
                        TreeViewCategories.SelectedNode = TreeViewCategories.Nodes[0];
                    }
                }
                else
                {
                    TreeViewCategories.SelectedNode = TreeViewCategories.Nodes[0];
                }

            }


        }

        private TreeNode BuildNode(GedFolder folder)
        {
            TreeNode node = new TreeNode(folder.title);
            node.Tag = folder;
            node.Name = folder.id.ToString();

            foreach (GedFolder subFolder in folder.folders)
            {
                TreeNode subNode = BuildNode(subFolder);
                subNode.Tag = subFolder;
                node.Nodes.Add(subNode);
            }

            // Image spéciale pour le(s) noeud(s) racine
            if (folder.idParent == null)
            {
                node.NodeFont = new Font(TreeViewCategories.Font, FontStyle.Bold);
                node.SelectedImageIndex = 0;
                node.ImageIndex = 0;
                // Ajoute le nom du serveur
                node.Text = node.Text + "@" + Program.serverHostname;
                node.EnsureVisible();
            }
            else
            {
                node.NodeFont = new Font(TreeViewCategories.Font, FontStyle.Regular);
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

        private void EmptyViewer()
        {
            LabelPdfName.Text = "-";
            LabelNbPages.Text = "(0 pages)";
            OriginalNameLabel.Text = "-";
            PdfViewer.Visible = false;
            if (currentDocument != null)
            {
                currentDocument.Dispose();
            }
            PdfViewer.Load(PdfDocument.Load("BLANK.pdf"));
        }

        private void ToolButtonNewFile_Click(object sender, EventArgs e)
        {
            if (TreeViewCategories.SelectedNode == null)
            {
                MessageBox.Show("Merci de sélectionner le dossier où le fichier sera déposé.", "Précision requise", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AddFileForm addFile = new AddFileForm();
            addFile.folder = (GedFolder)TreeViewCategories.SelectedNode.Tag;
            addFile.ShowDialog();

            RefreshFilesList();
        }

        private void ToolButtonDeleteFile_Click(object sender, EventArgs e)
        {
            if (ListBoxFiles.SelectedItem != null)
            {
                EmptyViewer();
                Program.ServerDeleteFile((GedFile)ListBoxFiles.SelectedItem);
                RefreshFilesList();
            }
        }

        private void ToolButtonRenameFile_Click(object sender, EventArgs e)
        {
            if (ListBoxFiles.SelectedItem != null)
            {
                InputForm input = new InputForm();
                input.title = "Entrez le nom souhaité pour le document";
                input.label = "Nom";
                input.value = ((GedFile)ListBoxFiles.SelectedItem).title;
                input.ShowDialog();

                while (input.Visible)
                {
                    Application.DoEvents();
                }

                Program.ServerRenameFile(((GedFile)ListBoxFiles.SelectedItem), input.value);
                input.Close();

                RefreshFilesList();
            }
        }

        private void ToolButtonEditFile_Click(object sender, EventArgs e)
        {
            string originalTitle = LabelPdfName.Text;
            string originalName = OriginalNameLabel.Text;

            EditPdfForm edit = new EditPdfForm();
            edit.documentUri = currentDocumentUri;
            DialogResult = edit.ShowDialog();

            while (edit.Visible)
            {
                Application.DoEvents();
            }

            if (DialogResult != DialogResult.OK)
            {
                return;
            }

            currentDocumentUri = edit.documentUri;
            Program.tempFiles.Add(currentDocumentUri);

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
            file.folderId = ((GedFolder)TreeViewCategories.SelectedNode.Tag).id;
            file.size = size;
            file.title = originalTitle + " (édité)";
            file.originalname = originalName;
            file.bytes = fileBytes;
            Program.ServerSendFile(file);

            edit.Close();
            RefreshFilesList();
        }

        private void ToolButtonFolderAdd_Click(object sender, EventArgs e)
        {
            GedFolder folder = new GedFolder();

            InputForm input = new InputForm();
            input.title = "Entrez le nom souhaité pour le dossier";
            input.label = "Nom";
            input.value = "Nouveau dossier";
            input.ShowDialog();

            while (input.Visible)
            {
                Application.DoEvents();
            }
            folder.title = input.value;
            input.Close();

            if (TreeViewCategories.SelectedNode != null)
            {
                folder.idParent = ((GedFolder)TreeViewCategories.SelectedNode.Tag).id;
            }

            Program.ServerCreateFolder(folder);
            RefreshFilesList();
        }

        private void ToolButtonFolderDelete_Click(object sender, EventArgs e)
        {
            // Interdis de supprimer un noeud racine
            if (((GedFolder)TreeViewCategories.SelectedNode.Tag).idParent != null)
            {
                Program.ServerDeleteFolder((GedFolder)TreeViewCategories.SelectedNode.Tag);
                lastClickedNode = "";
                RefreshFilesList();
            }
        }

        private void ToolButtonFolderRename_Click(object sender, EventArgs e)
        {
            if (TreeViewCategories.SelectedNode != null)
            {
                InputForm input = new InputForm();
                input.title = "Entrez le nom souhaité pour le dossier";
                input.label = "Nom";
                input.value = ((GedFolder)TreeViewCategories.SelectedNode.Tag).title;
                input.ShowDialog();

                while (input.Visible)
                {
                    Application.DoEvents();
                }

                Program.ServerRenameFolder((GedFolder)TreeViewCategories.SelectedNode.Tag, input.value);
                input.Close();

                RefreshFilesList();
            }
        }

        private void ToolButtonPrint_Click(object sender, EventArgs e)
        {
            printPdf = PdfViewer.Document.CreatePrintDocument();
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

        private void ToolButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshFilesList();
            lastClickedNode = "";
        }

        private void ToolButtonInitDatabase_Click(object sender, EventArgs e)
        {
            Program.ServerSend("INIT");
            RefreshFilesList();
        }

        private void ToolButtonStopServer_Click(object sender, EventArgs e)
        {
            Program.ServerHalt();
            Close();
        }

        private void ToolButtonDisconnect_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TreeViewCategories_Click(object sender, EventArgs e)
        {
            // Nécessaire pour rafraichir _AfterSelect si on reclique sur le même élément
            TreeViewCategories.SelectedNode = null;
        }

        private void TreeViewCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lastClickedHash = "";
            ListBoxFiles.SelectedItem = null;
            ListBoxFiles.Items.Clear();
            foreach (GedFile currentGedFile in ((GedFolder)TreeViewCategories.SelectedNode.Tag).files)
            {
                ListBoxFiles.Items.Add(currentGedFile);
            }
            lastClickedNode = TreeViewCategories.SelectedNode.Name;
        }

        private void ListBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxFiles.SelectedItem != null)
            {
                GedFile selectedFile = (GedFile)ListBoxFiles.SelectedItem;

                if (selectedFile.hash.Equals(lastClickedHash))
                {
                    return;
                }
                else
                {
                    lastClickedHash = selectedFile.hash;
                }

                RemoteGedFile file = Program.ServerReciveFile(selectedFile);

                // Ecris le fichier dans un fichier temporaire sur le disque
                string localFilename = Path.GetTempFileName() + ".pdf";
                FileStream outStream = new FileStream(localFilename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 1024, FileOptions.None);
                outStream.Write(file.bytes, 0, file.size);
                outStream.Close();

                // Charge et affiche le PDF
                LabelPdfName.Text = file.title;
                LabelNbPages.Text = "(" + file.pages + " pages)";
                OriginalNameLabel.Text = file.originalname;

                PdfViewer.Visible = false;
                if (currentDocument != null)
                {
                    currentDocument.Dispose();
                }
                currentDocument = PdfDocument.Load(localFilename);
                PdfViewer.Load(currentDocument);
                PdfViewer.Visible = true;

                // Mémorise le fichier temporaire et son URI
                Program.tempFiles.Add(localFilename);
                currentDocumentUri = localFilename;
            }
            else
            {
                EmptyViewer();
            }
        }

        private void ChildSplitContainer_Resize(object sender, EventArgs e)
        {
            PropertiesGroupBox.Top = ListBoxFiles.Top + ListBoxFiles.Height + 10;
            PropertiesGroupBox.Height = Height - ListBoxFiles.Top - ListBoxFiles.Height - 110;
        }

        private void ListBoxFiles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    ToolButtonRenameFile_Click(null, null);
                    break;

                case Keys.F5:
                    ToolButtonRefresh_Click(null, null);
                    break;

                case Keys.Delete:
                    ToolButtonDeleteFile_Click(null, null);
                    break;
            }
        }

        private void TreeViewCategories_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    ToolButtonFolderRename_Click(null, null);
                    break;

                case Keys.F5:
                    ToolButtonRefresh_Click(null, null);
                    break;

                case Keys.Delete:
                    ToolButtonFolderDelete_Click(null, null);
                    break;
            }
        }

    }
}
