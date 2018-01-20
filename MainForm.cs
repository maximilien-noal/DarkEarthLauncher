using DarkEarthLauncher.Hook;
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

        private System.Windows.Forms.Timer _exitTimer = new Timer();

        private Process _hookedProc;

        public MainForm()
        {
            InitializeComponent();
            Application.ApplicationExit += OnApplicationExit;
            DeactivateDdrawCompatCheckBox.Checked = Properties.Settings.Default.IsDdrawCompatDisabled;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsDdrawCompatDisabled = DeactivateDdrawCompatCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeactivateDdrawCompatCheckBox.Checked)
                {
                    if(File.Exists(Path.Combine(_workDir, "ddraw.dll")))
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

            Properties.Settings.Default.Save();

            try
            {
                _hookedProc = HookLauncher.Run("dkev.exe");

                this.Visible = false;

                _exitTimer.Tick += _exitTimer_Tick;
                _exitTimer.Interval = 500;
                _exitTimer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0} : {1}{2}", ex.Message, Environment.NewLine, ex.StackTrace));
            }
        }

        private void _exitTimer_Tick(object sender, EventArgs e)
        {
            _hookedProc.Refresh();
            if (_hookedProc.HasExited)
            {
                Application.Exit();
            }
        }
    }
}
