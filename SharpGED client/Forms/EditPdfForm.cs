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

        public EditPdfForm()
        {
            InitializeComponent();
        }

        private void EditPdfForm_Load(object sender, EventArgs e)
        {
            // HiDPI trick
            MainToolbar.AutoSize = false;
            MainToolbar.ImageScalingSize = new System.Drawing.Size(32 * ((int)CreateGraphics().DpiX / 96) + 8, 32 * ((int)CreateGraphics().DpiY / 96));
            MainToolbar.AutoSize = true;

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
            source.Close();
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

        private void ToolButtonCut_Click(object sender, EventArgs e)
        {
            EmptyViewer();

            if (ListBoxPages.SelectedItem != null)
            {
                int i = (int)ListBoxPages.SelectedItem;
                ListBoxPages.SelectedItem = null;
                File.Delete(documentUri.Substring(0, documentUri.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                ListBoxPages.Items.Remove(i);

                if (ListBoxPages.Items.Count > 0)
                {
                    ListBoxPages.SelectedIndex = 0;
                }
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

        private void ToolButtonSave_Click(object sender, EventArgs e)
        {
            EmptyViewer();
            PdfDocument merge = new PdfDocument();
            merge.Info.Title = source.Info.Title;

            if (ListBoxPages.Items.Count > 0)
            {
                foreach (int currPage in ListBoxPages.Items)
                {
                    if (source.Pages.Count > 0)
                    {
                        merge.AddPage(source.Pages[currPage - 1]);
                    }
                    File.Delete(documentUri.Substring(0, documentUri.Length - 4) + "[" + currPage.ToString("0000") + "].pdf");
                }

                documentUri = documentUri.Substring(0, documentUri.Length - 4) + "[EDIT].pdf";
                merge.Save(documentUri);
                merge.Close();

                DialogResult = DialogResult.OK;
            }

            Hide();
        }

    }
}
