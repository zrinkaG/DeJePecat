using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeJePecat
{
    public partial class MakeJson : Form
    {
        string _jsonFolder;

        public MakeJson()
        {
            InitializeComponent();
        }

        private void btnMakeJson_Click(object sender, EventArgs e)
         {
            
                Utility.MakeJson(txtSourcePath.Text);
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _jsonFolder = ofd.SelectedPath;
                txtSourcePath.Text = _jsonFolder;
            }
        }
    }
}
