using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class MainForm : Form
    {

        PdfDocument pdf;
        Socket sock = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (addPdfDialog.ShowDialog().Equals(DialogResult.OK))
            {
                pdf = PdfReader.Open(addPdfDialog.FileName, PdfDocumentOpenMode.Import);
                TextBoxPdfName.Text = pdf.Info.Title;
                LabelNbPages.Text = "(" + pdf.PageCount + " pages)";

                PdfViewer.Url = new Uri(addPdfDialog.FileName + "#toolbar=0&navpanes=0&scrollbar=1&view=FitH");

            }

        }

        private void ButtonEclaterPdf_Click(object sender, EventArgs e)
        {

            int i = 0;
            PdfDocument split;
            foreach (PdfPage currPage in pdf.Pages)
            {
                i++;
                split = new PdfDocument(addPdfDialog.FileName.Substring(0, addPdfDialog.FileName.Length - 4) + "[" + i.ToString("0000") + "].pdf");
                ListBoxPages.Items.Add(i);
                split.AddPage(currPage);
                split.Close();
            }

        }

        private void ListBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = (int)ListBoxPages.SelectedItem;
            PdfViewer.Url = new Uri(addPdfDialog.FileName.Substring(0, addPdfDialog.FileName.Length - 4) + "[" + i.ToString("0000") + "].pdf" + "#toolbar=0&navpanes=0&scrollbar=1&view=FitW");

        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint iep = new IPEndPoint(ipAddress, 8080);
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(iep);
        }

        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            sock.Send(Encoding.ASCII.GetBytes("BYE"));
            sock.Close();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            sock.Send(Encoding.ASCII.GetBytes(TextBoxRemoteCmd.Text));
        }

        private void ButtonStopServer_Click(object sender, EventArgs e)
        {
            sock.Send(Encoding.ASCII.GetBytes("STOPSERVER"));
            ButtonConnect_Click(null, null); // Force le serveur à accepter une dernière connexion pour prendre en compte l'état "arrêté"
            sock.Close();
        }
    }
}
