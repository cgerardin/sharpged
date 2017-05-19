using SharpGED_lib;
using System;
using System.Windows.Forms;

namespace SharpGED_client.Forms
{
    public partial class InputForm : Form
    {

        public string title { get; set; }
        public string value { get; set; }

        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            Text = title;
            TextBoxInput.Text = value;
        }

        private void InputForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    Close();
                    break;

                case Keys.Enter:
                    ButtonValidate_Click(null, null);
                    break;
            }
        }

        private void ButtonValidate_Click(object sender, EventArgs e)
        {
            value = TextBoxInput.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
