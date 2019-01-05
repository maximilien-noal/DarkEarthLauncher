using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DarkEarthLauncher
{
    public partial class MainForm : Form
    {
        private string _workDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public MainForm()
        {
            InitializeComponent();
            Application.ApplicationExit += OnApplicationExit;
            DisableDdrawCompatCheckBox.Checked = Properties.Settings.Default.IsDdrawCompatDisabled;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsDdrawCompatDisabled = DisableDdrawCompatCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            EnableOrDisableDDrawCompat();

            Properties.Settings.Default.Save();

            try
            {
                Process.Start(Path.Combine(_workDir, "DKEV.EXE"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0} : {1}{2}", ex.Message, Environment.NewLine, ex.StackTrace));
            }
        }

        private void EnableOrDisableDDrawCompat()
        {
            try
            {
                if (DisableDdrawCompatCheckBox.Checked)
                {
                    if (File.Exists(Path.Combine(_workDir, "ddraw.dll")))
                    {
                        File.Move(Path.Combine(_workDir, "ddraw.dll"), Path.Combine(_workDir, "ddrawDisabled.dll"));
                    }
                }
                else
                {
                    if (File.Exists(Path.Combine(_workDir, "ddrawDisabled.dll")))
                    {
                        File.Move(Path.Combine(_workDir, "ddrawDisabled.dll"), Path.Combine(_workDir, "ddraw.dll"));
                    }
                }
            }
            catch
            {

            }
        }
        
        private void SeeDefaultControlsButton_Click(object sender, EventArgs e)
        {
            new ControlsForm().ShowDialog();
        }

        private void GameHelpButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(_workDir, "Dark_f.chm"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0} : {1}{2}", ex.Message, Environment.NewLine, ex.StackTrace));
            }
        }
    }
}
