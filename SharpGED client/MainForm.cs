using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
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

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (addPdfDialog.ShowDialog().Equals(DialogResult.OK))
            {
                pdf = PdfReader.Open(addPdfDialog.FileName, PdfDocumentOpenMode.Import);
                TextBoxPdfName.Text = pdf.Info.Title;
                LabelNbPages.Text = "(" + pdf.PageCount + " pages)";

                PdfViewer.Url = new Uri(addPdfDialog.FileName + "#toolbar=0&navpanes=0&scrollbar=1&view=FitH");
            }
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

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            Program.ServerSendFile(pdf.FullPath.Substring(pdf.FullPath.LastIndexOf("\\") + 1), pdf.FullPath);
        }

        private void ButtonStopServer_Click(object sender, EventArgs e)
        {
            Program.ServerHalt();
        }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            Program.ServerReciveFile(TextBoxRemoteCmd.Text);
            pdf = PdfReader.Open("C:\\TMP\\" + TextBoxRemoteCmd.Text + ".pdf", PdfDocumentOpenMode.Import);
            TextBoxPdfName.Text = pdf.Info.Title;
            LabelNbPages.Text = "(" + pdf.PageCount + " pages)";

            PdfViewer.Url = new Uri("C:\\TMP\\" + TextBoxRemoteCmd.Text + ".pdf" + "#toolbar=0&navpanes=0&scrollbar=1&view=FitH");
        }

    }
}
