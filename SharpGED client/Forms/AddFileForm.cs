using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
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
            Program.ServerSendFile(pdf.FullPath.Substring(pdf.FullPath.LastIndexOf("\\") + 1), TextBoxPdfName.Text, pdf.FullPath);
            Close();
        }
    }

}
