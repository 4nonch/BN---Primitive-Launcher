using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using BN_Primitive_Launcher.Classes;

namespace BN_Primitive_Launcher
{
    public partial class Form1 : Form
    {
		// Initializing variables and stuff
        Settings settings = new Settings();
		List<string> preferences;
		List<string> kenan_inst_options = new List<string>();

		static string launcher_name = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
		static string downloaded_archive_name = "";
		static string rootdir = "";
		static string SP_musicreplace = "";
		static string musicpack_name = "";

		static bool availability = true;
		static bool KenanState;

		static Dictionary<string, string> soundpacks = new Dictionary<string, string>
		{
			{ "Otopack soundpack", @"https://github.com/Kenan2000/Otopack-Mods-Updates/archive/refs/heads/master.zip" },
			{ "@'s soundpack",     @"https://github.com/damalsk/damalsksoundpack/archive/refs/heads/master.zip" },
			{ "CO.AG", @"https://github.com/4nonch/CO.AG-copy/archive/refs/heads/main.zip" }
		};

		// Constants
		const string OLD_DATA_DIR_NAME = "BN - old data";
		const string OLD_DATA_NEWZIP_NAME = "BN - backup.zip";
		const string OLD_DATA_OLDZIP_NAME = "BN - backup-old.zip";
		const string SETTINGS_FILENAME = "LauncherSettings.xml";

		private void Form1_Load(object sender, EventArgs e)
		{
			DeserializeUserSettings();
			BindUserSettings();
			ApplyUserSettings();
			
			SetSecurityProtocol();

			if (!kenan_downloadinstall_rb.Checked)
            {
				kenan_archivedBox.Enabled = false;
				kenan_highmaintBox.Enabled = false;
				kenan_mediummaintBox.Enabled = false;
            }

			progressBar1.Minimum = 0;
			progressBar1.Maximum = 100;
			
			if (tbGamepath.Text != "") { tbGamepath.Enabled = false; }
			
			MusicreplaceListbox.SelectedIndex = 0;
			cbMusicbox.SelectedIndex = 0;
			
			if (cbVerionBox.Text == "") { cbVerionBox.Text = "cataclysmbn-win64-tiles"; }
			
			UpdateButtonCheck();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			//UpdateUserSettings();
			SaveUnbindValues();
			SerializeUserSettings();
			//log.Info($"END LOG");
		}
	}
}
