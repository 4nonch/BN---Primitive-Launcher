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
		private async void btUpdate_Click(object sender, EventArgs e)
		{
            if (availability == false) { MessageBox.Show("Game is currently updating..."); return; }
			if (cbVerionBox.Text == "") { MessageBox.Show("Game version not selected"); return; }
			if (label3.Visible == true) { label3.Visible = false; }

			availability = false;
			ToggleControlsAvailability();

			tbGamepath.Enabled = false;
			rootdir = tbGamepath.Text;
			soundpack_music_to_replace = (string)MusicreplaceListbox.Items[MusicreplaceListbox.SelectedIndex];
			musicpack_name = cbMusicbox.Text;

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

			await Task.Run(() => MoveFromRoot());
			progressBar1.Style = ProgressBarStyle.Blocks;

			string version = String.Join("-", cbVerionBox.Text.Split('-').Skip(1));
			await Task.Run( () => GameDownload(version) );

			if (settings.KenanBoxState) { await Task.Run( () => KenanDownload() ); }
			await Task.Run( () => UndeadpeopleDownload() );
			await Task.Run( () => SoundpackDownload() );
			if (soundpack_music_to_replace != "---") { await Task.Run( () => MusicDownload() ); }
			await Task.Run( () => ClearOldDirectory() );
			UpdateButtonCheck();

			progressBar1.Visible = false;
			availability = true;
			
			label3.Visible = true;
			ToggleControlsAvailability();
		}
		private async void btSPinstall_Click(object sender, EventArgs e)
		{
			if (availability == false) { MessageBox.Show("Soundpack installation..."); return; }
			UpdateButtonCheck();
			availability = false;
			ToggleControlsAvailability();

			rootdir = tbGamepath.Text;
			progressBar1.Visible = true;

			soundpack_music_to_replace = (string)MusicreplaceListbox.Items[MusicreplaceListbox.SelectedIndex];
			musicpack_name = cbMusicbox.Text;

			await Task.Run(() => SoundpackDownload());
			if ((string)MusicreplaceListbox.Items[MusicreplaceListbox.SelectedIndex] != "---") { await Task.Run(() => MusicDownload()); }

			progressBar1.Visible = false;
			availability = true;
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

		public void ToggleControlsAvailability()
        {
			if (!availability)
			{
				btDirDialogOpen.Enabled = false;
				btPlay.Enabled = false;
				cbVerionBox.Enabled = false;
				SoundpackChecklistbox.Enabled = false;
				MusicreplaceListbox.Enabled = false;
				cbMusicbox.Enabled = false;
				btSPinstall.Enabled = false;
				foreach (var control in tabPage1.Controls)
                {
					try
					{
						var checkbox = (CheckBox)control; // Возможна ли утечка памяти при таком подходе?
						checkbox.Enabled = false;
					}
                    catch { ; }
                }
			}
            else
            {
				btDirDialogOpen.Enabled = true;
				btPlay.Enabled = true;
				cbVerionBox.Enabled = true;
				SoundpackChecklistbox.Enabled = true;
				MusicreplaceListbox.Enabled = true;
				cbMusicbox.Enabled = true;
				btSPinstall.Enabled = true;
				foreach (var control in tabPage1.Controls)
				{
					try
					{
						var checkbox = (CheckBox)control; // Возможна ли утечка памяти при таком подходе?
						checkbox.Enabled = true;
					}
					catch { ; }
				}

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
			//MessageBox.Show($"{listBox1.SelectedIndex}");
        }

        private void progressLabel_SizeChanged(object sender, EventArgs e)
        {
			//MessageBox.Show($"{Size.Width}");
			progressLabel.Left = ((Size.Width - progressLabel.Size.Width) / 2) - 8;
			//MessageBox.Show($"{progressLabel.Width} {Form1.ActiveForm.Width / 2 - progressLabel.Width / 2} {Size.Width / 2 - progressLabel.Width / 2}");
			//progressLabel.Left = (Size.Width - progressLabel.Width) / 2;
		}
    }
}
