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

        private PdfDocument newPdf;
        private String newPdfUri;
        private bool isPdf;
        public GedFolder folder { get; set; }

        public AddFileForm()
        {
            InitializeComponent();
        }

        private void AddFileForm_Load(object sender, EventArgs e)
        {
            if (addPdfDialog.ShowDialog().Equals(DialogResult.OK))
            {
                isPdf = addPdfDialog.SafeFileName.Substring(addPdfDialog.SafeFileName.Length - 4, 4).Equals(".pdf");

                if (isPdf)
                {
                    newPdfUri = addPdfDialog.FileName;
                    newPdf = PdfReader.Open(addPdfDialog.FileName, PdfDocumentOpenMode.Import);


                    if (!newPdf.Info.Title.Equals(""))
                    {
                        TextBoxPdfName.Text = newPdf.Info.Title;
                    }
                    else
                    {
                        TextBoxPdfName.Text = addPdfDialog.SafeFileName.Substring(0, addPdfDialog.SafeFileName.LastIndexOf("."));
                    }

                    LabelNbPages.Text = "(" + newPdf.PageCount + " pages)";
                }
                else
                {
                    newPdfUri = Program.NewTempFile();
                    newPdf = new PdfDocument(newPdfUri);

                    PdfPage page = newPdf.AddPage();
                    page.Size = PdfSharp.PageSize.A4;

                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XImage xImage = XImage.FromFile(addPdfDialog.FileName);

                    double imageWidth = xImage.PointWidth;
                    double imageHeight = xImage.PointHeight;
                    double pageWidth = page.Width.Point;
                    double pageHeight = page.Height.Point;
                    double marginLeft = (pageWidth - imageWidth) / 2;
                    double marginTop = (pageHeight - imageHeight) / 2;

                    gfx.DrawImage(xImage, new XRect(marginLeft, marginTop, pageWidth, pageHeight), new XRect(0, 0, imageWidth, imageHeight), XGraphicsUnit.Point);

                    newPdf.Close();

                    TextBoxPdfName.Text = addPdfDialog.SafeFileName.Substring(0, addPdfDialog.SafeFileName.LastIndexOf("."));
                    LabelNbPages.Text = "(1 pages)";
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

            // Lit le fichier PDF et place son contenu dans un tableau
            byte[] fileBytes;
            int size;
            using (FileStream inStream = File.OpenRead(newPdfUri))
            {
                size = (int)inStream.Length;
                fileBytes = new byte[size];
                inStream.Read(fileBytes, 0, size);
            }

            // Crée un GedFile et l'envoie au serveur
            RemoteGedFile file = new RemoteGedFile();
            file.folderId = folder.id;
            file.size = size;
            file.title = TextBoxPdfName.Text;
            if (isPdf)
            {
                file.originalname = newPdfUri.Substring(newPdfUri.LastIndexOf("\\") + 1);
            }
            else
            {
                file.originalname = addPdfDialog.SafeFileName;
            }
            file.bytes = fileBytes;
            Program.ServerSendFile(file);

            Cursor = Cursors.Default;

            DialogResult = DialogResult.OK;
            Close();
        }
    }

}
