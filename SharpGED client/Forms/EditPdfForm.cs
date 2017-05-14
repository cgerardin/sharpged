using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client.Forms
{
    public partial class EditPdfForm : Form
    {
        public string documentUri { get; set; }
        public PdfDocument source { get; set; }
        public PdfiumViewer.PdfDocument currentDocument { get; set; }

        private String newFileUri;

        public EditPdfForm()
        {
            InitializeComponent();
        }

        private void EditPdfForm_Load(object sender, EventArgs e)
        {
            source = PdfReader.Open(documentUri, PdfDocumentOpenMode.Import);
            int i = 0;

            PdfDocument split;
            foreach (PdfPage currPage in source.Pages)
            {
                i++;
                split = new PdfDocument(documentUri.Substring(0, documentUri.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                ListBoxPages.Items.Add(i);
                split.AddPage(currPage);
                split.Close();
            }

            ListBoxPages.SelectedIndex = 0;
        }

        private void EditPdfForm_FormClosed(object sender, FormClosingEventArgs e)
        {
            EmptyViewer();
        }

        private void ListBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxPages.SelectedItem != null)
            {
                int i = (int)ListBoxPages.SelectedItem;

                PdfViewer.Visible = false;
                if (currentDocument != null)
                {
                    currentDocument.Dispose();
                }
                currentDocument = PdfiumViewer.PdfDocument.Load(documentUri.Substring(0, documentUri.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                PdfViewer.Load(currentDocument);
                PdfViewer.Visible = true;
            }
            else
            {
                EmptyViewer();
            }
        }

        private void EmptyViewer()
        {
            PdfViewer.Visible = false;
            if (currentDocument != null)
            {
                currentDocument.Dispose();
            }
            PdfViewer.Load(PdfiumViewer.PdfDocument.Load("BLANK.pdf"));
        }

        private void ToolButtonCut_Click(object sender, EventArgs e)
        {
            if (ListBoxPages.SelectedItem != null)
            {
                if (ListBoxPages.Items.Count == 1)
                {
                    MessageBox.Show("Le document doit comporter au moins une page.", "Impossible d'effectuer l'action", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                EmptyViewer();

                int i = (int)ListBoxPages.SelectedItem;
                ListBoxPages.SelectedItem = null;
                File.Delete(documentUri.Substring(0, documentUri.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                ListBoxPages.Items.Remove(i);
            }
        }

        private void ToolButtonUp_Click(object sender, EventArgs e)
        {
            int index = ListBoxPages.SelectedIndex;

            if (ListBoxPages.SelectedItem != null && index > 0)
            {
                ListBoxPages.Items.Insert(index - 1, ListBoxPages.SelectedItem);
                ListBoxPages.Items.RemoveAt(index + 1);
                ListBoxPages.SelectedIndex = index - 1;
            }
        }

        private void ToolButtonDown_Click(object sender, EventArgs e)
        {
            int index = ListBoxPages.SelectedIndex;

            if (ListBoxPages.SelectedItem != null && index < ListBoxPages.Items.Count - 1)
            {
                ListBoxPages.Items.Insert(index + 2, ListBoxPages.SelectedItem);
                ListBoxPages.Items.RemoveAt(index);
                ListBoxPages.SelectedIndex = index + 1;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            EmptyViewer();

            PdfDocument merge = new PdfDocument();
            merge.Info.Title = source.Info.Title; ;

            foreach (int currPage in ListBoxPages.Items)
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
