using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BN_Primitive_Launcher
{
	public partial class Form1 : Form
	{
		string this_launcher = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
		List<string> preferences;
		static string bn_archiveName = "";
		static string rootdir = "";
		static bool availability = true;
		static int total_bytes = 0;
		public Form1()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			InitializeComponent();
		}
        public List<string> GetUserPreferences()
		{
			List<string> preferences = new List<string>();

			if (saveBox.Checked)      { preferences.Add("save"); }
			if (ModsBox.Checked)      { preferences.Add("mods"); } //// переводить в ловеркейс
			if (soundBox.Checked)     { preferences.Add("sound"); }
			if (fontBox.Checked)      { preferences.Add("font"); }
			if (configBox.Checked)    { preferences.Add("config"); }
			if (templatesBox.Checked) { preferences.Add("templates"); }
			if (memorialBox.Checked)  { preferences.Add("memorial"); }
			if (graveyardBox.Checked) { preferences.Add("graveyard"); }

			return preferences;
		}
		public void GameDownload(string version)
		{
			string url = @"https://github.com/cataclysmbnteam/Cataclysm-BN/releases";
			using (var client = new WebClient())
			{
				client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				Regex rx = new Regex(@"\/cataclysmbnteam\/Cataclysm-BN\/releases\/download\/\d{0,99}\/\S{0,99}" + version + ".zip", RegexOptions.Compiled);
				string githubPage = client.DownloadString(url);
				MatchCollection matches = rx.Matches(githubPage);

				WebClient wc = new WebClient();
				while (total_bytes == 0)
				{
					wc.OpenRead(@"https://github.com/" + matches[0]);
					total_bytes = Convert.ToInt32(wc.ResponseHeaders["Content-Length"]);
				}

				bn_archiveName = matches[0].ToString().Split('/').Last();
				client.DownloadFileAsync(new Uri(@"https://github.com/" + matches[0]), matches[0].ToString().Split('/').Last());
				while(progressBar1.Visible) { ; }
			}
		}
		public void KenanDownload()
        {
			string url = @"https://github.com/Kenan2000/CDDA-Kenan-Modpack/archive/refs/heads/master.zip";

			WebClient wc = new WebClient();
			while (total_bytes == 0)
			{
				wc.OpenRead(url);
				total_bytes = Convert.ToInt32(wc.ResponseHeaders["Content-Length"]);
			}

			using (var client = new WebClient())
			{
				client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				bn_archiveName = "Kenan.zip";
				client.DownloadFileAsync(new Uri(url), bn_archiveName);
				while (progressBar1.Visible) { ; }
			}
		}
		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			double bytesIn = double.Parse(e.BytesReceived.ToString());
			double percentage = bytesIn / total_bytes * 100;
			this.BeginInvoke((MethodInvoker)delegate { progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString()); });
		}
		async void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.BeginInvoke((MethodInvoker)delegate { progressBar1.Value = 0; });
			IProgress<int> zip_progressSetMax = new Progress<int>(value =>
			{
				this.BeginInvoke((MethodInvoker)delegate { progressBar1.Maximum = value; });
			});
			IProgress<int> zip_progress = new Progress<int>	( value => 
			{
				this.BeginInvoke((MethodInvoker)delegate { progressBar1.Value += value; });
			});
			await Task.Run( () => ExtractAndUpdate( zip_progress, zip_progressSetMax ) );
			this.BeginInvoke((MethodInvoker)delegate { progressBar1.Value = 0; });
			this.BeginInvoke((MethodInvoker)delegate { progressBar1.Visible = false; });
		}
		public void ExtractAndUpdate(IProgress<int> progress, IProgress<int> progressSetMax)
		{
			bool error = false;
			ZipArchive zipArchive = ZipFile.OpenRead(Directory.GetCurrentDirectory() + "\\" + bn_archiveName);
			int ammountF = zipArchive.Entries.Count();
			progressSetMax.Report(ammountF);
			try
			{
				foreach (ZipArchiveEntry entry in zipArchive.Entries)
				{
					progress.Report(1);

					string endname = entry.FullName;
					//if (endname.Contains('/')) { endname = endname.Replace('/', '\\'); }

					string completeFileName = Path.GetFullPath(rootdir + "\\" + endname);
					if (entry.Name == "")
					{
						Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
						continue;
					}

					try	{ entry.ExtractToFile(completeFileName, true); }
					catch { continue; }
				}
			}
			catch(System.UnauthorizedAccessException)
			{
				error = true;
				MessageBox.Show($"{rootdir}\nAccess denied. Run as administrator");
			}
			catch(Exception e)
			{
				error = true;
				MessageBox.Show($"Unexpected error\n{e.Message}\n{e.TargetSite}");
			}
			zipArchive.Dispose();
			File.Delete(Directory.GetCurrentDirectory() + "\\" + bn_archiveName);
			if (error == true) { Application.Exit(); }

			MoveToRoot();
		}
		public void MoveFromRoot(IProgress<sbyte> progress)
		{
			bool toBackup = backupBox.Checked;

			string oldData = rootdir + "\\BN - old data";
			var folders = Directory.GetDirectories(rootdir);
			var files = Directory.GetFiles(rootdir);

			string ExecutablePath = Environment.CurrentDirectory;
			if (ExecutablePath.IndexOf(rootdir) == 0 && ExecutablePath != rootdir)
            {
				Directory.SetCurrentDirectory(rootdir);
				File.Move(ExecutablePath + $"\\{this_launcher}", rootdir + $"\\{this_launcher}");
            }

			if (Directory.Exists(oldData)) 
			{ 
				Directory.Delete(oldData, true); 
			}

			if (folders.Count() != 0)
			{
				Directory.CreateDirectory(oldData);
				foreach (var folder in folders)
				{
					if (!folder.EndsWith("BN - old data") && !folder.EndsWith("en"))
					{
						Directory.Move(folder, oldData + $"\\{folder.Split('\\').Last()}");
					}
				}
			}

			if (files.Count() != 0)
			{
				Directory.CreateDirectory(oldData);
				foreach (var file in files)
				{
					if (!file.EndsWith(this_launcher))
					{
						File.Move(file, oldData + $"\\{file.Split('\\').Last()}");
					}
				}
			}

			progress.Report(1);
			if (toBackup && Directory.Exists(oldData))
			{
				ZipFile.CreateFromDirectory(oldData, rootdir + "\\BN - backup.zip", CompressionLevel.Fastest, true);
			}
			progress.Report(0);
		}
		public void MoveToRoot()
		{
			string oldData = rootdir + "\\BN - old data";

			if (Directory.Exists(oldData))
			{
				var folders = Directory.GetDirectories(oldData);
				var files = Directory.GetFiles(oldData);

				if (folders.Count() != 0)
				{
					foreach (var folder in folders)
					{
						string pfolder = folder.Split('\\').Last().ToLower();
						if (preferences.Contains(pfolder))
						{
							Directory.Move(folder, rootdir + $"\\{folder.Split('\\').Last()}");
						}
					}
				}
				if (preferences.Contains("sound"))
				{
					if (Directory.Exists(oldData + "\\data\\sound"))
					{
						var sounds = Directory.GetDirectories(oldData + "\\data\\sound");
						if (folders.Count() != 0)
						{
							foreach (var sound in sounds)
							{
								if (sound.Split('\\').Last() != "Basic") { Directory.Move(sound, rootdir + $"\\data\\sound\\{sound.Split('\\').Last()}"); }
							}
						}
					}
				}
			}

			string KenanPath = rootdir + @"\CDDA-Kenan-Modpack-master\Kenan-Modpack";
			if (Properties.Settings.Default.KenanState && Directory.Exists(KenanPath))
            {
				var folders = Directory.GetDirectories(KenanPath);
				if (folders.Count() != 0)
				{
					foreach (var folder in folders)
					{
						try
						{
							Directory.Move(folder, rootdir + $"\\data\\mods\\{folder.Split('\\').Last()}");
                        }
                        catch(IOException)
                        {
							// Необходимо перемещать с заменой, а не просто удалять и перемещать.
							Directory.Delete(rootdir + $"\\data\\mods\\{folder.Split('\\').Last()}", true);
							Directory.Move(folder, rootdir + $"\\data\\mods\\{folder.Split('\\').Last()}");
						}
					}
				}
				Directory.Delete(rootdir + @"\CDDA-Kenan-Modpack-master", true);
			}
		}
		public void MoveWithReplacement(string startdir, string destdir)
        {

        }
		private void button1_Click(object sender, EventArgs e)
		{
			var dlg = new FolderPicker();
			dlg.InputPath = Directory.GetCurrentDirectory();
			if (dlg.ShowDialog(IntPtr.Zero) == true)
			{
				textBox1.Text = dlg.ResultPath;
				textBox1.Enabled = false;
			}
		}
		private async void button2_Click(object sender, EventArgs e)
		{
            if (availability == false) { MessageBox.Show("Game is currently updating..."); return; }
			if (comboBox1.Text == "") { MessageBox.Show("Game version not selected"); return; }
			if (label3.Visible == true) { label3.Visible = false; }
			availability = false;
			textBox1.Enabled = false;
			rootdir = textBox1.Text;

			if (!System.IO.Directory.Exists(rootdir))
			{
				try
				{
					Directory.CreateDirectory(rootdir);
				}
				catch
				{
					MessageBox.Show("Enter the correct path to the root folder");
					availability = true;
					return;
				}
			}

			bool error = false;
			IProgress<sbyte> progress = new Progress<sbyte>(value =>
			{
				if      (value ==  1) { label4.Visible = true; } 
				else if (value ==  0) { label4.Visible = false; } 
				else if (value == -1)
				{
					availability = true;
					error = true; 
				}
			});
			await Task.Run(() => MoveFromRoot(progress));
			if (error) { return; }

			progressBar1.Visible = true;
			string version = String.Join("-", comboBox1.Text.Split('-').Skip(1));
			await Task.Run( () => GameDownload(version) );

			progressBar1.Visible = true;
			if (Properties.Settings.Default.KenanState) { await Task.Run( () => KenanDownload() ); }

			availability = true;
			label3.Visible = true;
		}
		private void button3_Click(object sender, EventArgs e)
		{
			string game_path = textBox1.Text + "\\cataclysm -tiles.exe";
			if (File.Exists(game_path) && textBox1.Text != "")
            {
				var previous_directory = Directory.GetCurrentDirectory();
				Directory.SetCurrentDirectory(textBox1.Text);
				System.Diagnostics.Process.Start(game_path);
				Directory.SetCurrentDirectory(previous_directory);
				Application.Exit();
			}
            else
            {
				MessageBox.Show("The game executable was not found in the root folder, or it has been renamed");
            }
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && textBox1.Enabled == true) 
			{ 
				textBox1.Enabled = false; 
			}
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			if (textBox1.Bounds.Contains(e.Location) && availability == true)
			{
				if (textBox1.Enabled == false) 
				{ 
					textBox1.Enabled = true;
					textBox1.SelectAll();
					textBox1.Focus();
				}
			}
		}

		private void statusStrip1_Click(object sender, EventArgs e)
		{
			if (Size.Height != MaximumSize.Height) { Size = MaximumSize; }
			else { Size = MinimumSize; }
		}
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

        private void Form1_Load(object sender, EventArgs e)
        {
			preferences = GetUserPreferences();
			statusStrip1.Cursor = Cursors.Hand;
			if (textBox1.Text != "") { textBox1.Enabled = false; }
        }
    }
}
