using Microsoft.Win32;
using SharpGED_lib;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class MainForm : Form
    {

        private string lastClickedHash = "";
        private string currentDocumentUri = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.IsConnectionUp())
            {
                Program.ServerDisconnect();
            }
            Program.loginForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshFilesList();

            MainToolbar.AutoSize = false;
            MainToolbar.ImageScalingSize = new System.Drawing.Size(32 * ((int)CreateGraphics().DpiX / 96), 32 * ((int)CreateGraphics().DpiY / 96));
            MainToolbar.AutoSize = true;

            WindowState = FormWindowState.Maximized;
        }

        private void RefreshFilesList()
        {
            lastClickedHash = "";
            currentDocumentUri = "";
            ListBoxFiles.SelectedItem = null;
            ListBoxFiles.Items.Clear();
            foreach (GedFile currentGedFile in Program.ServerListFiles())
            {
                ListBoxFiles.Items.Add(currentGedFile);
            }
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
                PdfViewer.Url = new Uri("about:blank");
                LabelPdfName.Text = "";
                LabelNbPages.Text = "(0 pages)";

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
                FileStream outStream = File.OpenWrite(localFilename);
                outStream.Write(file.bytes, 0, file.size);
                outStream.Close();

                // Affiche le PDF
                LabelPdfName.Text = file.title;
                LabelNbPages.Text = "(" + file.pages + " pages)";
                OriginalNameLabel.Text = file.originalname;
                PdfViewer.Url = new Uri(localFilename + "#toolbar=0&navpanes=0&scrollbar=1&view=FitH");
                AdobeReader.LoadFile(localFilename);
                currentDocumentUri = localFilename; // Mémorise le chemin local vers le fichier

                // Mémorise le fichier temporaire
                /*foreach (string tmpFile in Program.tempFiles)
                {
                    File.Delete(tmpFile);
                }
                Program.tempFiles.Clear();*/
                Program.tempFiles.Add(localFilename);
            }
            else
            {
                PdfViewer.Url = new Uri("about:blank");
                LabelPdfName.Text = "-";
                LabelNbPages.Text = "(0 pages)";
                OriginalNameLabel.Text = "-";
            }
        }

        private void ChildSplitContainer_Resize(object sender, EventArgs e)
        {
            PropertiesGroupBox.Top = ListBoxFiles.Top + ListBoxFiles.Height + 10;
            PropertiesGroupBox.Height = Height - ListBoxFiles.Top - ListBoxFiles.Height - 110;
        }

        private void ToolButtonPrint_Click(object sender, EventArgs e)
        {
            AdobeReader.printWithDialog();
        }
    }
}
