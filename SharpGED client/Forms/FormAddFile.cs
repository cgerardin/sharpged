using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpGED_lib;
using System;
using System.IO;
using System.Windows.Forms;
using static SharpGED_lib.GedFile;

namespace SharpGED_client
{
    public partial class formAddFile : Form
    {

        private PdfDocument[] newPdf = new PdfDocument[100];
        private String[] newFileUri = new String[100];
        private bool[] convertToPdf = new bool[100];
        private GedFileType[] fileType = new GedFileType[100];
        public GedFolder folder { get; set; }

        public formAddFile()
        {
            InitializeComponent();
        }

        private void AddFileForm_Load(object sender, EventArgs e)
        {
            textBoxPdfName.Enabled = false;
            textBoxPdfName.Text = "";
            labelNbPages.Text = "(0 pages)";
            checkBoxConvertPdf.Enabled = false;
            checkBoxConvertPdf.Checked = false;

            if (addPdfDialog.ShowDialog().Equals(DialogResult.OK))
            {
                for (int i = 0; i < addPdfDialog.FileNames.Length; i++)
                {
                    listBoxFiles.Items.Add(addPdfDialog.SafeFileNames[i].Substring(0, addPdfDialog.SafeFileNames[i].LastIndexOf(".")));

                    switch (addPdfDialog.SafeFileNames[i].Substring(addPdfDialog.SafeFileNames[i].LastIndexOf(".")))
                    {
                        case ".pdf":
                            fileType[i] = GedFileType.PDF;
                            break;

                        case ".jpeg":
                            fileType[i] = GedFileType.Image;
                            break;

                        case ".jpg":
                            fileType[i] = GedFileType.Image;
                            break;

                        case ".png":
                            fileType[i] = GedFileType.Image;
                            break;

                        case "docx":
                            fileType[i] = GedFileType.Office;
                            break;
                    }

                    if (fileType[i] == GedFileType.PDF)
                    {
                        newPdf[i] = PdfReader.Open(addPdfDialog.FileNames[i], PdfDocumentOpenMode.Import);
                    }
                    newFileUri[i] = addPdfDialog.FileNames[i];
                }
            }
            else
            {
                Close();
            }
        }

        private void ButtonAddPdf_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            progressBarTransfert.Minimum = 0;
            progressBarTransfert.Maximum = addPdfDialog.FileNames.Length * 2;

            RemoteGedFile file;
            byte[] fileBytes;
            int size;
            for (int i = 0; i < addPdfDialog.FileNames.Length; i++)
            {

                labelCurrentFile.Text = addPdfDialog.SafeFileNames[i] + " ...";

                // Conversion des fichiers image
                if (fileType[i] == GedFileType.PDF && convertToPdf[i])
                {
                    newFileUri[i] = Program.NewTempFile();
                    newPdf[i] = new PdfDocument(newFileUri[i]);

                    PdfPage page = newPdf[i].AddPage();
                    page.Size = PdfSharp.PageSize.A4;

                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XImage xImage = XImage.FromFile(addPdfDialog.FileNames[i]);

                    double imageWidth = xImage.PointWidth;
                    double imageHeight = xImage.PointHeight;
                    double pageWidth = page.Width.Point;
                    double pageHeight = page.Height.Point;
                    double marginLeft = (pageWidth - imageWidth) / 2;
                    double marginTop = (pageHeight - imageHeight) / 2;

                    gfx.DrawImage(xImage, new XRect(marginLeft, marginTop, pageWidth, pageHeight), new XRect(0, 0, imageWidth, imageHeight), XGraphicsUnit.Point);

                    newPdf[i].Close();
                    fileType[i] = GedFileType.PDF;
                }

                // Conversion des documents bureautique
                if (fileType[i] == GedFileType.Office && convertToPdf[i])
                {
                    newFileUri[i] = Program.NewTempFile();

                    Microsoft.Office.Interop.Word.Document wordDocument;
                    Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();

                    wordDocument = appWord.Documents.Open(addPdfDialog.FileNames[i]);
                    wordDocument.ExportAsFixedFormat(newFileUri[i], Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                    wordDocument.Close();

                    fileType[i] = GedFileType.PDF;
                }

                // Lit le fichier et place son contenu dans un tableau
                using (FileStream inStream = File.OpenRead(newFileUri[i]))
                {
                    size = (int)inStream.Length;
                    fileBytes = new byte[size];
                    inStream.Read(fileBytes, 0, size);
                }

                progressBarTransfert.Value++;

                // Crée un GedFile et l'envoie au serveur
                file = new RemoteGedFile();
                file.type = fileType[i];
                file.folderId = folder.id;
                file.size = size;
                file.title = listBoxFiles.Items[i].ToString();
                file.originalname = addPdfDialog.SafeFileNames[i];
                file.bytes = fileBytes;
                Program.ServerSendFile(file);

                progressBarTransfert.Value++;

            }

            Cursor = Cursors.Default;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxFiles.SelectedIndex;

            if (i != -1)
            {
                textBoxPdfName.Enabled = true;
                textBoxPdfName.Text = listBoxFiles.Items[i].ToString();
                checkBoxConvertPdf.Checked = convertToPdf[i];
                checkBoxConvertPdf.Enabled = fileType[i] != GedFileType.PDF;

                if (fileType[i] == GedFileType.PDF)
                {
                    labelNbPages.Text = "(" + newPdf[i].PageCount + " pages)";
                }
                else
                {
                    labelNbPages.Text = "(1 pages)";
                }
            }
            else
            {
                textBoxPdfName.Enabled = false;
                textBoxPdfName.Text = "";
                labelNbPages.Text = "(0 pages)";
            }
        }

        private void textBoxPdfName_TextChanged(object sender, EventArgs e)
        {
            int i = listBoxFiles.SelectedIndex;

            if (i != -1)
            {
                listBoxFiles.Items[i] = textBoxPdfName.Text;
            }
        }

        private void formAddFile_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;

                case Keys.Enter:
                    ButtonAddPdf_Click(null, null);
                    break;
            }
        }

        private void checkBoxConvertPdf_CheckedChanged(object sender, EventArgs e)
        {
            int i = listBoxFiles.SelectedIndex;

            if (i != -1)
            {
                convertToPdf[i] = checkBoxConvertPdf.Checked;
            }
        }
    }

}
