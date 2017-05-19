using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using SharpGED_lib;
using System;
using System.IO;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class AddFileForm : Form
    {

        private PdfDocument[] newPdf = new PdfDocument[100];
        private String[] newPdfUri = new String[100];
        private bool[] isPdf = new bool[100];
        public GedFolder folder { get; set; }

        public AddFileForm()
        {
            InitializeComponent();
        }

        private void AddFileForm_Load(object sender, EventArgs e)
        {
            textBoxPdfName.Enabled = false;
            textBoxPdfName.Text = "";
            labelNbPages.Text = "(0 pages)";

            if (addPdfDialog.ShowDialog().Equals(DialogResult.OK))
            {
                for (int i = 0; i < addPdfDialog.FileNames.Length; i++)
                {
                    listBoxFiles.Items.Add(addPdfDialog.SafeFileNames[i].Substring(0, addPdfDialog.SafeFileNames[i].LastIndexOf(".")));

                    isPdf[i] = addPdfDialog.SafeFileNames[i].Substring(addPdfDialog.SafeFileNames[i].Length - 4, 4).Equals(".pdf");
                    if (isPdf[i])
                    {
                        newPdfUri[i] = addPdfDialog.FileNames[i];
                        newPdf[i] = PdfReader.Open(addPdfDialog.FileNames[i], PdfDocumentOpenMode.Import);
                    }
                    else
                    {
                        newPdfUri[i] = Program.NewTempFile();
                        newPdf[i] = new PdfDocument(newPdfUri[i]);

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
                    }
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

            RemoteGedFile file;
            byte[] fileBytes;
            int size;
            for (int i = 0; i < addPdfDialog.FileNames.Length; i++)
            {
                // Lit le fichier PDF et place son contenu dans un tableau
                using (FileStream inStream = File.OpenRead(newPdfUri[i]))
                {
                    size = (int)inStream.Length;
                    fileBytes = new byte[size];
                    inStream.Read(fileBytes, 0, size);
                }

                // Crée un GedFile et l'envoie au serveur
                file = new RemoteGedFile();
                file.folderId = folder.id;
                file.size = size;
                file.title = listBoxFiles.Items[i].ToString();
                if (isPdf[i])
                {
                    file.originalname = newPdfUri[i].Substring(newPdfUri[i].LastIndexOf("\\") + 1);
                }
                else
                {
                    file.originalname = addPdfDialog.SafeFileNames[i];
                }
                file.bytes = fileBytes;
                Program.ServerSendFile(file);

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

                if (isPdf[i])
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
    }

}
