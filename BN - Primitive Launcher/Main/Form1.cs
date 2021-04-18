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
		public Form1()
		{
			InitializeComponent();
		}

		private void btDirDialogOpen_Click(object sender, EventArgs e)
		{
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
			ProcessInstallClick(sender);
		}
		private void btSPinstall_Click(object sender, EventArgs e)
		{
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

			preferences = SetUserPreferences();
			SP_musicreplace = (string)MusicreplaceListbox.Items[MusicreplaceListbox.SelectedIndex];
			musicpack_name = cbMusicbox.Text;

			Button btInstall = (Button)sender;
			if (btInstall.Name == "btUpdate")
			{
				btUpdate_process();
			}
			else if (btInstall.Name == "btSPinstall")
			{
				btSPinstall_process();
			}
		}
		public async void btUpdate_process()
        {
			string version = String.Join("-", cbVerionBox.Text.Split('-').Skip(1));

											await Task.Run(() => MoveFromRoot());
											await Task.Run(() => GameDownload(version));
			if (settings.KenanBoxState) {	await Task.Run(() => KenanDownload()); }
											await Task.Run(() => UndeadpeopleDownload());
											await Task.Run(() => SoundpackDownload());
			if (SP_musicreplace != "---") { await Task.Run(() => MusicDownload()); }
											await Task.Run(() => ClearOldDirectory());

			progressBar1.Visible = false;
			label3.Visible = true;
			ToggleControlsAvailability();
		}
		public async void btSPinstall_process()
		{
			progressBar1.Visible = true;

											await Task.Run(() => SoundpackDownload());
			if (SP_musicreplace != "---") { await Task.Run(() => MusicDownload()); }

			progressBar1.Visible = false;
			label3.Visible = true;
			ToggleControlsAvailability();
		}
		
		private void btPlay_Click(object sender, EventArgs e)
		{
			if (!availability) { return; }

			string game_path = tbGamepath.Text + "\\cataclysm-tiles.exe";
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
				MessageBox.Show($"{settings.VersionState}");
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
			string game_path = tbGamepath.Text + "\\cataclysm-tiles.exe";
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
    }
}
