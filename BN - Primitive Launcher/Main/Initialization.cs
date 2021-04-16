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
using System.Xml.Serialization;

namespace BN_Primitive_Launcher
{
    public partial class Form1 : Form
    {
		// Initializing variables and stuff
        Settings settings = new Settings();
		List<string> preferences;

		static string launcher_name = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
		static string bn_archiveName = "";
		static string rootdir = "";
		static string listbox_selected = "";
		static string musicname = "";

		static bool availability = true;

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

		private void Form1_Load(object sender, EventArgs e)
		{
			ApplyUserSettings();
			SetSecurityProtocol();
			//statusStrip1.Cursor = Cursors.Hand;
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
