using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZMLInstaller
{
    public partial class InstallerForm : Form
    {
        public InstallerForm()
        {
            InitializeComponent();
        }

        private string GameDir;
        private byte[] ZMLBundleData;

        private void OpenDirButton_Click(object sender, EventArgs e)
        {
            var folderBrowser = new VistaFolderBrowserDialog();
            folderBrowser.Description = "Select your CarX Folder";
            folderBrowser.UseDescriptionForTitle = true;

            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                CheckSelectedPath(folderBrowser.SelectedPath);
            }
        }

        private void CheckSelectedPath(string path)
        {
            var exePath = Path.Combine(path, "Drift Racing Online.exe");
            var gameAssemblyPath = Path.Combine(path, "GameAssembly.dll");
            if (File.Exists(exePath))
            {
                if (File.Exists(gameAssemblyPath))
                {
                    var taskDialog = new TaskDialog();
                    taskDialog.WindowTitle = "ZML Installer";
                    taskDialog.MainIcon = TaskDialogIcon.Warning;
                    taskDialog.MainInstruction = "You appear to be on the LIVE version of the game";
                    taskDialog.Content = "You need to be on the Moddable version. Here are the steps.\n\nOpen Steam.\nRight Click on CarX in your Library\nProperties\nBetas\nBeta participation, select \"moddable\"\n\nYou will need to wait for the game to update to the moddable version to try installing ZML again.";
                    taskDialog.Buttons.Add(new TaskDialogButton("Retry"));
                    taskDialog.Buttons.Add(new TaskDialogButton(ButtonType.Cancel));
                    var result = taskDialog.ShowDialog();
                    if (result.Text == "Retry")
                    {
                       CheckSelectedPath(path);
                    }
                    return;
                }
                GameDir = path;
                EnableStep2();
            }
            else
            {
                MessageBox.Show("Invalid CarX Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Step2DownloadButton_Button(object sender, EventArgs e)
        {
            this.Enabled = false;
            var webClient = new System.Net.WebClient();
            webClient.DownloadProgressChanged += (s, pe) =>
            {
                Step2DownloadProgress.Value = pe.ProgressPercentage;
            };
            ZMLBundleData = await webClient.DownloadDataTaskAsync("https://cdn.discordapp.com/attachments/938577547514499152/1174746809831276684/ZML_Bundle_11-16.zip?ex=6596dbb9&is=658466b9&hm=49137a7696e649618db51b8a9bb7f54ec7955f0b50245a42a0afa68d15e4df76&");
            this.Enabled = true;
            EnableStep3();
        }

        public void EnableStep2()
        {
            Step2Label.Enabled = true;
            Step2DownloadButton.Enabled = true;
            Step2DownloadProgress.Value = 0;
            Step2DownloadProgress.Enabled = true;
        }

        public void EnableStep3()
        {
            Step3Label.Enabled = true;
            Step3InstallButton.Enabled = true;
        }

        private void Step3InstallButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var zipFile = new ZipArchive(new MemoryStream(ZMLBundleData), ZipArchiveMode.Read);
            var firstFolder = zipFile.Entries.First().FullName;
            var entries = zipFile.Entries.Where(x => !string.IsNullOrWhiteSpace(x.FullName.Replace(firstFolder, ""))).ToList();
            entries.ForEach(x =>
            {
                var path = Path.Combine(GameDir, x.FullName.Replace(firstFolder, ""));
                if (x.FullName.EndsWith("/"))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    x.ExtractToFile(path, true);
                }
            });
            MessageBox.Show("ZML Installed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Enabled = true;
        }
    }
}
