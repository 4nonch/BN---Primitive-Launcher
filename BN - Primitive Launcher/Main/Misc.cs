using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using BN_Primitive_Launcher.Classes;

namespace BN_Primitive_Launcher
{
	public partial class Form1 : Form
	{
		public void ToggleControlsAvailability()
		{
			log.Trace("Toggle controls...");
			if (availability)
			{
				availability = false;
				btDirDialogOpen.Enabled = false;
				btPlay.Enabled = false;
				tbGamepath.Enabled = false;
				cbVerionBox.Enabled = false;
				SoundpackChecklistbox.Enabled = false;
				MusicreplaceListbox.Enabled = false;
				cbMusicbox.Enabled = false;
				btSPinstall.Enabled = false;
				foreach (var control in tabPage1.Controls)
				{
					try
					{
						var checkbox = (CheckBox)control;
						checkbox.Enabled = false;
					}
					catch {; }
				}
			}
			else
			{
				availability = true;
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
						var checkbox = (CheckBox)control;
						checkbox.Enabled = true;
					}
					catch {; }
				}

			}
		}
	}
}
