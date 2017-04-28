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

        PdfDocument pdf;

        public AddFileForm()
        {
            InitializeComponent();
        }

        private void AddFileForm_Load(object sender, EventArgs e)
        {
            if (addPdfDialog.ShowDialog().Equals(DialogResult.OK))
            {
                pdf = PdfReader.Open(addPdfDialog.FileName, PdfDocumentOpenMode.Import);
                TextBoxPdfName.Text = pdf.Info.Title;
                LabelNbPages.Text = "(" + pdf.PageCount + " pages)";
            }
            else
            {
                Close();
            }
        }

        private void ButtonAddPdf_Click(object sender, EventArgs e)
        {
            // Lit le fichier PDF et place son contenu dans un tableau
            byte[] fileBytes;
            int size;
            using (FileStream inStream = File.OpenRead(pdf.FullPath))
            {
                size = (int)inStream.Length;
                fileBytes = new byte[size];
                inStream.Read(fileBytes, 0, size);
            }

            // Crée un GedFile et l'envoie au serveur
            GedFile file = new GedFile();
            file.size = size;
            file.title = TextBoxPdfName.Text;
            file.originalname = pdf.FullPath.Substring(pdf.FullPath.LastIndexOf("\\") + 1);
            file.bytes = fileBytes;
            Program.ServerSendFile(file);

            Close();
        }
    }

}
