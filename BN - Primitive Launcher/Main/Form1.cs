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
	public partial class Form1 : Form // This is there Controls handling
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

			if (settings.KenanBoxState) { await Task.Run( () => KenanDownload() ); }
			await Task.Run( () => UndeadpeopleDownload() );
			await Task.Run( () => SoundpackDownload() );
			if (soundpack_music_to_replace != "---") { await Task.Run( () => MusicDownload() ); }
			await Task.Run( () => ClearOldDirectory(progress) );
			UpdateButtonCheck();
			progressBar1.Visible = false;
			availability = true;
			label3.Visible = true;
		}

		private void ClearOldDirectory(IProgress<sbyte> progress)
		{
			progress.Report(1);
			string oldData =  Path.Combine(rootdir, OLD_DATA_DIR_NAME);
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

			soundpack_music_to_replace = (string)MusicreplaceListbox.Items[MusicreplaceListbox.SelectedIndex];
			musicpack_name = cbMusicbox.Text;

			await Task.Run(() => SoundpackDownload());
			if ((string)MusicreplaceListbox.Items[MusicreplaceListbox.SelectedIndex] != "---") { await Task.Run(() => MusicDownload()); }

			progressBar1.Visible = false;
			availability = true;

		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && tbPathInput.Enabled == true)
			{
				MessageBox.Show($"{settings.VersionState}");
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
				MusicreplaceListbox.Items.Add(SoundpackChecklistbox.Items[e.Index]);
            }
            else
            {
				MusicreplaceListbox.Items.Remove(SoundpackChecklistbox.Items[e.Index]);
			}
			//MessageBox.Show($"{listBox1.SelectedIndex}");
        }
    }
}
