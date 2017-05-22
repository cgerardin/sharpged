using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SharpGED_controls
{
    public partial class OfficeViewer: UserControl
    {
        private string uri;

        [Category("Configuration"), Browsable(true), Description("URI du fichier à afficher")]
        public String URI
        {
            get
            {
                return uri;
            }
            set
            {
                uri = value;
            }
        }



        public OfficeViewer()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            Process.Start(uri);
        }
    }
}
