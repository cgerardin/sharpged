﻿using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpGED_lib;
using System;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class MainForm : Form
    {

        PdfDocument pdf;

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

        private void ButtonEclaterPdf_Click(object sender, EventArgs e)
        {
            int i = 0;
            PdfDocument split;
            foreach (PdfPage currPage in pdf.Pages)
            {
                i++;
                split = new PdfDocument(pdf.FullPath.Substring(0, pdf.FullPath.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                ListBoxPages.Items.Add(i);
                split.AddPage(currPage);
                split.Close();
            }
        }

        private void ListBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = (int)ListBoxPages.SelectedItem;
            PdfViewer.Url = new Uri(pdf.FullPath.Substring(0, pdf.FullPath.Length - 4) + "[" + i.ToString("0000") + "].pdf" + "#toolbar=0&navpanes=0&scrollbar=1&view=FitW");
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

        private void ListBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ServerReciveFile(ListBoxFiles.SelectedItem.ToString());
            pdf = PdfReader.Open("C:\\TMP\\" + ListBoxFiles.SelectedItem.ToString() + ".pdf", PdfDocumentOpenMode.Import);
            TextBoxPdfName.Text = pdf.Info.Title;
            LabelNbPages.Text = "(" + pdf.PageCount + " pages)";

            PdfViewer.Url = new Uri("C:\\TMP\\" + ListBoxFiles.SelectedItem.ToString() + ".pdf" + "#toolbar=0&navpanes=0&scrollbar=1&view=FitH");
        }

        private void RefreshFilesList()
        {
            ListBoxFiles.Items.Clear();
            foreach (string filename in Program.ServerListFiles())
            {
                ListBoxFiles.Items.Add(filename);
            }
        }

    }
}
