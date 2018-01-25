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
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            (new Form1()).ShowDialog();
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            (new LabelResults()).ShowDialog();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            (new CompareResults()).ShowDialog();
        }

        private void btnMakeJson_Click(object sender, EventArgs e)
        {
            (new MakeJson()).ShowDialog();
        }
    }
}
