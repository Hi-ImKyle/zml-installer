using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                    taskDialog.Content = "You need to be on the Moddable version. Here are the steps.\n\nOpen Steam.\nRight Click on CarX in your Library\nProperties at the bottom\nBetas on the left\nBeta participation, select \"moddable\"\n\nYou will need to wait for the game to update to the moddable version to try installing ZML again.";
                    taskDialog.Buttons.Add(new TaskDialogButton("Help!"));
                    taskDialog.Buttons.Add(new TaskDialogButton("Retry"));
                    taskDialog.Buttons.Add(new TaskDialogButton(ButtonType.Cancel));
                    var result = taskDialog.ShowDialog();
                    if(result.Text == "Help!")
                    {
                        Process.Start("https://zi9.github.io/zml/media/how2moddableplshelp.gif");
                    }else if (result.Text == "Retry")
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
            ZMLBundleData = await webClient.DownloadDataTaskAsync("https://zi9.github.io/zml/versions/LIVE/Bundle.zip");
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

            var kinoFile = Path.Combine(GameDir, "kino.ini");
            var knBaseFolder = Path.Combine(GameDir, "kino", "mods", "KN_Base");
            if (!File.Exists(kinoFile) && !Directory.Exists(knBaseFolder))
                return;
            var migrateDialog = MessageBox.Show("ZML detected that you have KSL/Kino installed. Would you like to migrate your Kino data to ZML?\n\nIf KSL/Kino was detected and you don't have it, just press No.", "Migrate KSL/Kino", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (migrateDialog != DialogResult.Yes)
                return;
            try
            {
                MigrateKino();
                MessageBox.Show("Kino data migrated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show("Failed to migrate Kino data. Please do it manually.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MigrateKino()
        {
            var kinoIni = Path.Combine(GameDir, "kino.ini");
            var kinoFolder = Path.Combine(GameDir, "kino");
            var knBaseFolder = Path.Combine(kinoFolder, "mods", "KN_Base");
            var zmlFolder = Path.Combine(GameDir, "ZML", "mods");

            File.Move(kinoIni, Path.Combine(GameDir, "kino-migrated.ini"));
            Directory.Move(knBaseFolder, Path.Combine(zmlFolder, "KN_Base"));
            Directory.Move(kinoFolder, Path.Combine(GameDir, "kino-migrated"));
        }

        private void UninstallZMLButton_Click(object sender, EventArgs e)
        {
            var folderBrowser = new VistaFolderBrowserDialog();
            folderBrowser.Description = "Select your CarX Folder";
            folderBrowser.UseDescriptionForTitle = true;

            var result = folderBrowser.ShowDialog();
            if (result != DialogResult.OK)
            {
                MessageBox.Show("Uninstall Cancelled", "Uninstall ZML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var gameDir = folderBrowser.SelectedPath;
            var gameExe = Path.Combine(gameDir, "Drift Racing Online.exe");

            if(!File.Exists(gameExe))
            {
                MessageBox.Show("Invalid CarX Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirmUninstall = MessageBox.Show("Do you want to uninstall ZML?", "Uninstall ZML", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmUninstall == DialogResult.Yes)
            {
                var winHttpDll = Path.Combine(gameDir, "winhttp.dll");
                File.Delete(winHttpDll);

                var deleteData = MessageBox.Show("Do you want to delete all ZML data? (mods, settings, etc)", "Uninstall ZML", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (deleteData == DialogResult.Yes)
                {
                    var zmlFolder = Path.Combine(gameDir, "ZML");
                    Directory.Delete(zmlFolder, true);
                }
                MessageBox.Show("ZML Uninstalled", "Uninstall ZML", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
