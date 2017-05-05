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
            currentDocument.Dispose();
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
            lastClickedHash = "";
            ListBoxFiles.SelectedItem = null;
            ListBoxFiles.Items.Clear();
            foreach (GedFile currentGedFile in Program.ServerListFiles())
            {
                ListBoxFiles.Items.Add(currentGedFile);
            }
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
            Form addFile = new AddFileForm();
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

        private void ToolButtonInitDatabase_Click(object sender, EventArgs e)
        {
            Program.ServerSend("INIT");
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

        private void ToolButtonPrint_Click(object sender, EventArgs e)
        {
            //AdobeReader.LoadFile(localFilename);
            //AdobeReader.printWithDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (ListBoxFiles.SelectedItem != null)
                    {
                        RenameForm rename = new RenameForm();
                        rename.file = (GedFile)ListBoxFiles.SelectedItem;
                        rename.ShowDialog();
                        RefreshFilesList();
                    }
                    break;
            }
        }

    }
}
