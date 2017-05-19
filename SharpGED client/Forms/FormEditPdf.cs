using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client.Forms
{
    public partial class formEditPdf : Form
    {
        public string documentUri { get; set; }
        public PdfDocument source { get; set; }
        public PdfiumViewer.PdfDocument currentDocument { get; set; }

        private String newFileUri;

        public formEditPdf()
        {
            InitializeComponent();
        }

        private void formEditPdf_Load(object sender, EventArgs e)
        {
            source = PdfReader.Open(documentUri, PdfDocumentOpenMode.Import);
            int i = 0;

            PdfDocument split;
            foreach (PdfPage currPage in source.Pages)
            {
                i++;
                split = new PdfDocument(documentUri.Substring(0, documentUri.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                listBoxPages.Items.Add(i);
                split.AddPage(currPage);
                split.Close();
            }

            listBoxPages.SelectedIndex = 0;
        }

        private void formEditPdf_FormClosed(object sender, FormClosingEventArgs e)
        {
            EmptyViewer();
        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPages.SelectedItem != null)
            {
                int i = (int)listBoxPages.SelectedItem;

                pdfViewer.Visible = false;
                if (currentDocument != null)
                {
                    currentDocument.Dispose();
                }
                currentDocument = PdfiumViewer.PdfDocument.Load(documentUri.Substring(0, documentUri.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                pdfViewer.Load(currentDocument);
                pdfViewer.Visible = true;
            }
            else
            {
                EmptyViewer();
            }
        }

        private void EmptyViewer()
        {
            pdfViewer.Visible = false;
            if (currentDocument != null)
            {
                currentDocument.Dispose();
            }
            pdfViewer.Load(PdfiumViewer.PdfDocument.Load("BLANK.pdf"));
        }

        private void toolButtonCut_Click(object sender, EventArgs e)
        {
            if (listBoxPages.SelectedItem != null)
            {
                if (listBoxPages.Items.Count == 1)
                {
                    MessageBox.Show("Le document doit comporter au moins une page.", "Impossible d'effectuer l'action", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                EmptyViewer();

                int i = (int)listBoxPages.SelectedItem;
                listBoxPages.SelectedItem = null;
                File.Delete(documentUri.Substring(0, documentUri.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                listBoxPages.Items.Remove(i);
            }
        }

        private void toolButtonUp_Click(object sender, EventArgs e)
        {
            int index = listBoxPages.SelectedIndex;

            if (listBoxPages.SelectedItem != null && index > 0)
            {
                listBoxPages.Items.Insert(index - 1, listBoxPages.SelectedItem);
                listBoxPages.Items.RemoveAt(index + 1);
                listBoxPages.SelectedIndex = index - 1;
            }
        }

        private void toolButtonDown_Click(object sender, EventArgs e)
        {
            int index = listBoxPages.SelectedIndex;

            if (listBoxPages.SelectedItem != null && index < listBoxPages.Items.Count - 1)
            {
                listBoxPages.Items.Insert(index + 2, listBoxPages.SelectedItem);
                listBoxPages.Items.RemoveAt(index);
                listBoxPages.SelectedIndex = index + 1;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            EmptyViewer();

            PdfDocument merge = new PdfDocument();
            merge.Info.Title = source.Info.Title; ;

            foreach (int currPage in listBoxPages.Items)
            {
                merge.AddPage(source.Pages[currPage - 1]);
                File.Delete(documentUri.Substring(0, documentUri.Length - 4) + "[" + currPage.ToString("0000") + "].pdf");
            }

            documentUri = Program.NewTempFile();
            merge.Save(documentUri);
            merge.Close();

            DialogResult = DialogResult.OK;

            Close();
        }

    }
}
