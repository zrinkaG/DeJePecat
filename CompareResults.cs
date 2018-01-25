using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeJePecat
{
    public partial class CompareResults : Form
    {
        string _labeledFilePath = String.Empty;
        string _resultStampsPath = String.Empty;
        string _comparisonResultPath = String.Empty;
        public CompareResults()
        {
            InitializeComponent();
            _comparisonResultPath = "C:\\Users\\zmarkoc\\Desktop\\DEST";
        }

        private void btnBrowseLabeled_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _labeledFilePath = ofd.FileName;
                txtLabeledPath.Text = _labeledFilePath;
            }
        }

        private void btnBrowseResult_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                _resultStampsPath = ofd.FileName;
                txtResultStamps.Text = _resultStampsPath;
            }
        }

        private void btnBrowseComparison_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _comparisonResultPath = fbd.SelectedPath;
                txtComparisonResultPath.Text = _comparisonResultPath;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(_labeledFilePath) || String.IsNullOrEmpty(_resultStampsPath) || String.IsNullOrEmpty(_comparisonResultPath))
            {
                MessageBox.Show("Sve putanje moraju biti definirane");
                return;
            }

            MakeComparison();

        }

        private void MakeComparison()
        {
            var labeledStamps = Utility.Deserialize(_labeledFilePath);
            var resultsStamps = Utility.Deserialize(_resultStampsPath);
            string comparisonResultFilePath = Path.Combine(_comparisonResultPath, Guid.NewGuid().ToString() + ".json");

            Utility.CompareResults(labeledStamps, resultsStamps, _labeledFilePath, _resultStampsPath, comparisonResultFilePath);

            MessageBox.Show("Comparison successed! " + Environment.NewLine + "Result path: " + comparisonResultFilePath);

        }
    }
}
