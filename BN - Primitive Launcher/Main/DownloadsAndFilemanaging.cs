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

				downloaded_archive_name = matches[0].ToString().Split('/').Last();
				client.DownloadFileAsync(new Uri(@"https://github.com/" + matches[0]), matches[0].ToString().Split('/').Last());
				while (flagLabel.Visible) {; }
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
				downloaded_archive_name = "Kenan.zip";
				client.DownloadFileAsync(new Uri(url), downloaded_archive_name);
				while (flagLabel.Visible) {; }
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
				downloaded_archive_name = "UPT.zip";
				client.DownloadFileAsync(new Uri(url), downloaded_archive_name);
				while (flagLabel.Visible) {; }
			}
		}

		public void SoundpackDownload()
		{
			foreach (var item in SoundpackChecklistbox.CheckedItems)
			{
				this.Invoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });
				if (soundpack_music_to_replace != (string)item || !Directory.Exists(rootdir + $"\\data\\sound\\{(string)item}"))
				{
					using (var client = new WebClient())
					{
						//this.BeginInvoke((MethodInvoker)delegate { progressBar1.Style = ProgressBarStyle.Marquee; flagLabel.Visible = true; });
						client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
						client.Headers.Add("user-agent", "Anything");
						//MessageBox.Show((string)item + " 1 " + MessageBox.Show(bn_archiveName));
						downloaded_archive_name = $"{(string)item}.zip";
						client.DownloadFileAsync(new Uri(soundpacks[(string)item]), downloaded_archive_name);
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
				downloaded_archive_name = $"{musicpack_name}.zip";
				client.DownloadFileAsync(new Uri(soundpacks[musicpack_name]), downloaded_archive_name);
				while (flagLabel.Visible) {; }
			}
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
			bool error = false;
			bool is_first_time = true;
			string archive_name = "";
			//MessageBox.Show(bn_archiveName);
			ZipArchive zipArchive = ZipFile.OpenRead(Directory.GetCurrentDirectory() + "\\" + downloaded_archive_name);
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

			MoveToRoot(archive_name);
		}


		// Directories&Files managing
		public void MoveFromRoot(IProgress<sbyte> progress)
		{
			bool toBackup = backupBox.Checked;

			string oldData = rootdir + "\\" + OLD_DATA_DIR_NAME;
			var folders = Directory.GetDirectories(rootdir);
			var files = Directory.GetFiles(rootdir);

			string ExecutablePath = Environment.CurrentDirectory;
			if (ExecutablePath.IndexOf(rootdir) == 0 && ExecutablePath != rootdir)
			{
				Directory.SetCurrentDirectory(rootdir);
				File.Move(ExecutablePath + $"\\{launcher_name}", rootdir + $"\\{launcher_name}");
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
					if (!folder.EndsWith(OLD_DATA_DIR_NAME))
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
					if (!file.EndsWith(launcher_name))
					{
						File.Move(file, oldData + $"\\{file.Split('\\').Last()}");
					}
				}
			}

			progress.Report(1);
			if (toBackup && Directory.Exists(oldData))
			{
				string oldZipPath = Path.Combine(oldData, OLD_DATA_NEWZIP_NAME);
				string oldZipPathBackup = Path.Combine(rootdir, OLD_DATA_OLDZIP_NAME);
				if (File.Exists(oldZipPath))
					File.Move(oldZipPath, oldZipPathBackup);

				ZipFile.CreateFromDirectory(oldData, Path.Combine(rootdir, OLD_DATA_NEWZIP_NAME), CompressionLevel.Fastest, true);

				if (File.Exists(oldZipPathBackup))
					File.Delete(oldZipPathBackup);
			}

			progress.Report(0);
		}

		public void MoveToRoot(string folder_name)
		{
			string oldData = rootdir + "\\" + OLD_DATA_DIR_NAME;

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
			if (settings.KenanBoxState && Directory.Exists(KenanPath))
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
						catch (IOException)
						{
							Utils.CopyDirectories(folder, rootdir + $"\\data\\mods\\{folder.Split('\\').Last()}");
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
				if (settings.KenanBoxState)
				{

					folders = Directory.GetDirectories(UndeadPath);
					foreach (var folder in folders)
					{
						Utils.CopyDirectories(folder, rootdir + $"\\{folder.Split('\\').Last()}");
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
								Utils.CopyDirectories(folder, rootdir + $"\\{folder.Split('\\').Last()}");
							}
						}
					}
				}
				Directory.Delete(rootdir + @"\UndeadPeopleTileset-master", true);
			}

			foreach (var item in SoundpackChecklistbox.CheckedItems)
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
				//// Надо будет (кажется теперь уже не надо) обязательно переделать folder name (при распаковке сабстринг
				//// сабстринг с длинной (рутдир + символ слеша), сплит по слешу, беру первый элемент - это и будет название папки)
				if (Directory.Exists(musicpack))
				{
					if (soundpack_music_to_replace != "---")
					{
						string jsoncheck = Directory.GetFiles(musicpack, "musicset.json", SearchOption.AllDirectories)[0];
						string musicdir = jsoncheck.Substring(0, jsoncheck.Length - @"\musicset.json".Length);
						string sounddest = rootdir + $"\\data\\sound\\{soundpack_music_to_replace}";
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
				if (Directory.Exists(musicpack)) { Directory.Delete(musicpack, true); }
			}
			this.Invoke((MethodInvoker)delegate { flagLabel.Visible = false; });
		}
	}
}
