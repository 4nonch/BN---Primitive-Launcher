using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BN_Primitive_Launcher.Classes;

namespace BN_Primitive_Launcher
{
	public partial class Form1 : Form
	{
		public void SetSecurityProtocol()
        {
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
		}


		// Download managing
		public void GameDownload(string version)
		{
			this.Invoke((MethodInvoker)delegate { progressLabel.Text = "Downloading last game release..."; progressLabel.Visible = true; });

			string url = @"https://github.com/cataclysmbnteam/Cataclysm-BN/releases"; //log.Trace($"version = {version}");

			this.Invoke((MethodInvoker)delegate { flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				Regex rx = new Regex(@"\/cataclysmbnteam\/Cataclysm-BN\/releases\/download\/\d{0,99}\/\S{0,99}" + version + ".zip", RegexOptions.Compiled);
				string githubPage = client.DownloadString(url);
				MatchCollection matches = rx.Matches(githubPage);
				//MessageBox.Show($"{matches[8]}");
				downloaded_archive_name = matches[0].ToString().Split('/').Last();
				client.DownloadFileAsync(new Uri(@"https://github.com/" + matches[0]), matches[0].ToString().Split('/').Last());
				while (flagLabel.Visible) {; }
			}

			this.Invoke((MethodInvoker)delegate { progressLabel.Visible = false; });
		}

		public void KenanDownload()
		{
			this.Invoke((MethodInvoker)delegate { progressLabel.Text = "Downloading KenanModpack..."; progressLabel.Visible = true; });

			string url = @"https://github.com/Kenan2000/Bright-Nights-Kenan-Mod-Pack/archive/refs/heads/master.zip";

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				downloaded_archive_name = "Kenan.zip";
				client.DownloadFileAsync(new Uri(url), downloaded_archive_name);
				while (flagLabel.Visible) {; }
			}

			this.Invoke((MethodInvoker)delegate { progressLabel.Visible = false; });
		}

		public void UndeadpeopleDownload()
		{
			this.Invoke((MethodInvoker)delegate { progressLabel.Text = "Downloading Undeadpeople Tileset..."; progressLabel.Visible = true; });

			string url = @"https://github.com/SomeDeadGuy/UndeadPeopleTileset/archive/refs/heads/master.zip";

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				downloaded_archive_name = "UPT.zip";
				client.DownloadFileAsync(new Uri(url), downloaded_archive_name);
				while (flagLabel.Visible) {; }
			}

			this.Invoke((MethodInvoker)delegate { progressLabel.Visible = false; });
		}

		public void SoundpackDownload()
		{
			foreach (var item in SoundpackChecklistbox.CheckedItems)
			{
				this.Invoke((MethodInvoker)delegate { progressLabel.Text = $"Downloading {(string)item}..."; progressLabel.Visible = true; });
				//log.Trace($"soundpack = {(string)item}");
				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });
				if (SP_musicreplace != (string)item || !Directory.Exists(rootdir + $"\\data\\sound\\{(string)item}"))
				{
					using (var client = new WebClient())
					{
						client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
						client.Headers.Add("user-agent", "Anything");
						downloaded_archive_name = $"{(string)item}.zip";
						client.DownloadFileAsync(new Uri(soundpacks[(string)item]), downloaded_archive_name);
						while (flagLabel.Visible) {; }
					}
				}

				this.Invoke((MethodInvoker)delegate { progressLabel.Visible = false; });
			}
		}

		public void MusicDownload()
		{
			this.Invoke((MethodInvoker)delegate { progressLabel.Text = "Downloading musicpack..."; progressLabel.Visible = true; });

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });

			using (var client = new WebClient())
			{
				client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
				client.Headers.Add("user-agent", "Anything");
				downloaded_archive_name = $"{musicpack_name}.zip";
				client.DownloadFileAsync(new Uri(soundpacks[musicpack_name]), downloaded_archive_name);
				while (flagLabel.Visible) {; }
			}

			this.Invoke((MethodInvoker)delegate { progressLabel.Visible = false; });
		}

		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			double bytesIn = double.Parse(e.BytesReceived.ToString());
			double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
			double percentage = bytesIn / totalBytes * 100;
			this.Invoke((MethodInvoker)delegate { progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString()); });
		}

		async void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			//log.Trace($"{downloaded_archive_name} - download complete");

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Blocks; });
			this.Invoke((MethodInvoker)delegate { progressBar1.Value = 0; });
			IProgress<int> zip_progressSetMax = new Progress<int>(value =>
			{
				this.Invoke((MethodInvoker)delegate { progressBar1.Maximum = value; });
			});
			IProgress<int> zip_progress = new Progress<int>(value =>
			{
				this.Invoke((MethodInvoker)delegate { progressBar1.Value += value; });
			});
			await Task.Run(() => ExtractAndUpdate(zip_progress, zip_progressSetMax));
			this.Invoke((MethodInvoker)delegate { progressBar1.Value = 0; });
		}

		public void ExtractAndUpdate(IProgress<int> progress, IProgress<int> progressSetMax)
		{
			//log.Trace($"{downloaded_archive_name} - extraction begin");

			this.Invoke((MethodInvoker)delegate { progressLabel.Text = $"{downloaded_archive_name.Split('.')[0]} extracting..."; progressLabel.Visible = true; });

			bool error = false;
			ZipArchive zipArchive = ZipFile.OpenRead(Directory.GetCurrentDirectory() + "\\" + downloaded_archive_name);
			int ammountF = zipArchive.Entries.Count();
			progressSetMax.Report(ammountF);
			try
			{
				foreach (ZipArchiveEntry entry in zipArchive.Entries)
				{
					progress.Report(1);

					string endname = entry.FullName;

					string completeFileName = Path.GetFullPath(rootdir + "\\" + endname);
					if (entry.Name == "")
					{
						Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
						continue;
					}
					try { entry.ExtractToFile(completeFileName, true); }
					catch { continue; }
				}
			}
			catch (System.UnauthorizedAccessException)
			{
				error = true;
				MessageBox.Show($"{rootdir}\nAccess denied. Run as administrator");
			}
			catch (Exception e)
			{
				error = true;
				MessageBox.Show($"Unexpected error\n{e.Message}\n{e.TargetSite}");
			}
			zipArchive.Dispose();
			File.Delete(Directory.GetCurrentDirectory() + "\\" + downloaded_archive_name);
			if (error == true) { Application.Exit(); }

			MoveToRoot();

			this.Invoke((MethodInvoker)delegate { progressLabel.Visible = false; });
		}


		// Directories&Files managing (надо добавить 
		private void ClearOldDirectory()
		{
			//log.Trace("olddata delete");

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; });
			
			string oldData = Path.Combine(rootdir, OLD_DATA_DIR_NAME);
			if (Directory.Exists(oldData))
				Directory.Delete(oldData, true);

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Blocks; });
		}

		public void MoveFromRoot()
		{
			this.Invoke((MethodInvoker)delegate { progressBar1.Visible = true; progressBar1.Style = ProgressBarStyle.Marquee; });

			bool toBackup = backupBox.Checked;

			string oldData = rootdir + "\\" + OLD_DATA_DIR_NAME;
			var folders = Directory.GetDirectories(rootdir);
			var files = Directory.GetFiles(rootdir);

			string ExecutablePath = Environment.CurrentDirectory;
			if (ExecutablePath.IndexOf(rootdir) == 0 && ExecutablePath != rootdir)
			{
				//log.Trace("Moving Launcher.exe to rootdir");
				Directory.SetCurrentDirectory(rootdir);
				File.Move(ExecutablePath + $"\\{launcher_name}", rootdir + $"\\{launcher_name}");
			}

			if (Directory.Exists(oldData))
			{
				//log.Trace("olddata delete");
				Directory.Delete(oldData, true);
			}

			if (folders.Count() != 0)
			{
				//log.Trace("Moving all folders to olddata");
				Directory.CreateDirectory(oldData);
				foreach (var folder in folders)
				{
					if (!folder.EndsWith(OLD_DATA_DIR_NAME))
					{
						Directory.Move(folder, oldData + $"\\{folder.Split('\\').Last()}");
					}
				}
			}

			if (files.Count() != 0)
			{
				//log.Trace("Moving all files to olddata");
				Directory.CreateDirectory(oldData);
				foreach (var file in files)
				{
					if (!file.EndsWith(launcher_name) && !file.EndsWith(SETTINGS_FILENAME))
					{
						File.Move(file, oldData + $"\\{file.Split('\\').Last()}");
					}
				}
			}

			if (toBackup && Directory.Exists(oldData))
			{
				//log.Trace("Backup olddata");

				this.Invoke((MethodInvoker)delegate { progressLabel.Text = "Backup..."; progressLabel.Visible = true; });

				string oldZipPath = Path.Combine(oldData, OLD_DATA_NEWZIP_NAME);
				string oldZipPathBackup = Path.Combine(rootdir, OLD_DATA_OLDZIP_NAME);
				if (File.Exists(oldZipPath))
					File.Move(oldZipPath, oldZipPathBackup);

				ZipFile.CreateFromDirectory(oldData, Path.Combine(rootdir, OLD_DATA_NEWZIP_NAME), CompressionLevel.Fastest, true);

				if (File.Exists(oldZipPathBackup))
					File.Delete(oldZipPathBackup);

				this.Invoke((MethodInvoker)delegate { progressLabel.Visible = false; });
			}

			this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Blocks; });
		}

		public void MoveToRoot()
		{
			//log.Trace($"{downloaded_archive_name} - extraction complete.");
			string oldData = rootdir + "\\" + OLD_DATA_DIR_NAME;

			if (Directory.Exists(oldData))
			{
				//log.Trace("Moving user folders from olddata");

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

			KenanInstall();

			UndeadpeopleInstall();

			SoundpackInstall();
		}

		public void KenanInstall()
        {
			string KenanPath = rootdir + @"\Bright-Nights-Kenan-Mod-Pack-master\Kenan-BrightNights-Modpack";
			if (settings.KenanBoxState && Directory.Exists(KenanPath))
			{
				//log.Trace("Install KenanModpack");

				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; });

				var folders = Directory.GetDirectories(KenanPath);
				if (folders.Count() != 0)
				{
					//log.Trace("Moving mods to data\\mods");
					foreach (var folder in folders)
					{
						try
						{
							Directory.Move(folder, rootdir + $"\\data\\mods\\{folder.Split('\\').Last()}");
						}
						catch (IOException)
						{
							Utils.CopyDirectories(folder, rootdir + $"\\data\\mods\\{folder.Split('\\').Last()}");
						}
					}
				}

				//log.Trace("Delete installation folder");
				Directory.Delete(rootdir + @"\Bright-Nights-Kenan-Mod-Pack-master", true);
				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Blocks; });
			}
		}

		public void UndeadpeopleInstall()
        {
			string UndeadPath = rootdir + @"\UndeadPeopleTileset-master\TILESETS";
			if (Directory.Exists(UndeadPath))
			{
				//log.Trace("Install UndeadpeolpeTileset");

				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; });

				string[] folders;
				if (Directory.Exists(rootdir + @"\Mods"))
				{
					//log.Trace("Delete graphical mods");
					foreach (var folder in Directory.GetDirectories(rootdir + @"\Mods"))
					{
						if (folder.Split('\\').Last().Split('_').Contains("SDG") || folder.Split('\\').Last().Split('_').Contains("UnDeadPeople"))
						{
							Directory.Delete(rootdir + $"\\Mods\\{folder.Split('\\').Last()}", true);
						}
					}
				}
				
				folders = Directory.GetDirectories(UndeadPath + @"\gfx"); //log.Trace("Install tilesets\\gfx");
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

				if (settings.KenanBoxState)
				{
					//log.Trace("Updating tilesets\\data\\mods tilesets for KenanPack");
					folders = Directory.GetDirectories(UndeadPath + "\\data");
					foreach (var folder in folders)
					{
						Utils.CopyDirectories(folder, rootdir + $"\\data\\{folder.Split('\\').Last()}");
					}
				}
				else
				{
					//log.Trace("Install graphical&overmap mods");
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
								Utils.CopyDirectories(folder, rootdir + $"\\{folder.Split('\\').Last()}");
							}
						}
					}
				}
				//log.Trace("Delete installation folder");
				Directory.Delete(rootdir + @"\UndeadPeopleTileset-master", true);
			}
		}

		// Soundpack & Musicpack
		public void SoundpackInstall()
        {
			foreach (var item in SoundpackChecklistbox.CheckedItems)
			{
				string[] splited_sound = soundpacks[(string)item].Split('/');
				string soundpath = rootdir + $"\\{splited_sound[Array.IndexOf(splited_sound, "archive") - 1] + "-master"}";

				if (Directory.Exists(soundpath))
				{
					//log.Trace($"{(string)item} install");
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

				string[] splited_music = soundpacks[musicpack_name].Split('/');
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

				if (Directory.Exists(musicpack))
				{
					if (SP_musicreplace != "---")
					{
						//log.Trace($"{SP_musicreplace} music replace");
						string jsoncheck = Directory.GetFiles(musicpack, "musicset.json", SearchOption.AllDirectories)[0];
						string musicdir = jsoncheck.Substring(0, jsoncheck.Length - @"\musicset.json".Length);
						string sounddest = rootdir + $"\\data\\sound\\{SP_musicreplace}";
						if (Directory.Exists(sounddest + @"\music"))
						{
							Directory.Delete(sounddest + @"\music", true);
							Utils.CopyDirectories(musicdir, sounddest);
						}
						else
						{
							Utils.CopyDirectories(musicdir, sounddest);
						}
					}
				}
				//log.Trace("Delete installation folder");
				if (Directory.Exists(musicpack)) { Directory.Delete(musicpack, true); }
			}
			this.Invoke((MethodInvoker)delegate { flagLabel.Visible = false; });
		}
	}
}
