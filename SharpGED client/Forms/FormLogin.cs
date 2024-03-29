﻿using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SharpGED_client
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            int serverPort;

            try
            {
                Cursor = Cursors.WaitCursor;
                if (int.TryParse(textBoxPort.Text, out serverPort))
                {
                    Program.ServerConnect(textBoxServer.Text, serverPort);
                }
                else
                {
                    MessageBox.Show("Le numéro de port saisi est incorrect.", "Impossible de se connecter au serveur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

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

            // Sauvegarde des informations saisies
            Properties.Settings.Default.ServerIP = textBoxServer.Text;
            Properties.Settings.Default.ServerPort = serverPort;
            Properties.Settings.Default.User = textBoxUser.Text;
            Properties.Settings.Default.Save();

            new formMain().Show();
            Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = "v" + Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);
            textBoxServer.Text = Properties.Settings.Default.ServerIP;
            textBoxPort.Text = Properties.Settings.Default.ServerPort.ToString();
            textBoxUser.Text = Properties.Settings.Default.User;
        }
    }
}
