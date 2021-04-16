﻿using System;
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
using BN_Primitive_Launcher.Classes;

namespace BN_Primitive_Launcher
{
	public partial class Form1 : Form
	{
		string this_launcher = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
		List<string> preferences;
		static string bn_archiveName = "";
		static string rootdir = "";
		static bool availability = true;
		static Dictionary<string, string> soundpacks = new Dictionary<string, string> 
		{
			{ "Otopack soundpack", @"https://github.com/Kenan2000/Otopack-Mods-Updates/archive/refs/heads/master.zip" },
			{ "@'s soundpack",     @"https://github.com/damalsk/damalsksoundpack/archive/refs/heads/master.zip" },
			{ "CO.AG", @"https://github.com/4nonch/CO.AG-copy/archive/refs/heads/main.zip" }
		};
		static string listbox_selected = "";
		static string musicname = "";
		public Form1()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
			InitializeComponent();
		}
        public void GetUserPreferences()
		{
			tbPathInput.Text = Properties.Settings.Default.TextboxState;
			cbVerionBox.Text = Properties.Settings.Default.GameState;
			saveBox.Checked = Properties.Settings.Default.savesBoxState;
			soundBox.Checked = Properties.Settings.Default.soundBoxState;
			ModsBox.Checked = Properties.Settings.Default.ModBoxState;
			fontBox.Checked = Properties.Settings.Default.fontBoxState;
			configBox.Checked = Properties.Settings.Default.configBoxState;
			templatesBox.Checked = Properties.Settings.Default.templatesBoxState;
			memorialBox.Checked = Properties.Settings.Default.memorialBoxState;
			graveyardBox.Checked = Properties.Settings.Default.graveyardBoxState;
			backupBox.Checked = Properties.Settings.Default.backupBoxState;
			kenanBox.Checked = Properties.Settings.Default.KenanState;
		}
		public List<string> SetUserPreferences()
        {
			List<string> preferences = new List<string>();
			if (saveBox.Checked) { preferences.Add("save"); }
			if (ModsBox.Checked) { preferences.Add("mods"); } //// переводить в ловеркейс
			if (soundBox.Checked) { preferences.Add("sound"); }
			if (fontBox.Checked) { preferences.Add("font"); }
			if (configBox.Checked) { preferences.Add("config"); }
			if (templatesBox.Checked) { preferences.Add("templates"); }
			if (memorialBox.Checked) { preferences.Add("memorial"); }
			if (graveyardBox.Checked) { preferences.Add("graveyard"); }

			return preferences;
		}
		public void GameDownload(string version)
		{
			string url = @"https://github.com/cataclysmbnteam/Cataclysm-BN/releases";

			this.Invoke((MethodInvoker)delegate { flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				Regex rx = new Regex(@"\/cataclysmbnteam\/Cataclysm-BN\/releases\/download\/\d{0,99}\/\S{0,99}" + version + ".zip", RegexOptions.Compiled);
				string githubPage = client.DownloadString(url);
				MatchCollection matches = rx.Matches(githubPage);

				bn_archiveName = matches[0].ToString().Split('/').Last();
				client.DownloadFileAsync(new Uri(@"https://github.com/" + matches[0]), matches[0].ToString().Split('/').Last());
				while(flagLabel.Visible) { ; }
			}
		}
		public void KenanDownload()
        {
			string url = @"https://github.com/Kenan2000/Bright-Nights-Kenan-Mod-Pack/archive/refs/heads/master.zip";

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				bn_archiveName = "Kenan.zip";
				client.DownloadFileAsync(new Uri(url), bn_archiveName);
				while (flagLabel.Visible) { ; }
			}
		}
		public void UndeadpeopleDownload()
        {
			string url = @"https://github.com/SomeDeadGuy/UndeadPeopleTileset/archive/refs/heads/master.zip";

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				bn_archiveName = "UPT.zip";
				client.DownloadFileAsync(new Uri(url), bn_archiveName);
				while (flagLabel.Visible) { ; }
			}
		}
		public void SoundpackDownload()
        {
			foreach (var item in checkedListBox1.CheckedItems)
			{
				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });
				if (listbox_selected != (string)item || !Directory.Exists(rootdir + $"\\data\\sound\\{(string)item}"))
				{
					using (var client = new WebClient())
					{
						//this.BeginInvoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });
						client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
						client.Headers.Add("user-agent", "Anything");
						//MessageBox.Show((string)item + " 1 " + MessageBox.Show(bn_archiveName));
						bn_archiveName = $"{(string)item}.zip";
						client.DownloadFileAsync(new Uri(soundpacks[(string)item]), bn_archiveName);
						while (flagLabel.Visible) {; }
					}
				}
			}
		}
		public void MusicDownload()
		{
			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				bn_archiveName = $"{musicname}.zip";
				client.DownloadFileAsync(new Uri(soundpacks[musicname]), bn_archiveName);
				while (flagLabel.Visible) { ; }
			}
		}
		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			double bytesIn = double.Parse(e.BytesReceived.ToString());
			double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
			double percentage = bytesIn / totalBytes * 100;
			this.Invoke((MethodInvoker)delegate { progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());});
		}
		async void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Blocks; });
			this.Invoke((MethodInvoker)delegate { progressBar1.Value = 0; });
			IProgress<int> zip_progressSetMax = new Progress<int>(value =>
			{
				this.Invoke((MethodInvoker)delegate { progressBar1.Maximum = value; });
			});
			IProgress<int> zip_progress = new Progress<int>	( value => 
			{
				this.Invoke((MethodInvoker)delegate { progressBar1.Value += value; });
			});
			await Task.Run( () => ExtractAndUpdate( zip_progress, zip_progressSetMax ) );
			this.Invoke((MethodInvoker)delegate { progressBar1.Value = 0; });
		}
		public void ExtractAndUpdate(IProgress<int> progress, IProgress<int> progressSetMax)
		{
			bool error = false;
			bool is_first_time = true;
			string archive_name = "";
			//MessageBox.Show(bn_archiveName);
			ZipArchive zipArchive = ZipFile.OpenRead(Directory.GetCurrentDirectory() + "\\" + bn_archiveName);
			int ammountF = zipArchive.Entries.Count();
			progressSetMax.Report(ammountF);
			try
			{
				foreach (ZipArchiveEntry entry in zipArchive.Entries)
				{
					progress.Report(1);

					string endname = entry.FullName;
					if (is_first_time) { archive_name = Path.GetDirectoryName(endname); } else { is_first_time = false; }

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

			MoveToRoot(archive_name);
		}

		/// <summary>
		/// Перенос всего в bn-olddata
		/// </summary>
		/// <param name="progress"></param>
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
				string zipFileName = "BN - backup.zip"; //TODO Move to constants!
				string zipFileNameOldBackup = "BN - backup-old.zip"; //TODO Move to constants!
				string oldZipPath = Path.Combine(oldData, zipFileName);
				string oldZipPathBackup = Path.Combine(rootdir, zipFileNameOldBackup);
				if (File.Exists(oldZipPath))
					File.Move(oldZipPath, oldZipPathBackup);

				ZipFile.CreateFromDirectory(oldData, Path.Combine(rootdir, zipFileName), CompressionLevel.Fastest, true);

				if (File.Exists(oldZipPathBackup))
					File.Delete(oldZipPathBackup);
			}

			progress.Report(0);
		}
		public void MoveToRoot(string folder_name)
		{
			string oldData = rootdir + "\\BN - old data";

			if (Directory.Exists(oldData))
			{
				var folders = Directory.GetDirectories(oldData);

				if (folders.Count() != 0)
				{
					foreach (var folder in folders)
					{
						string pfolder = folder.Split('\\').Last().ToLower();
						if (preferences != null)
						{
							if (preferences.Contains(pfolder))
							{
								Directory.Move(folder, rootdir + $"\\{folder.Split('\\').Last()}");
							}
						}
					}
				}

				if (preferences != null)
				{
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
			}

			string KenanPath = rootdir + @"\Bright-Nights-Kenan-Mod-Pack-master\Kenan-BrightNights-Modpack";
			if (Properties.Settings.Default.KenanState && Directory.Exists(KenanPath))
            {
				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; });

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
							MoveWithReplacement(folder, rootdir + $"\\data\\mods\\{folder.Split('\\').Last()}");
						}
					}
				}

				Directory.Delete(rootdir + @"\Bright-Nights-Kenan-Mod-Pack-master", true);
				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Blocks; });
			}

			string UndeadPath = rootdir + @"\UndeadPeopleTileset-master\TILESETS";
			if (Directory.Exists(UndeadPath))
            {
				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; });

				if (Directory.Exists(rootdir + @"\Mods"))
                {
					foreach (var folder in Directory.GetDirectories(rootdir + @"\Mods"))
                    {
						if (folder.Split('\\').Last().Split('_').Contains("SDG") || folder.Split('\\').Last().Split('_').Contains("UnDeadPeople"))
                        {
							Directory.Delete(rootdir + $"\\Mods\\{folder.Split('\\').Last()}", true);
                        }
                    }
                }

				string[] folders;
				if (Properties.Settings.Default.KenanState)
				{
					
					folders = Directory.GetDirectories(UndeadPath);
					foreach (var folder in folders)
					{
						MoveWithReplacement(folder, rootdir + $"\\{folder.Split('\\').Last()}");
					}
				}
				else
				{
					folders = Directory.GetDirectories(UndeadPath + @"\gfx");
					foreach (var folder in folders)
					{
						try
						{
							Directory.Move(folder, rootdir + @"\gfx\" + folder.Split('\\').Last());
						}
						catch (IOException)
                        {
							Directory.Delete(rootdir + @"\gfx\" + folder.Split('\\').Last(), true);
							Directory.Move(folder, rootdir + @"\gfx\" + folder.Split('\\').Last());
						}
					}

					string[] paths = new string[] { rootdir + @"\UndeadPeopleTileset-master\GRAPHICAL_OVERMAP_MODS", rootdir + @"\UndeadPeopleTileset-master\TILESET_MODS" };
					for (int i = 0; i < 2; i++)
					{
						folders = Directory.GetDirectories(paths[i]);
						foreach (var folder in folders)
						{
							try
							{
								Directory.Move(folder, rootdir + $"\\{folder.Split('\\').Last()}");
							}
							catch (IOException)
							{
								MoveWithReplacement(folder, rootdir + $"\\{folder.Split('\\').Last()}");
							}
						}
					}
				}
				Directory.Delete(rootdir + @"\UndeadPeopleTileset-master", true);
			}

			foreach (var item in checkedListBox1.CheckedItems)
            {
				string[] splited_sound = soundpacks[(string)item].Split('/');
				string soundpath = rootdir + $"\\{splited_sound[Array.IndexOf(splited_sound, "archive") - 1] + "-master"}";

				if (Directory.Exists(soundpath))
                {
					string txtcheck = Directory.GetFiles(soundpath, "soundpack.txt", SearchOption.AllDirectories)[0];
					string sounddir = txtcheck.Substring(0, txtcheck.Length - @"\soundpack.txt".Length);
					try
					{
						Directory.Move(sounddir, rootdir + @"\data\sound\" + (string)item);
                    }
                    catch (IOException)
                    {
						Directory.Delete(rootdir + @"\data\sound\" + (string)item, true);
						Directory.Move(sounddir, rootdir + @"\data\sound\" + (string)item);
					}
                }

                if (Directory.Exists(soundpath)) { Directory.Delete(soundpath, true); }

                string[] splited_music = soundpacks[musicname].Split('/');
                string musicfolder = $"{splited_music[Array.IndexOf(splited_music, "archive") - 1]}";
				string musicpack;
				try
				{
					musicpack = Directory.GetDirectories(rootdir, $"{musicfolder.Split('\\').Last()}*")[0];
				}
				catch (IndexOutOfRangeException)
                {
					musicpack = null;
                }
                //// Надо будет (кажется теперь уже не надо) обязательно переделать folder name (при распаковке сабстринг
                //// сабстринг с длинной (рутдир + символ слеша), сплит по слешу, беру первый элемент - это и будет название папки)
                if (Directory.Exists(musicpack))
				{
					if (listbox_selected != "---")
					{
						string jsoncheck = Directory.GetFiles(musicpack, "musicset.json", SearchOption.AllDirectories)[0];
						string musicdir = jsoncheck.Substring(0, jsoncheck.Length - @"\musicset.json".Length);
						string sounddest = rootdir + $"\\data\\sound\\{listbox_selected}";
						if (Directory.Exists(sounddest + @"\music"))
                        {
							Directory.Delete(sounddest + @"\music", true);
							MoveWithReplacement(musicdir, sounddest);
                        }
                        else
                        {
							MoveWithReplacement(musicdir, sounddest);
						}
					}
				}
				if (Directory.Exists(musicpack)) { Directory.Delete(musicpack, true); }
            }
			this.Invoke((MethodInvoker)delegate { flagLabel.Visible = false; });
		}

		/// <summary>
		/// Заменить каталоги
		/// </summary>
		/// <param name="startdir">Источник</param>
		/// <param name="destdir">Приемник</param>
		public void MoveWithReplacement(string startdir, string destdir)
        {
			Utils.CopyDirectories(startdir, destdir);
		}
		private void btDirDialogOpen_Click(object sender, EventArgs e)
		{
			if (!availability) { return; }
			var dlg = new FolderPicker();
			dlg.InputPath = Directory.GetCurrentDirectory();
			if (dlg.ShowDialog(IntPtr.Zero) == true)
			{
				tbPathInput.Text = dlg.ResultPath;
				tbPathInput.Enabled = false;
				UpdateButtonCheck();
			}
		}
		private async void btUpdate_Click(object sender, EventArgs e)
		{
            if (availability == false) { MessageBox.Show("Game is currently updating..."); return; }
			if (cbVerionBox.Text == "") { MessageBox.Show("Game version not selected"); return; }
			if (label3.Visible == true) { label3.Visible = false; }
			availability = false;
			tbPathInput.Enabled = false;
			rootdir = tbPathInput.Text;
			listbox_selected = (string)listBox1.Items[listBox1.SelectedIndex];
			musicname = comboBox2.Text;

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

			preferences = SetUserPreferences();

			progressBar1.Visible = true;
			progressBar1.Style = ProgressBarStyle.Marquee;
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
			if (error) { progressBar1.Visible = false; progressBar1.Style = ProgressBarStyle.Blocks; return; }
			progressBar1.Style = ProgressBarStyle.Blocks;

			string version = String.Join("-", cbVerionBox.Text.Split('-').Skip(1));
			await Task.Run( () => GameDownload(version) );

			if (Properties.Settings.Default.KenanState) { await Task.Run( () => KenanDownload() ); }
			await Task.Run( () => UndeadpeopleDownload() );
			await Task.Run( () => SoundpackDownload() );
			if (listbox_selected != "---") { await Task.Run( () => MusicDownload() ); }
			await Task.Run( () => ClearOldDirectory(progress) );
			UpdateButtonCheck();
			progressBar1.Visible = false;
			availability = true;
			label3.Visible = true;
		}

		private void ClearOldDirectory(IProgress<sbyte> progress)
		{
			progress.Report(1);
			string oldDataDirName = "BN - old data"; //TODO move old directory name to constants
			string oldData =  Path.Combine(rootdir,oldDataDirName);
			if (Directory.Exists(oldData))
				Directory.Delete(oldData, true);

			progress.Report(0);
		}

		private void btPlay_Click(object sender, EventArgs e)
		{
			if (!availability) { return; }
			string game_path = tbPathInput.Text + "\\cataclysm-tiles.exe";
			if (File.Exists(game_path) && tbPathInput.Text != "")
            {
				var previous_directory = Directory.GetCurrentDirectory();
				Directory.SetCurrentDirectory(tbPathInput.Text);
				System.Diagnostics.Process.Start(game_path);
				Directory.SetCurrentDirectory(previous_directory);
				Application.Exit();
			}
            else
            {
				MessageBox.Show("The game executable was not found in the root folder, or it has been renamed");
            }
		}
		private async void btSPinstall_Click(object sender, EventArgs e)
		{
			if (availability == false) { MessageBox.Show("Soundpack installation..."); return; }
			UpdateButtonCheck();
			availability = false;
			rootdir = tbPathInput.Text;
			progressBar1.Visible = true;

			listbox_selected = (string)listBox1.Items[listBox1.SelectedIndex];
			musicname = comboBox2.Text;

			await Task.Run(() => SoundpackDownload());
			if ((string)listBox1.Items[listBox1.SelectedIndex] != "---") { await Task.Run(() => MusicDownload()); }

			progressBar1.Visible = false;
			availability = true;

		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbPathInput.Enabled == true) 
			{ 
				tbPathInput.Enabled = false;
				UpdateButtonCheck();
			}
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			flagLabel.Focus();
			if (tbPathInput.Bounds.Contains(e.Location) && availability == true)
			{
				if (tbPathInput.Enabled == false) 
				{ 
					tbPathInput.Enabled = true;
					tbPathInput.SelectAll();
					tbPathInput.Focus();
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
		public void UpdateButtonCheck()
        {
			string game_path = tbPathInput.Text + "\\cataclysm-tiles.exe";
			if (File.Exists(game_path) && tbPathInput.Text != "")
			{
				btUpdate.Text = "Update";
				btSPinstall.Enabled = true;
			}
			else
			{
				btUpdate.Text = "Install";
				btSPinstall.Enabled = false;
			}
		}
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
			if (e.NewValue == CheckState.Checked) 
			{ 
				listBox1.Items.Add(checkedListBox1.Items[e.Index]);
            }
            else
            {
				listBox1.Items.Remove(checkedListBox1.Items[e.Index]);
			}
			//MessageBox.Show($"{listBox1.SelectedIndex}");
        }
		private void Form1_Load(object sender, EventArgs e)
		{
			GetUserPreferences();
			statusStrip1.Cursor = Cursors.Hand;
			progressBar1.Minimum = 0;
			progressBar1.Maximum = 100;
			if (tbPathInput.Text != "") { tbPathInput.Enabled = false; }
			listBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			if (cbVerionBox.Text == "") { cbVerionBox.Text = "cataclysmbn-win64-tiles"; }
			UpdateButtonCheck();
			//progressBar1.Visible = true;
		}
    }
}
