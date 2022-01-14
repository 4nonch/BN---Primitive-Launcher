using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace BN_Primitive_Launcher.Classes
{
    [Serializable]
    public class Settings
    {
		private bool savesBoxState = true;
		public bool SavesBoxState { get { return savesBoxState; } set { savesBoxState = value; } }


		private bool modsBoxState = true;
		public bool ModsBoxState { get { return modsBoxState; } set { modsBoxState = value; } }


		private bool soundBoxState = true;
		public bool SoundBoxState { get { return soundBoxState; } set { soundBoxState = value; } }


		private bool fontBoxState = true;
		public bool FontBoxState { get { return fontBoxState; } set { fontBoxState = value; } }


		private bool configBoxState = true;
		public bool ConfigBoxState { get { return configBoxState; } set { configBoxState = value; } }


		private bool templateBoxState = true;
		public bool TemplateBoxState { get { return templateBoxState; } set { templateBoxState = value; } }


		private bool memorialBoxState = true;
		public bool MemorialBoxState { get { return memorialBoxState; } set { memorialBoxState = value; } }


		private bool graveyardBoxState = true;
		public bool GraveyardBoxState { get { return graveyardBoxState; } set { graveyardBoxState = value; } }


		private bool backupBoxState = true;
		public bool BackupBoxState { get { return backupBoxState; } set { backupBoxState = value; } }


		private string textboxState = "";
		public string TextboxState { get { return textboxState; } set { textboxState = value; } }


		private string versionState = "";
		public string VersionState { get { return versionState; } set { versionState = value; } }


		private bool kenan_download_rbState = false;
		public bool Kenan_download_rbState { get { return kenan_download_rbState; } set { kenan_download_rbState = value; } }

		private bool kenan_downloadinstall_rbState = false;
		public bool Kenan_downloadinstall_rbState { get { return kenan_downloadinstall_rbState; } set { kenan_downloadinstall_rbState = value; } }

		private bool kenan_archivedBoxState = false;
		public bool Kenan_archivedBoxState { get { return kenan_archivedBoxState; } set { kenan_archivedBoxState = value; } }

		private bool kenan_highmaintBoxState = false;
		public bool Kenan_highmaintBoxState { get { return kenan_highmaintBoxState; } set { kenan_highmaintBoxState = value; } }

		private bool kenan_mediummaintBoxState = false;
		public bool Kenan_mediummaintBoxState { get { return kenan_mediummaintBoxState; } set { kenan_mediummaintBoxState = value; } }
	}
}

namespace BN_Primitive_Launcher
{
	public partial class Form1 : Form
	{
		public void BindUserSettings()
        {
			saveBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "SavesBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			ModsBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "ModsBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			soundBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "SoundBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			fontBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "FontBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			configBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "ConfigBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			templatesBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "TemplateBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			memorialBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "MemorialBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			graveyardBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "GraveyardBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			backupBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "BackupBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			tbGamepath.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings, "TextboxState", true, DataSourceUpdateMode.OnPropertyChanged));
			cbVerionBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings, "VersionState", true, DataSourceUpdateMode.OnPropertyChanged));
			
			//kenan_download_rb.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "Kenan_download_rbState", true, DataSourceUpdateMode.OnPropertyChanged));
			//kenan_downloadinstall_rb.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "Kenan_downloadinstall_rbState", true, DataSourceUpdateMode.OnPropertyChanged));
			kenan_archivedBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "Kenan_archivedBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			kenan_highmaintBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "Kenan_highmaintBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
			kenan_mediummaintBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings, "Kenan_mediummaintBoxState", true, DataSourceUpdateMode.OnPropertyChanged));
		}

		public void SerializeUserSettings()
		{
			XmlSerializer SerializerObj = new XmlSerializer(typeof(BN_Primitive_Launcher.Classes.Settings));
			using (FileStream filestream = new FileStream(SETTINGS_FILENAME, FileMode.Create, FileAccess.Write))
			{
				SerializerObj.Serialize(filestream, settings);
			}
		}

		public void DeserializeUserSettings()
        {
			if (File.Exists(SETTINGS_FILENAME))
			{
				XmlSerializer SerializerObj = new XmlSerializer(typeof(BN_Primitive_Launcher.Classes.Settings));
				using (FileStream filestream = new FileStream(SETTINGS_FILENAME, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					settings = (BN_Primitive_Launcher.Classes.Settings)SerializerObj.Deserialize(filestream);
				}
			}
            else
            {
				SerializeUserSettings();
			}
		}

		public void ApplyUserSettings()
		{
			saveBox.Checked      = settings.SavesBoxState;
			ModsBox.Checked      = settings.ModsBoxState;
			soundBox.Checked     = settings.SoundBoxState;
			fontBox.Checked      = settings.FontBoxState;
			configBox.Checked    = settings.ConfigBoxState;
			templatesBox.Checked = settings.TemplateBoxState;
			memorialBox.Checked  = settings.MemorialBoxState;
			graveyardBox.Checked = settings.GraveyardBoxState;
			backupBox.Checked    = settings.BackupBoxState;
			tbGamepath.Text     = settings.TextboxState;
			cbVerionBox.Text     = settings.VersionState;

			kenan_download_rb.Checked = settings.Kenan_download_rbState;
			kenan_downloadinstall_rb.Checked = settings.Kenan_downloadinstall_rbState;
			kenan_archivedBox.Checked = settings.Kenan_archivedBoxState;
			kenan_highmaintBox.Checked = settings.Kenan_highmaintBoxState;
			kenan_mediummaintBox.Checked = settings.Kenan_mediummaintBoxState;
		}

		public void UpdateUserSettings()
        {
			settings.SavesBoxState     = saveBox.Checked;
			settings.ModsBoxState      = ModsBox.Checked;
			settings.SoundBoxState     = soundBox.Checked;
			settings.FontBoxState      = fontBox.Checked;
			settings.ConfigBoxState    = configBox.Checked;
			settings.TemplateBoxState  = templatesBox.Checked;
			settings.MemorialBoxState  = memorialBox.Checked;
			settings.GraveyardBoxState = graveyardBox.Checked;
			settings.BackupBoxState    = backupBox.Checked;
			settings.TextboxState      = tbGamepath.Text;
			settings.VersionState      = cbVerionBox.Text;

			settings.Kenan_download_rbState = kenan_download_rb.Checked;
			settings.Kenan_downloadinstall_rbState = kenan_downloadinstall_rb.Checked;
			settings.Kenan_archivedBoxState = kenan_archivedBox.Checked;
			settings.Kenan_highmaintBoxState = kenan_highmaintBox.Checked;
			settings.Kenan_mediummaintBoxState = kenan_mediummaintBox.Checked;
		}

		public List<string> SetUserPreferences()
		{
			List<string> preferences = new List<string>();
			
			if (saveBox.Checked)      { preferences.Add("save");      }
			if (ModsBox.Checked)      { preferences.Add("mods");      }
			if (soundBox.Checked)     { preferences.Add("sound");     }
			if (fontBox.Checked)      { preferences.Add("font");      }
			if (configBox.Checked)    { preferences.Add("config");    }
			if (templatesBox.Checked) { preferences.Add("templates"); }
			if (memorialBox.Checked)  { preferences.Add("memorial");  }
			if (graveyardBox.Checked) { preferences.Add("graveyard"); }

			return preferences;
		}

		public void SaveUnbindValues()
        {
			settings.Kenan_download_rbState = kenan_download_rb.Checked;
			settings.Kenan_downloadinstall_rbState = kenan_downloadinstall_rb.Checked;
        }
	}
}