using SharpGED_lib;
using System;
using System.Windows.Forms;

namespace SharpGED_client.Forms
{
    public partial class RenameForm : Form
    {

        public GedFile file { get; set; }

        public RenameForm()
        {
            InitializeComponent();
        }

        private void RenameForm_Load(object sender, EventArgs e)
        {
            TextBoxPdfName.Text = file.title;
        }

        private void RenameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    Close();
                    break;

                case Keys.Enter:
                    ButtonRename_Click(null, null);
                    break;
            }
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {
            Program.ServerRenameFile(file, TextBoxPdfName.Text);
            Close();
        }

    }
}
