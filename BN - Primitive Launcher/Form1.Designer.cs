
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.backupBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.graveyardBox = new System.Windows.Forms.CheckBox();
            this.memorialBox = new System.Windows.Forms.CheckBox();
            this.templatesBox = new System.Windows.Forms.CheckBox();
            this.configBox = new System.Windows.Forms.CheckBox();
            this.fontBox = new System.Windows.Forms.CheckBox();
            this.soundBox = new System.Windows.Forms.CheckBox();
            this.ModsBox = new System.Windows.Forms.CheckBox();
            this.saveBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackColor = System.Drawing.Color.LightGray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Click += new System.EventHandler(this.statusStrip1_Click);
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BN_Primitive_Launcher.Properties.Settings.Default, "GameState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Text = global::BN_Primitive_Launcher.Properties.Settings.Default.GameState;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.KenanState;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "KenanState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LanguageLabel
            // 
            resources.ApplyResources(this.LanguageLabel, "LanguageLabel");
            this.LanguageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LanguageLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BN_Primitive_Launcher.Properties.Settings.Default, "LanguageState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Text = global::BN_Primitive_Launcher.Properties.Settings.Default.LanguageState;
            this.LanguageLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // backupBox
            // 
            resources.ApplyResources(this.backupBox, "backupBox");
            this.backupBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.backupBoxState;
            this.backupBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backupBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "backupBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.backupBox.Name = "backupBox";
            this.backupBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::BN_Primitive_Launcher.Properties.Settings.Default, "TextboxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Name = "textBox1";
            this.textBox1.Text = global::BN_Primitive_Launcher.Properties.Settings.Default.TextboxState;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // graveyardBox
            // 
            resources.ApplyResources(this.graveyardBox, "graveyardBox");
            this.graveyardBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.graveyardBoxState;
            this.graveyardBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.graveyardBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "graveyardBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.graveyardBox.Name = "graveyardBox";
            this.graveyardBox.UseVisualStyleBackColor = true;
            // 
            // memorialBox
            // 
            resources.ApplyResources(this.memorialBox, "memorialBox");
            this.memorialBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.memorialBoxState;
            this.memorialBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.memorialBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "memorialBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.memorialBox.Name = "memorialBox";
            this.memorialBox.UseVisualStyleBackColor = true;
            // 
            // templatesBox
            // 
            resources.ApplyResources(this.templatesBox, "templatesBox");
            this.templatesBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.templatesBoxState;
            this.templatesBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.templatesBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "templatesBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.templatesBox.Name = "templatesBox";
            this.templatesBox.UseVisualStyleBackColor = true;
            // 
            // configBox
            // 
            resources.ApplyResources(this.configBox, "configBox");
            this.configBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.configBoxState;
            this.configBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.configBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "configBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.configBox.Name = "configBox";
            this.configBox.UseVisualStyleBackColor = true;
            // 
            // fontBox
            // 
            resources.ApplyResources(this.fontBox, "fontBox");
            this.fontBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.fontBoxState;
            this.fontBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fontBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "fontBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fontBox.Name = "fontBox";
            this.fontBox.UseVisualStyleBackColor = true;
            // 
            // soundBox
            // 
            resources.ApplyResources(this.soundBox, "soundBox");
            this.soundBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.soundBoxState;
            this.soundBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soundBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "soundBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.soundBox.Name = "soundBox";
            this.soundBox.UseVisualStyleBackColor = true;
            // 
            // ModsBox
            // 
            resources.ApplyResources(this.ModsBox, "ModsBox");
            this.ModsBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.ModBoxState;
            this.ModsBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ModsBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "ModBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ModsBox.Name = "ModsBox";
            this.ModsBox.UseVisualStyleBackColor = true;
            // 
            // saveBox
            // 
            resources.ApplyResources(this.saveBox, "saveBox");
            this.saveBox.Checked = global::BN_Primitive_Launcher.Properties.Settings.Default.savesBoxState;
            this.saveBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BN_Primitive_Launcher.Properties.Settings.Default, "savesBoxState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.saveBox.Name = "saveBox";
            this.saveBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.backupBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.graveyardBox);
            this.Controls.Add(this.memorialBox);
            this.Controls.Add(this.templatesBox);
            this.Controls.Add(this.configBox);
            this.Controls.Add(this.fontBox);
            this.Controls.Add(this.soundBox);
            this.Controls.Add(this.ModsBox);
            this.Controls.Add(this.saveBox);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox saveBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

