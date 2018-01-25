using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeJePecat
{
    public partial class Form1 : Form
    {
        #region Fields
        private string _sourceFolder;
        private string _destFolder;

        HoughAlgorithm _hughesAlgorithm;
        MatchingTemplateAlgorithm _matchingTemplateAlgorithm;
        CustomAlgorithm _customAlgoritm;

        long _hughesDuration;
        long _matchingTemplateDuration;
        long _customDuration;
        #endregion

        #region Properties
        public string SourceFolder
        {
            get
            {
                if(String.IsNullOrEmpty(_sourceFolder))
                {
                    MessageBox.Show("Source folder cannot be empty!");
                    return String.Empty;
                }
                return _sourceFolder;
            }
            set
            {
                _sourceFolder = value;
            }
        }
        public string DestinationFolder
        {
            get
            {
                if (String.IsNullOrEmpty(_destFolder))
                {
                    MessageBox.Show("Destination folder cannot be empty!");
                    return String.Empty;
                }
                return _destFolder;
            }
            set
            {
                _destFolder = value;
            }
        }
        public long CustomDuration
        {
            get
            {
                return _customDuration;
            }

            set
            {
                _customDuration = value;
            }
        }

        public long MatchingTemplateDuration
        {
            get
            {
                return _matchingTemplateDuration;
            }

            set
            {
                _matchingTemplateDuration = value;
            }
        }

        public long HughesDuration
        {
            get
            {
                return _hughesDuration;
            }

            set
            {
                _hughesDuration = value;
            }
        }


        #endregion

        #region Constructor & Init
        public Form1()
        {
            InitializeComponent();

            _hughesAlgorithm = new HoughAlgorithm();
            _matchingTemplateAlgorithm = new MatchingTemplateAlgorithm();
            _customAlgoritm = new CustomAlgorithm();

            txtSourcePath.Text = @"C:\Users\zmarkoc\Desktop\SOURCE";
            SourceFolder = @"C:\Users\zmarkoc\Desktop\SOURCE";
            txtDestPath.Text = @"C:\Users\zmarkoc\Desktop\CUTDEST";
            DestinationFolder = @"C:\Users\zmarkoc\Desktop\CUTDEST"; ;
        }

        #endregion

        #region Events

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if( fbd.ShowDialog() == DialogResult.OK)
            {
                SourceFolder = fbd.SelectedPath;
                txtSourcePath.Text = SourceFolder;
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                DestinationFolder = fbd.SelectedPath;
                txtDestPath.Text = DestinationFolder;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartLocating();
        }


        #endregion

        #region Methods
        private void StartLocating()
        {
            string[] sourceImageFilePaths = Utility.GetImageFilePaths(SourceFolder);


            if (!(chbHughes.Checked || chbPGAlgorithm.Checked || chbMatchingTemplate.Checked))
            {
                MessageBox.Show("No algorithm is selected!");
                return;
            }


            Stopwatch sw = new Stopwatch();
            Cursor.Current = Cursors.WaitCursor;

            sw.Start();
            if (chbHughes.Checked)
            {
                sw.Restart();
                var hughesStamps = _hughesAlgorithm.Start(sourceImageFilePaths, DestinationFolder);
                HughesDuration = sw.ElapsedMilliseconds;

                if (chbCreateCompFiles.Checked)
                {
                    CreateCompFiles(HughesDuration, hughesStamps, "Hughes algorithm");
                }

            }

            if (chbMatchingTemplate.Checked)
            {
                sw.Restart();
                var matchingTemplateStamps = _matchingTemplateAlgorithm.Start(sourceImageFilePaths, DestinationFolder);
                MatchingTemplateDuration = sw.ElapsedMilliseconds;

                if (chbCreateCompFiles.Checked)
                {
                    CreateCompFiles(MatchingTemplateDuration, matchingTemplateStamps, "Matching template algorithm");
                }
            }

            if (chbPGAlgorithm.Checked)
            {
                sw.Restart();
               var customTemplateStamps =  _customAlgoritm.Start(sourceImageFilePaths, DestinationFolder);
                CustomDuration = sw.ElapsedMilliseconds;

                if (chbCreateCompFiles.Checked)
                {
                    CreateCompFiles(CustomDuration, customTemplateStamps, "Custom algorithm");
                }
            }


            sw.Stop();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Stamps are located!");
        }

        private void CreateCompFiles(long duration, List<Stamp> stamps, string algorithmName)
        {
            Utility.Serialize(stamps, DestinationFolder, Guid.NewGuid().ToString(), algorithmName, duration);
        }

        #endregion
    }
}
