using System;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            Program.ServerConnect(TextBoxServer.Text, int.Parse(TextBoxPort.Text));
            new MainForm().Show();
            Hide();
        }

    }
}
