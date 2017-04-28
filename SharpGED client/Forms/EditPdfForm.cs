using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpGED_client.Forms
{
    public partial class EditPdfForm : Form
    {
        private PdfDocument pdf;

        public EditPdfForm()
        {
            InitializeComponent();
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
            // PdfViewer.Url = new Uri(pdf.FullPath.Substring(0, pdf.FullPath.Length - 4) + "[" + i.ToString("0000") + "].pdf" + "#toolbar=0&navpanes=0&scrollbar=1&view=FitW");
        }
    }
}
