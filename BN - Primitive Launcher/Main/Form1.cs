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
using BN_Primitive_Launcher.Classes;

namespace BN_Primitive_Launcher
{
	public partial class Form1 : Form // This is where Controls handling
	{
		//Logger log = LogManager.GetCurrentClassLogger();
		public Form1()
		{
			//log.Info("BEGIN LOG");

			InitializeComponent();
			//webBrowser1.DocumentText = "<pre>WIP</pre>";
			//webBrowser1.DocumentText = "<div style = \"border:1px solid black;\"><div class=\"f1 flex-auto min - width - 0 text - normal\"><a href=\" / cataclysmbnteam / Cataclysm - BN / releases / tag / 1626\">1626:Merge pull request #375 from LyleSY/patch-7</a></div><div class=\"commit - desc\"><pre class=\"text - small color - text - secondary\">[DinoMod] The Bone Wars</pre></div></div><div style = \"border:1px solid black;\"><div class=\"f1 flex-auto min - width - 0 text - normal\"><a href=\" / cataclysmbnteam / Cataclysm - BN / releases / tag / 1626\">1626:Merge pull request #375 from LyleSY/patch-7</a></div><div class=\"commit - desc\"><pre class=\"text - small color - text - secondary\">[DinoMod] The Bone Wars</pre></div></div>";
			//LauncherDownload();
		}

		private void btDirDialogOpen_Click(object sender, EventArgs e)
		{
			//log.Info("DirDialog - Click");
			if (!availability) { return; }
			var dlg = new FolderPicker();
			dlg.InputPath = Directory.GetCurrentDirectory();
			if (dlg.ShowDialog(IntPtr.Zero) == true)
			{
				tbGamepath.Text = dlg.ResultPath;
				tbGamepath.Enabled = false;
				UpdateButtonCheck();
			}
		}

		private void btUpdate_Click(object sender, EventArgs e)
		{
			//log.Info("UpdateButton - Click");
			ProcessInstallClick(sender);
		}
		private void btSPinstall_Click(object sender, EventArgs e)
		{
			//log.Info("SPinstallButton - Click");
			ProcessInstallClick(sender);
		}
		public void ProcessInstallClick(object sender)
		{
			rootdir = tbGamepath.Text;

			if (availability == false) { MessageBox.Show("Game is currently updating..."); return; }
			if (!Utils.CheckRootdir(rootdir)) { return; }
			if (label3.Visible == true) { label3.Visible = false; }

			ToggleControlsAvailability();
			UpdateButtonCheck();

			progressBar1.Minimum = 0;
			progressBar1.Maximum = 100;

			/*log.Trace($"ROOTDIR = {rootdir}; Getting user preferences...");*/ preferences = SetUserPreferences();
			SP_musicreplace = (string)MusicreplaceListbox.Items[MusicreplaceListbox.SelectedIndex];
			musicpack_name = cbMusicbox.Text;

			if (kenan_mediummaintBox.Checked)
				kenan_inst_options.Add(kenan_mediummaintBox.Text);
			if(kenan_highmaintBox.Checked)
				kenan_inst_options.Add(kenan_highmaintBox.Text);
			if(kenan_archivedBox.Checked)
				kenan_inst_options.Add(kenan_archivedBox.Text);

			Button btInstall = (Button)sender;
			if (btInstall.Name == "btUpdate")
			{
				//log.Info("Update Begin");
				btUpdate_process();
			}
			else if (btInstall.Name == "btSPinstall")
			{
				//log.Info("Soundpack Installation Begin");
				btSPinstall_process();
			}
		}
		public async void btUpdate_process()
        {
			string version = String.Join("-", cbVerionBox.Text.Split('-').Skip(3));

											/*log.Info("MoveFromRoot Begin");*/			await Task.Run(() => MoveFromRoot());
											/*log.Info("GameDownload Begin");*/			await Task.Run(() => GameDownload(version));
			KenanState = kenan_download_rb.Checked || kenan_downloadinstall_rb.Checked;
			if (KenanState)
			{
				await Task.Run(() => KenanDownload());
                await Task.Run(() => UndeadpeopleDownload());
            }
											/*log.Info("SoundpackDownload Begin");*/	await Task.Run(() => SoundpackDownload());
			if (SP_musicreplace != "---") { /*log.Info("MusicDownload Begin");*/		await Task.Run(() => MusicDownload()); }
											/*log.Info("ClearOldDirectory Begin");*/	await Task.Run(() => ClearOldDirectory());

			progressBar1.Visible = false;
			label3.Visible = true;
			ToggleControlsAvailability();
		}
		public async void btSPinstall_process()
		{
			progressBar1.Visible = true;

											/*log.Info("SoundpackDownload Begin");*/	await Task.Run(() => SoundpackDownload());
			if (SP_musicreplace != "---") { /*log.Info("MusicDownload Begin");*/		await Task.Run(() => MusicDownload()); }

			progressBar1.Visible = false;
			label3.Visible = true;
			ToggleControlsAvailability();
		}
		
		private void btPlay_Click(object sender, EventArgs e)
		{
			if (!availability) { return; }

			string game_path = tbGamepath.Text + "\\cataclysm-bn-tiles.exe";
			if (File.Exists(game_path) && tbGamepath.Text != "")
            {
				var previous_directory = Directory.GetCurrentDirectory();
				Directory.SetCurrentDirectory(tbGamepath.Text);
				
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
			if (e.KeyCode == Keys.Enter && tbGamepath.Enabled == true)
			{
				//log.Info("Textbox Input");
				tbGamepath.Enabled = false;
				UpdateButtonCheck();
			}
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			flagLabel.Focus();
			if (tbGamepath.Bounds.Contains(e.Location) && availability == true)
			{
				if (tbGamepath.Enabled == false) 
				{ 
					tbGamepath.Enabled = true;
					tbGamepath.SelectAll();
					tbGamepath.Focus();
				}
			}
		}

		public void UpdateButtonCheck()
        {
			string game_path = tbGamepath.Text + "\\cataclysm-bn-tiles.exe";
			if (File.Exists(game_path) && tbGamepath.Text != "")
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
				MusicreplaceListbox.Items.Add(SoundpackChecklistbox.Items[e.Index]);
            }
            else
            {
				MusicreplaceListbox.Items.Remove(SoundpackChecklistbox.Items[e.Index]);
			}
        }

        private void progressLabel_SizeChanged(object sender, EventArgs e)
        {
			progressLabel.Left = ((Size.Width - progressLabel.Size.Width) / 2) - 8;
		}

        private void kenan_downloadinstall_rb_CheckedChanged(object sender, EventArgs e)
        {
			if (!availability) { return; }
			kenan_archivedBox.Enabled = kenan_downloadinstall_rb.Checked;
			kenan_highmaintBox.Enabled = kenan_downloadinstall_rb.Checked;
			kenan_mediummaintBox.Enabled = kenan_downloadinstall_rb.Checked;
			kenan_archivedBox.Checked = !kenan_downloadinstall_rb.Checked ? false : kenan_archivedBox.Checked;
			kenan_highmaintBox.Checked = !kenan_downloadinstall_rb.Checked ? false : kenan_highmaintBox.Checked;
			kenan_mediummaintBox.Checked = !kenan_downloadinstall_rb.Checked ? false : kenan_mediummaintBox.Checked;
		}

        private void kenan_downloadinstall_rb_MouseClick(object sender, MouseEventArgs e)
        {
			if (!availability) { return; }
			if (kenan_download_rb.Checked)
			{
				kenan_download_rb.Checked = false;
			}
		}

        private void kenan_download_rb_MouseClick(object sender, MouseEventArgs e)
        {
			if (!availability) { return; }
			if (kenan_downloadinstall_rb.Checked)
			{
				kenan_downloadinstall_rb.Checked = false;
			}
		}
    }
}
