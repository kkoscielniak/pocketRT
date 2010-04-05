namespace pocketRT
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.enableMenuItem = new System.Windows.Forms.MenuItem();
            this.menuMenuItem = new System.Windows.Forms.MenuItem();
            this.hideMenuItem = new System.Windows.Forms.MenuItem();
            this.optionsMenuItem = new System.Windows.Forms.MenuItem();
            this.soundMenuItem = new System.Windows.Forms.MenuItem();
            this.vibrateMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.aboutMenuItem = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.timer = new System.Windows.Forms.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.communiqueTextBox = new System.Windows.Forms.TextBox();
            this.listCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.enableMenuItem);
            this.mainMenu.MenuItems.Add(this.menuMenuItem);
            // 
            // enableMenuItem
            // 
            this.enableMenuItem.Text = "Enable";
            this.enableMenuItem.Click += new System.EventHandler(this.enableMenuItem_Click);
            // 
            // menuMenuItem
            // 
            this.menuMenuItem.MenuItems.Add(this.hideMenuItem);
            this.menuMenuItem.MenuItems.Add(this.optionsMenuItem);
            this.menuMenuItem.MenuItems.Add(this.menuItem1);
            this.menuMenuItem.MenuItems.Add(this.aboutMenuItem);
            this.menuMenuItem.MenuItems.Add(this.exitMenuItem);
            this.menuMenuItem.Text = "Menu";
            // 
            // hideMenuItem
            // 
            this.hideMenuItem.Text = "Hide";
            this.hideMenuItem.Click += new System.EventHandler(this.hideMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.MenuItems.Add(this.soundMenuItem);
            this.optionsMenuItem.MenuItems.Add(this.vibrateMenuItem);
            this.optionsMenuItem.Text = "Options";
            // 
            // soundMenuItem
            // 
            this.soundMenuItem.Checked = true;
            this.soundMenuItem.Text = "Play sound";
            this.soundMenuItem.Click += new System.EventHandler(this.soundMenuItem_Click);
            // 
            // vibrateMenuItem
            // 
            this.vibrateMenuItem.Checked = true;
            this.vibrateMenuItem.Text = "Vibrate";
            this.vibrateMenuItem.Click += new System.EventHandler(this.vibrateMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "-";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 22);
            this.label1.Text = "Remind every";
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(3, 16);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(67, 22);
            this.intervalTextBox.TabIndex = 1;
            this.intervalTextBox.Text = "15";
            // 
            // minutesLabel
            // 
            this.minutesLabel.Location = new System.Drawing.Point(76, 16);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(85, 22);
            this.minutesLabel.Text = "minutes";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.Text = "Communique:";
            // 
            // communiqueTextBox
            // 
            this.communiqueTextBox.Location = new System.Drawing.Point(3, 58);
            this.communiqueTextBox.Name = "communiqueTextBox";
            this.communiqueTextBox.Size = new System.Drawing.Size(170, 22);
            this.communiqueTextBox.TabIndex = 4;
            // 
            // listCheckBox
            // 
            this.listCheckBox.Location = new System.Drawing.Point(3, 87);
            this.listCheckBox.Name = "listCheckBox";
            this.listCheckBox.Size = new System.Drawing.Size(170, 22);
            this.listCheckBox.TabIndex = 5;
            this.listCheckBox.Text = "Use list of communiques";
            this.listCheckBox.CheckStateChanged += new System.EventHandler(this.listCheckBox_CheckStateChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Nina", 10F, System.Drawing.FontStyle.Italic);
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(46, 112);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(127, 22);
            this.statusLabel.Text = "Disabled";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listCheckBox);
            this.Controls.Add(this.communiqueTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.minutesLabel);
            this.Controls.Add(this.intervalTextBox);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "pocketRT";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem enableMenuItem;
        private System.Windows.Forms.MenuItem menuMenuItem;
        private System.Windows.Forms.MenuItem hideMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuItem optionsMenuItem;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem aboutMenuItem;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox communiqueTextBox;
        private System.Windows.Forms.CheckBox listCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.MenuItem soundMenuItem;
        private System.Windows.Forms.MenuItem vibrateMenuItem;
    }
}

