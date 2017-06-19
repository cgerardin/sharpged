﻿using System;
using System.Windows.Forms;

namespace SharpGED_server
{
    public partial class FormConfiguration : Form
    {

        public FormConfiguration()
        {
            InitializeComponent();
        }

        private void FormConfiguration_Load(object sender, EventArgs e)
        {
            textBoxHost.Text = Program.configuration.values.listenIP;
            textBoxPort.Text = Program.configuration.values.listenPort.ToString();
            textBoxFolder.Text = Program.configuration.values.baseFolder;
            textBoxDatabase.Text = Program.configuration.values.database;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFolder.Text = folderBrowserDialog.SelectedPath + "\\";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Program.configuration.values.listenIP = textBoxHost.Text;
            Program.configuration.values.listenPort = int.Parse(textBoxPort.Text);
            Program.configuration.values.baseFolder = textBoxFolder.Text;
            Program.configuration.values.database = textBoxDatabase.Text;
            Program.configuration.Save();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}