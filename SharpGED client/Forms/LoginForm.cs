using System;
using System.Net.Sockets;
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
            try
            {
                Program.ServerConnect(TextBoxServer.Text, int.Parse(TextBoxPort.Text));
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            new MainForm().Show();
            Hide();
        }

    }
}
