using PdfiumViewer;
using SharpGED_client.Forms;
using SharpGED_lib;
using System;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class MainForm : Form
    {

        private string lastClickedHash = "";
        private PdfDocument currentDocument;

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

            MainToolbar.AutoSize = false;
            MainToolbar.ImageScalingSize = new System.Drawing.Size(32 * ((int)CreateGraphics().DpiX / 96), 32 * ((int)CreateGraphics().DpiY / 96));
            MainToolbar.AutoSize = true;
        }

        private void RefreshFilesList()
        {
            TreeViewCategories.Nodes.Clear();
            foreach (GedFolder currentGedFolder in Program.ServerListFolders())
            {
                TreeViewCategories.Nodes.Add(BuildNode(currentGedFolder));
            }
            EmptyViewer();
            ListBoxFiles.Items.Clear();

            // Sélectionne le noeud racine
            if (TreeViewCategories.Nodes.Count > 0)
            {
                TreeViewCategories.SelectedNode = TreeViewCategories.Nodes[0];
            }
        }

        private TreeNode BuildNode(GedFolder folder)
        {
            TreeNode node = new TreeNode(folder.title);
            node.Tag = folder;

            foreach (GedFolder subFolder in folder.folders)
            {
                TreeNode subNode = BuildNode(subFolder);
                subNode.Tag = subFolder;
                node.Nodes.Add(subNode);
            }

            // Image spéciale pour le(s) noeud(s) racine
            if (folder.idParent == null)
            {
                node.SelectedImageIndex = 1;
                node.ImageIndex = 1;
                // Ajoute le nom du serveur
                node.Text = node.Text + "@" + Program.serverHostname + ":" + Program.serverPort;
            }
            else
            {
                node.SelectedImageIndex = 0;
                node.ImageIndex = 0;
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
                MessageBox.Show("Merci de sélectionner le dossier où le fichier sera déposé.");
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
                Program.ServerSend("DEL " + ((GedFile)ListBoxFiles.SelectedItem).hash);
                RefreshFilesList();
            }
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

            Program.ServerCreateFolders(folder);
            RefreshFilesList();
        }

        private void ToolButtonPrint_Click(object sender, EventArgs e)
        {
            //AdobeReader.LoadFile(localFilename);
            //AdobeReader.printWithDialog();
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

        private void TreeViewCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lastClickedHash = "";
            ListBoxFiles.SelectedItem = null;
            ListBoxFiles.Items.Clear();
            foreach (GedFile currentGedFile in ((GedFolder)TreeViewCategories.SelectedNode.Tag).files)
            {
                ListBoxFiles.Items.Add(currentGedFile);
            }
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

                // Mémorise le fichier temporaire
                Program.tempFiles.Add(localFilename);
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (ListBoxFiles.SelectedItem != null)
                    {
                        InputForm input = new InputForm();
                        input.title = "Entrez le nom souhaité pour le document";
                        input.label = "Titre";
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
                    break;
            }
        }

    }
}
