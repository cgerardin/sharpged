﻿using SharpGED_lib;
using System;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshFilesList();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            Form addFile = new AddFileForm();
            addFile.Show();
            while (addFile.Visible)
            {
                Application.DoEvents();
            }

            RefreshFilesList();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
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

        private void ListBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxFiles.SelectedItem != null)
            {
                RemoteGedFile file = Program.ServerReciveFile((GedFile)ListBoxFiles.SelectedItem);

                // Ecris le fichier dans un fichier temporaire sur le disque
                string localFilename = Path.GetTempFileName() + ".pdf";
                FileStream outStream = File.OpenWrite(localFilename);
                outStream.Write(file.bytes, 0, file.size);
                outStream.Close();

                // Affiche le PDF
                LabelPdfName.Text = file.title;
                LabelNbPages.Text = "(" + file.pages + " pages)";
                PdfViewer.Url = new Uri(localFilename + "#toolbar=0&navpanes=0&scrollbar=1&view=FitH");

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
                LabelPdfName.Text = "";
                LabelNbPages.Text = "(0 pages)";
            }

        }

        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            Program.ServerDisconnect();
        }

        private void ButtonStopServer_Click(object sender, EventArgs e)
        {
            Program.ServerHalt();
        }

        private void ButtonInitServer_Click(object sender, EventArgs e)
        {
            Program.ServerSend("INIT");
        }

        private void RefreshFilesList()
        {
            ListBoxFiles.SelectedItem = null;
            ListBoxFiles.Items.Clear();
            foreach (GedFile currentGedFile in Program.ServerListFiles())
            {
                ListBoxFiles.Items.Add(currentGedFile);
            }
        }

    }
}
