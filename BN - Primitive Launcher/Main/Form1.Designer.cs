
namespace BN_Primitive_Launcher
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btDirDialogOpen = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btPlay = new System.Windows.Forms.Button();
            this.cbVerionBox = new System.Windows.Forms.ComboBox();
            this.kenanBox = new System.Windows.Forms.CheckBox();
            this.backupBox = new System.Windows.Forms.CheckBox();
            this.tbPathInput = new System.Windows.Forms.TextBox();
            this.graveyardBox = new System.Windows.Forms.CheckBox();
            this.memorialBox = new System.Windows.Forms.CheckBox();
            this.templatesBox = new System.Windows.Forms.CheckBox();
            this.configBox = new System.Windows.Forms.CheckBox();
            this.fontBox = new System.Windows.Forms.CheckBox();
            this.soundBox = new System.Windows.Forms.CheckBox();
            this.ModsBox = new System.Windows.Forms.CheckBox();
            this.saveBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btSPinstall = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flagLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(100, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BN root folder:";
            // 
            // btDirDialogOpen
            // 
            this.btDirDialogOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDirDialogOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btDirDialogOpen.Location = new System.Drawing.Point(177, 45);
            this.btDirDialogOpen.Name = "btDirDialogOpen";
            this.btDirDialogOpen.Size = new System.Drawing.Size(27, 20);
            this.btDirDialogOpen.TabIndex = 3;
            this.btDirDialogOpen.Text = "..";
            this.btDirDialogOpen.UseVisualStyleBackColor = true;
            this.btDirDialogOpen.Click += new System.EventHandler(this.btDirDialogOpen_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btUpdate.Location = new System.Drawing.Point(140, 74);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(75, 23);
            this.btUpdate.TabIndex = 2;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.progressBar1.Location = new System.Drawing.Point(71, 104);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(92, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Folders to carry:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(89, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Update completed!";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(111, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Backup...";
            this.label4.Visible = false;
            // 
            // btPlay
            // 
            this.btPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPlay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btPlay.Location = new System.Drawing.Point(59, 74);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(75, 23);
            this.btPlay.TabIndex = 18;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // cbVerionBox
            // 
            this.cbVerionBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BN_Primitive_Launcher.Properties.Settings.Default, "GameState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbVerionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVerionBox.FormattingEnabled = true;
            this.cbVerionBox.Items.AddRange(new object[] {
            "cataclysmbn-win64-tiles-o3",
            "cataclysmbn-win64-tiles",
            "cataclysmbn-win32-tiles"});
            this.cbVerionBox.Location = new System.Drawing.Point(61, 152);
            this.cbVerionBox.Name = "cbVerionBox";
            this.cbVerionBox.Size = new System.Drawing.Size(154, 21);
            this.cbVerionBox.TabIndex = 21;
            this.cbVerionBox.Text = global::BN_Primitive_Launcher.Properties.Settings.Default.GameState;
            // 
            // kenanBox
            // 
            this.kenanBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.KenanState;
            this.kenanBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kenanBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "KenanState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.kenanBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kenanBox.Location = new System.Drawing.Point(61, 144);
            this.kenanBox.Name = "kenanBox";
            this.kenanBox.Size = new System.Drawing.Size(167, 17);
            this.kenanBox.TabIndex = 20;
            this.kenanBox.Text = "Install Kenan\'s modpack";
            this.kenanBox.UseVisualStyleBackColor = true;
            // 
            // backupBox
            // 
            this.backupBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.backupBoxState;
            this.backupBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backupBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "backupBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.backupBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.backupBox.Location = new System.Drawing.Point(61, 124);
            this.backupBox.Name = "backupBox";
            this.backupBox.Size = new System.Drawing.Size(167, 17);
            this.backupBox.TabIndex = 15;
            this.backupBox.Text = "Current version full backup";
            this.backupBox.UseVisualStyleBackColor = true;
            // 
            // tbPathInput
            // 
            this.tbPathInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BN_Primitive_Launcher.Properties.Settings.Default, "TextboxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbPathInput.Location = new System.Drawing.Point(71, 45);
            this.tbPathInput.Name = "tbPathInput";
            this.tbPathInput.Size = new System.Drawing.Size(100, 20);
            this.tbPathInput.TabIndex = 1;
            this.tbPathInput.Text = global::BN_Primitive_Launcher.Properties.Settings.Default.TextboxState;
            this.tbPathInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // graveyardBox
            // 
            this.graveyardBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.graveyardBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.graveyardBoxState;
            this.graveyardBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.graveyardBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "graveyardBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.graveyardBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graveyardBox.Location = new System.Drawing.Point(136, 97);
            this.graveyardBox.Name = "graveyardBox";
            this.graveyardBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.graveyardBox.Size = new System.Drawing.Size(125, 21);
            this.graveyardBox.TabIndex = 13;
            this.graveyardBox.Text = "graveyard folder\\";
            this.graveyardBox.UseVisualStyleBackColor = true;
            // 
            // memorialBox
            // 
            this.memorialBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.memorialBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.memorialBoxState;
            this.memorialBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.memorialBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "memorialBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.memorialBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.memorialBox.Location = new System.Drawing.Point(7, 97);
            this.memorialBox.Name = "memorialBox";
            this.memorialBox.Size = new System.Drawing.Size(123, 21);
            this.memorialBox.TabIndex = 12;
            this.memorialBox.Text = "\\memorial folder";
            this.memorialBox.UseVisualStyleBackColor = true;
            // 
            // templatesBox
            // 
            this.templatesBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.templatesBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.templatesBoxState;
            this.templatesBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.templatesBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "templatesBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.templatesBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.templatesBox.Location = new System.Drawing.Point(136, 74);
            this.templatesBox.Name = "templatesBox";
            this.templatesBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.templatesBox.Size = new System.Drawing.Size(125, 21);
            this.templatesBox.TabIndex = 11;
            this.templatesBox.Text = "templates folder\\";
            this.templatesBox.UseVisualStyleBackColor = true;
            // 
            // configBox
            // 
            this.configBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.configBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.configBoxState;
            this.configBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.configBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "configBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.configBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.configBox.Location = new System.Drawing.Point(7, 74);
            this.configBox.Name = "configBox";
            this.configBox.Size = new System.Drawing.Size(123, 21);
            this.configBox.TabIndex = 10;
            this.configBox.Text = "\\config folder";
            this.configBox.UseVisualStyleBackColor = true;
            // 
            // fontBox
            // 
            this.fontBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.fontBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.fontBoxState;
            this.fontBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fontBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "fontBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fontBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fontBox.Location = new System.Drawing.Point(136, 51);
            this.fontBox.Name = "fontBox";
            this.fontBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.fontBox.Size = new System.Drawing.Size(125, 21);
            this.fontBox.TabIndex = 9;
            this.fontBox.Text = "font folder\\";
            this.fontBox.UseVisualStyleBackColor = true;
            // 
            // soundBox
            // 
            this.soundBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.soundBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.soundBoxState;
            this.soundBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soundBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "soundBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soundBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.soundBox.Location = new System.Drawing.Point(136, 28);
            this.soundBox.Name = "soundBox";
            this.soundBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.soundBox.Size = new System.Drawing.Size(125, 21);
            this.soundBox.TabIndex = 8;
            this.soundBox.Text = "Sounds";
            this.soundBox.UseVisualStyleBackColor = true;
            // 
            // ModsBox
            // 
            this.ModsBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ModsBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.ModBoxState;
            this.ModsBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ModsBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "ModBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ModsBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ModsBox.Location = new System.Drawing.Point(7, 51);
            this.ModsBox.Name = "ModsBox";
            this.ModsBox.Size = new System.Drawing.Size(123, 21);
            this.ModsBox.TabIndex = 7;
            this.ModsBox.Text = "\\Mods folder";
            this.ModsBox.UseVisualStyleBackColor = true;
            // 
            // saveBox
            // 
            this.saveBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.saveBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.savesBoxState;
            this.saveBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "savesBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.saveBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveBox.Location = new System.Drawing.Point(7, 28);
            this.saveBox.Name = "saveBox";
            this.saveBox.Size = new System.Drawing.Size(123, 21);
            this.saveBox.TabIndex = 0;
            this.saveBox.Text = "Saves";
            this.saveBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 191);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(275, 196);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.saveBox);
            this.tabPage1.Controls.Add(this.ModsBox);
            this.tabPage1.Controls.Add(this.configBox);
            this.tabPage1.Controls.Add(this.kenanBox);
            this.tabPage1.Controls.Add(this.memorialBox);
            this.tabPage1.Controls.Add(this.soundBox);
            this.tabPage1.Controls.Add(this.fontBox);
            this.tabPage1.Controls.Add(this.templatesBox);
            this.tabPage1.Controls.Add(this.backupBox);
            this.tabPage1.Controls.Add(this.graveyardBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(267, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Update Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.btSPinstall);
            this.tabPage2.Controls.Add(this.checkedListBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Soundpack Preferences";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.Items.AddRange(new object[] {
            "CO.AG"});
            this.comboBox2.Location = new System.Drawing.Point(138, 21);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(126, 20);
            this.comboBox2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "S.P to install";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Replace S.P. music to:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "---"});
            this.listBox1.Location = new System.Drawing.Point(138, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(126, 95);
            this.listBox1.TabIndex = 25;
            // 
            // btSPinstall
            // 
            this.btSPinstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btSPinstall.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btSPinstall.Location = new System.Drawing.Point(95, 134);
            this.btSPinstall.Name = "btSPinstall";
            this.btSPinstall.Size = new System.Drawing.Size(75, 20);
            this.btSPinstall.TabIndex = 24;
            this.btSPinstall.Text = "Install";
            this.btSPinstall.UseVisualStyleBackColor = true;
            this.btSPinstall.Click += new System.EventHandler(this.btSPinstall_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Otopack soundpack",
            "@\'s soundpack"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 21);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(126, 109);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Game version:";
            // 
            // flagLabel
            // 
            this.flagLabel.AutoSize = true;
            this.flagLabel.Location = new System.Drawing.Point(263, 9);
            this.flagLabel.Name = "flagLabel";
            this.flagLabel.Size = new System.Drawing.Size(0, 13);
            this.flagLabel.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 387);
            this.Controls.Add(this.flagLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbVerionBox);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btDirDialogOpen);
            this.Controls.Add(this.tbPathInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(291, 426);
            this.MinimumSize = new System.Drawing.Size(291, 426);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BN Launcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPathInput;
        private System.Windows.Forms.Button btDirDialogOpen;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox saveBox;
        private System.Windows.Forms.CheckBox ModsBox;
        private System.Windows.Forms.CheckBox soundBox;
        private System.Windows.Forms.CheckBox fontBox;
        private System.Windows.Forms.CheckBox configBox;
        private System.Windows.Forms.CheckBox templatesBox;
        private System.Windows.Forms.CheckBox memorialBox;
        private System.Windows.Forms.CheckBox graveyardBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox backupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.CheckBox kenanBox;
        private System.Windows.Forms.ComboBox cbVerionBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btSPinstall;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label flagLabel;
    }
}

