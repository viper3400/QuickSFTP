using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace Jaxx.QuickSFTP
{
    public partial class Form1 : Form
    {
        SettingsProvider _settings;
        public Form1()
        {
            InitializeComponent();
            _settings = new SettingsProvider("Settings.ini");
            tbUsername.Text = _settings.DefaultUser;
            toolStripStatusLabel2.Text = $"Version {Assembly.GetEntryAssembly().GetName().Version}";
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (tbPassword.Text == "")
            {
                MessageBox.Show("Das Feld Passwort darf nicht leer sein!", "Bitte Passwort eingeben", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            openFileDialog1.Title = "Bitte Dateien für die Übertragung auswählen ...";
            openFileDialog1.FileName = "";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnUpload.Enabled = false;
                tbPassword.Enabled = false;
                toolStripStatusLabel1.Text = "Übertragung läuft.";
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripProgressBar1.MarqueeAnimationSpeed = 30;

                await Task.Run(() => Upload(openFileDialog1.FileNames.ToList(), _settings.RemotUploadPath));

                toolStripStatusLabel1.Text = "Bereit";
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                toolStripProgressBar1.MarqueeAnimationSpeed = 0;
                btnUpload.Enabled = true;
                tbPassword.Enabled = true;

                MessageBox.Show("Die Dateien wurden übertragen.", "Übertragung beendet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void Upload(List<string> Files, string RemoteUploadPath)
        {
            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = _settings.Server,
                    PortNumber = _settings.Port,
                    UserName = tbUsername.Text,
                    Password = tbPassword.Text,
                    SshHostKeyFingerprint = _settings.SSHFingerPrint
                };

                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    TransferOperationResult transferResult;
                    foreach (var file in Files)
                    {
                        transferResult = session.PutFiles(file, RemoteUploadPath, false, transferOptions);

                        // Throw on any error
                        transferResult.Check();

                        //// Print results
                        //foreach (TransferEventArgs transfer in transferResult.Transfers)
                        //{
                        //    MessageBox.Show($"Upload of {transfer.FileName} succeeded");
                        //}
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Es ist ein Problem aufgetreten", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            }

        }


    }
}
