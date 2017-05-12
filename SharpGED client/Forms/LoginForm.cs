using System;
using System.IO;
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
                Cursor = Cursors.WaitCursor;
                Program.ServerConnect(TextBoxServer.Text, int.Parse(TextBoxPort.Text));
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "Impossible de se connecter au serveur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            new MainForm().Show();
            Hide();
        }

    }
}
