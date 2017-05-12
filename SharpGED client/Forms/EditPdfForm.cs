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

        private bool newFile = false;
        private String newFileUri;

        public EditPdfForm()
        {
            InitializeComponent();
        }

        private void EditPdfForm_Load(object sender, EventArgs e)
        {
            if (documentUri == null)
            {
                newFile = true;
                documentUri = Path.GetTempFileName() + ".pdf";
                newFileUri = Path.GetTempFileName() + ".pdf";
                Program.tempFiles.Add(documentUri);
                Program.tempFiles.Add(newFileUri);

                // Crée un document vide
                source = new PdfDocument(newFileUri);
                source.AddPage();
                source.Close();

                source = PdfReader.Open(newFileUri, PdfDocumentOpenMode.Import);
            }
            else
            {
                source = PdfReader.Open(documentUri, PdfDocumentOpenMode.Import);
            }

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
            String title;

            if (newFile)
            {
                InputForm inputDialog = new InputForm();
                inputDialog.title = "Entrez le nom souhaité pour le document";
                inputDialog.label = "Nom";
                inputDialog.value = "Nouveau document";

                if (inputDialog.ShowDialog() == DialogResult.OK)
                {
                    title = inputDialog.value;
                }
                else
                {
                    return;
                }
            }
            else
            {
                title = source.Info.Title;
            }

            merge.Info.Title = title;

            if (ListBoxPages.Items.Count > 0)
            {
                foreach (int currPage in ListBoxPages.Items)
                {
                    merge.AddPage(source.Pages[currPage - 1]);
                    File.Delete(documentUri.Substring(0, documentUri.Length - 4) + "[" + currPage.ToString("0000") + "].pdf");
                }

                documentUri = documentUri.Substring(0, documentUri.Length - 4) + "[EDIT].pdf";
                merge.Save(documentUri);
                merge.Close();

                Program.tempFiles.Add(documentUri);
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void ToolButtonAddPage_Click(object sender, EventArgs e)
        {
            int pageNum = ListBoxPages.Items.Count + 1;
            String pageUri = documentUri.Substring(0, documentUri.Length - 4) + "[" + pageNum.ToString("0000") + "].pdf";
            Program.tempFiles.Add(documentUri);

            PdfDocument newDocument = new PdfDocument(pageUri);
            PdfPage page = newDocument.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage xImage = XImage.FromFile("C:\\Users\\GERARDIN\\Pictures\\PPEX.bmp");
            gfx.DrawImage(xImage, 0, 0, xImage.PixelWidth, xImage.PixelHeight);

            newDocument.Close();

            newDocument = PdfReader.Open(pageUri, PdfDocumentOpenMode.Import);
            source.AddPage(newDocument.Pages[0]);
            newDocument.Close();

            ListBoxPages.Items.Add(pageNum);
        }

    }
}
