
namespace AutoClickerCS
{
    partial class AutoClickerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.inputTypeComboBox = new System.Windows.Forms.ComboBox();
            this.addKeyButton = new System.Windows.Forms.Button();
            this.addTimeButton = new System.Windows.Forms.Button();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.inputTypeLabel = new System.Windows.Forms.Label();
            this.mouseInputGroupBox = new System.Windows.Forms.GroupBox();
            this.currYDynamicLabel = new System.Windows.Forms.Label();
            this.currXDynamicLabel = new System.Windows.Forms.Label();
            this.currentYlabel = new System.Windows.Forms.Label();
            this.currentXlabel = new System.Windows.Forms.Label();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.repeatTextBox = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.onScreenKeyboardButton = new System.Windows.Forms.Button();
            this.timeBreakGroupBox = new System.Windows.Forms.GroupBox();
            this.intervalsGroupBox = new System.Windows.Forms.GroupBox();
            this.infiniteCheckBox = new System.Windows.Forms.CheckBox();
            this.intervalsTextBox = new System.Windows.Forms.TextBox();
            this.intervalsLabel = new System.Windows.Forms.Label();
            this.ShortcutsLabel = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.startShortcutComboBox2 = new System.Windows.Forms.ComboBox();
            this.stopShortcutComboBox2 = new System.Windows.Forms.ComboBox();
            this.startShortcutComboBox1 = new System.Windows.Forms.ComboBox();
            this.stopShortcutLabel = new System.Windows.Forms.Label();
            this.stopShortcutComboBox1 = new System.Windows.Forms.ComboBox();
            this.startShortcutLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.commandListBox = new System.Windows.Forms.ListBox();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.keyboardInputgroupBox = new System.Windows.Forms.GroupBox();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.mouseInputGroupBox.SuspendLayout();
            this.timeBreakGroupBox.SuspendLayout();
            this.intervalsGroupBox.SuspendLayout();
            this.ShortcutsLabel.SuspendLayout();
            this.keyboardInputgroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(612, 479);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(96, 76);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(712, 479);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(96, 76);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // inputTypeComboBox
            // 
            this.inputTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.inputTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.inputTypeComboBox.FormattingEnabled = true;
            this.inputTypeComboBox.Items.AddRange(new object[] {
            "Mouse",
            "Keyboard"});
            this.inputTypeComboBox.Location = new System.Drawing.Point(154, 19);
            this.inputTypeComboBox.Name = "inputTypeComboBox";
            this.inputTypeComboBox.Size = new System.Drawing.Size(167, 28);
            this.inputTypeComboBox.TabIndex = 6;
            this.inputTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.inputTypeComboBox_SelectedIndexChanged_1);
            // 
            // addKeyButton
            // 
            this.addKeyButton.Location = new System.Drawing.Point(327, 19);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(40, 130);
            this.addKeyButton.TabIndex = 7;
            this.addKeyButton.Text = "+";
            this.addKeyButton.UseVisualStyleBackColor = true;
            this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
            // 
            // addTimeButton
            // 
            this.addTimeButton.Location = new System.Drawing.Point(327, 40);
            this.addTimeButton.Name = "addTimeButton";
            this.addTimeButton.Size = new System.Drawing.Size(40, 28);
            this.addTimeButton.TabIndex = 8;
            this.addTimeButton.Text = "+";
            this.addTimeButton.UseVisualStyleBackColor = true;
            this.addTimeButton.Click += new System.EventHandler(this.addTimeButton_Click);
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(154, 41);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(167, 27);
            this.timeTextBox.TabIndex = 9;
            this.timeTextBox.Text = "1000";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(24, 44);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(94, 20);
            this.timeLabel.TabIndex = 10;
            this.timeLabel.Text = "Time (in ms):";
            // 
            // inputTypeLabel
            // 
            this.inputTypeLabel.AutoSize = true;
            this.inputTypeLabel.Location = new System.Drawing.Point(25, 22);
            this.inputTypeLabel.Name = "inputTypeLabel";
            this.inputTypeLabel.Size = new System.Drawing.Size(43, 20);
            this.inputTypeLabel.TabIndex = 12;
            this.inputTypeLabel.Text = "Type:";
            // 
            // mouseInputGroupBox
            // 
            this.mouseInputGroupBox.Controls.Add(this.currYDynamicLabel);
            this.mouseInputGroupBox.Controls.Add(this.currXDynamicLabel);
            this.mouseInputGroupBox.Controls.Add(this.currentYlabel);
            this.mouseInputGroupBox.Controls.Add(this.currentXlabel);
            this.mouseInputGroupBox.Controls.Add(this.repeatLabel);
            this.mouseInputGroupBox.Controls.Add(this.repeatTextBox);
            this.mouseInputGroupBox.Controls.Add(this.yLabel);
            this.mouseInputGroupBox.Controls.Add(this.inputTypeLabel);
            this.mouseInputGroupBox.Controls.Add(this.yTextBox);
            this.mouseInputGroupBox.Controls.Add(this.inputTypeComboBox);
            this.mouseInputGroupBox.Controls.Add(this.xLabel);
            this.mouseInputGroupBox.Controls.Add(this.addKeyButton);
            this.mouseInputGroupBox.Controls.Add(this.xTextBox);
            this.mouseInputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.mouseInputGroupBox.Name = "mouseInputGroupBox";
            this.mouseInputGroupBox.Size = new System.Drawing.Size(390, 168);
            this.mouseInputGroupBox.TabIndex = 13;
            this.mouseInputGroupBox.TabStop = false;
            this.mouseInputGroupBox.Text = "Mouse Input";
            // 
            // currYDynamicLabel
            // 
            this.currYDynamicLabel.AutoSize = true;
            this.currYDynamicLabel.Location = new System.Drawing.Point(262, 129);
            this.currYDynamicLabel.Name = "currYDynamicLabel";
            this.currYDynamicLabel.Size = new System.Drawing.Size(17, 20);
            this.currYDynamicLabel.TabIndex = 24;
            this.currYDynamicLabel.Text = "0";
            this.currYDynamicLabel.Visible = false;
            // 
            // currXDynamicLabel
            // 
            this.currXDynamicLabel.AutoSize = true;
            this.currXDynamicLabel.Location = new System.Drawing.Point(104, 129);
            this.currXDynamicLabel.Name = "currXDynamicLabel";
            this.currXDynamicLabel.Size = new System.Drawing.Size(17, 20);
            this.currXDynamicLabel.TabIndex = 23;
            this.currXDynamicLabel.Text = "0";
            this.currXDynamicLabel.Visible = false;
            // 
            // currentYlabel
            // 
            this.currentYlabel.AutoSize = true;
            this.currentYlabel.Location = new System.Drawing.Point(184, 129);
            this.currentYlabel.Name = "currentYlabel";
            this.currentYlabel.Size = new System.Drawing.Size(72, 20);
            this.currentYlabel.TabIndex = 22;
            this.currentYlabel.Text = "Current Y:";
            this.currentYlabel.Visible = false;
            // 
            // currentXlabel
            // 
            this.currentXlabel.AutoSize = true;
            this.currentXlabel.Location = new System.Drawing.Point(25, 129);
            this.currentXlabel.Name = "currentXlabel";
            this.currentXlabel.Size = new System.Drawing.Size(73, 20);
            this.currentXlabel.TabIndex = 21;
            this.currentXlabel.Text = "Current X:";
            this.currentXlabel.Visible = false;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(25, 55);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(59, 20);
            this.repeatLabel.TabIndex = 20;
            this.repeatLabel.Text = "Repeat:";
            // 
            // repeatTextBox
            // 
            this.repeatTextBox.Location = new System.Drawing.Point(154, 52);
            this.repeatTextBox.Name = "repeatTextBox";
            this.repeatTextBox.Size = new System.Drawing.Size(167, 27);
            this.repeatTextBox.TabIndex = 19;
            this.repeatTextBox.Text = "1";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(184, 90);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(20, 20);
            this.yLabel.TabIndex = 16;
            this.yLabel.Text = "Y:";
            this.yLabel.Visible = false;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(210, 87);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(111, 27);
            this.yTextBox.TabIndex = 15;
            this.yTextBox.Text = "0";
            this.yTextBox.Visible = false;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(25, 90);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(21, 20);
            this.xLabel.TabIndex = 14;
            this.xLabel.Text = "X:";
            this.xLabel.Visible = false;
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(52, 87);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(111, 27);
            this.xTextBox.TabIndex = 13;
            this.xTextBox.Text = "0";
            this.xTextBox.Visible = false;
            // 
            // onScreenKeyboardButton
            // 
            this.onScreenKeyboardButton.Location = new System.Drawing.Point(24, 26);
            this.onScreenKeyboardButton.Name = "onScreenKeyboardButton";
            this.onScreenKeyboardButton.Size = new System.Drawing.Size(343, 82);
            this.onScreenKeyboardButton.TabIndex = 21;
            this.onScreenKeyboardButton.Text = "Open On-Screen Keyboard";
            this.onScreenKeyboardButton.UseVisualStyleBackColor = true;
            this.onScreenKeyboardButton.Click += new System.EventHandler(this.onScreenKeyboardButton_Click);
            // 
            // timeBreakGroupBox
            // 
            this.timeBreakGroupBox.Controls.Add(this.timeLabel);
            this.timeBreakGroupBox.Controls.Add(this.addTimeButton);
            this.timeBreakGroupBox.Controls.Add(this.timeTextBox);
            this.timeBreakGroupBox.Location = new System.Drawing.Point(12, 315);
            this.timeBreakGroupBox.Name = "timeBreakGroupBox";
            this.timeBreakGroupBox.Size = new System.Drawing.Size(390, 85);
            this.timeBreakGroupBox.TabIndex = 14;
            this.timeBreakGroupBox.TabStop = false;
            this.timeBreakGroupBox.Text = "Time Break";
            // 
            // intervalsGroupBox
            // 
            this.intervalsGroupBox.Controls.Add(this.infiniteCheckBox);
            this.intervalsGroupBox.Controls.Add(this.intervalsTextBox);
            this.intervalsGroupBox.Controls.Add(this.intervalsLabel);
            this.intervalsGroupBox.Location = new System.Drawing.Point(12, 406);
            this.intervalsGroupBox.Name = "intervalsGroupBox";
            this.intervalsGroupBox.Size = new System.Drawing.Size(390, 58);
            this.intervalsGroupBox.TabIndex = 15;
            this.intervalsGroupBox.TabStop = false;
            this.intervalsGroupBox.Text = "Intervals";
            // 
            // infiniteCheckBox
            // 
            this.infiniteCheckBox.AutoSize = true;
            this.infiniteCheckBox.Location = new System.Drawing.Point(290, 23);
            this.infiniteCheckBox.Name = "infiniteCheckBox";
            this.infiniteCheckBox.Size = new System.Drawing.Size(77, 24);
            this.infiniteCheckBox.TabIndex = 14;
            this.infiniteCheckBox.Text = "Infinite";
            this.infiniteCheckBox.UseVisualStyleBackColor = true;
            this.infiniteCheckBox.CheckedChanged += new System.EventHandler(this.inifiniteCheckBox_CheckedChanged);
            // 
            // intervalsTextBox
            // 
            this.intervalsTextBox.Location = new System.Drawing.Point(154, 20);
            this.intervalsTextBox.Name = "intervalsTextBox";
            this.intervalsTextBox.Size = new System.Drawing.Size(130, 27);
            this.intervalsTextBox.TabIndex = 13;
            this.intervalsTextBox.Text = "1";
            this.intervalsTextBox.TextChanged += new System.EventHandler(this.intervalsTextBox_TextChanged);
            // 
            // intervalsLabel
            // 
            this.intervalsLabel.AutoSize = true;
            this.intervalsLabel.Location = new System.Drawing.Point(24, 23);
            this.intervalsLabel.Name = "intervalsLabel";
            this.intervalsLabel.Size = new System.Drawing.Size(67, 20);
            this.intervalsLabel.TabIndex = 11;
            this.intervalsLabel.Text = "Intervals:";
            // 
            // ShortcutsLabel
            // 
            this.ShortcutsLabel.Controls.Add(this.saveButton);
            this.ShortcutsLabel.Controls.Add(this.startShortcutComboBox2);
            this.ShortcutsLabel.Controls.Add(this.stopShortcutComboBox2);
            this.ShortcutsLabel.Controls.Add(this.startShortcutComboBox1);
            this.ShortcutsLabel.Controls.Add(this.stopShortcutLabel);
            this.ShortcutsLabel.Controls.Add(this.stopShortcutComboBox1);
            this.ShortcutsLabel.Controls.Add(this.startShortcutLabel);
            this.ShortcutsLabel.Location = new System.Drawing.Point(12, 470);
            this.ShortcutsLabel.Name = "ShortcutsLabel";
            this.ShortcutsLabel.Size = new System.Drawing.Size(390, 85);
            this.ShortcutsLabel.TabIndex = 16;
            this.ShortcutsLabel.TabStop = false;
            this.ShortcutsLabel.Text = "Shortcuts";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveButton.Location = new System.Drawing.Point(327, 20);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(40, 55);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // startShortcutComboBox2
            // 
            this.startShortcutComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.startShortcutComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.startShortcutComboBox2.FormattingEnabled = true;
            this.startShortcutComboBox2.Location = new System.Drawing.Point(241, 20);
            this.startShortcutComboBox2.Name = "startShortcutComboBox2";
            this.startShortcutComboBox2.Size = new System.Drawing.Size(80, 28);
            this.startShortcutComboBox2.TabIndex = 19;
            // 
            // stopShortcutComboBox2
            // 
            this.stopShortcutComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.stopShortcutComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.stopShortcutComboBox2.FormattingEnabled = true;
            this.stopShortcutComboBox2.Location = new System.Drawing.Point(241, 47);
            this.stopShortcutComboBox2.Name = "stopShortcutComboBox2";
            this.stopShortcutComboBox2.Size = new System.Drawing.Size(80, 28);
            this.stopShortcutComboBox2.TabIndex = 20;
            // 
            // startShortcutComboBox1
            // 
            this.startShortcutComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.startShortcutComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.startShortcutComboBox1.FormattingEnabled = true;
            this.startShortcutComboBox1.Location = new System.Drawing.Point(154, 20);
            this.startShortcutComboBox1.Name = "startShortcutComboBox1";
            this.startShortcutComboBox1.Size = new System.Drawing.Size(79, 28);
            this.startShortcutComboBox1.TabIndex = 5;
            // 
            // stopShortcutLabel
            // 
            this.stopShortcutLabel.AutoSize = true;
            this.stopShortcutLabel.Location = new System.Drawing.Point(25, 50);
            this.stopShortcutLabel.Name = "stopShortcutLabel";
            this.stopShortcutLabel.Size = new System.Drawing.Size(100, 20);
            this.stopShortcutLabel.TabIndex = 12;
            this.stopShortcutLabel.Text = "Stop shortcut:";
            // 
            // stopShortcutComboBox1
            // 
            this.stopShortcutComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.stopShortcutComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.stopShortcutComboBox1.FormattingEnabled = true;
            this.stopShortcutComboBox1.Location = new System.Drawing.Point(154, 47);
            this.stopShortcutComboBox1.Name = "stopShortcutComboBox1";
            this.stopShortcutComboBox1.Size = new System.Drawing.Size(79, 28);
            this.stopShortcutComboBox1.TabIndex = 6;
            // 
            // startShortcutLabel
            // 
            this.startShortcutLabel.AutoSize = true;
            this.startShortcutLabel.Location = new System.Drawing.Point(25, 23);
            this.startShortcutLabel.Name = "startShortcutLabel";
            this.startShortcutLabel.Size = new System.Drawing.Size(100, 20);
            this.startShortcutLabel.TabIndex = 11;
            this.startShortcutLabel.Text = "Start shortcut:";
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(510, 479);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(96, 76);
            this.exportButton.TabIndex = 18;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(408, 479);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(96, 76);
            this.importButton.TabIndex = 17;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // commandListBox
            // 
            this.commandListBox.FormattingEnabled = true;
            this.commandListBox.HorizontalScrollbar = true;
            this.commandListBox.ItemHeight = 20;
            this.commandListBox.Location = new System.Drawing.Point(408, 20);
            this.commandListBox.Name = "commandListBox";
            this.commandListBox.Size = new System.Drawing.Size(325, 444);
            this.commandListBox.TabIndex = 19;
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(737, 20);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(71, 106);
            this.moveUpButton.TabIndex = 20;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(737, 132);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(71, 106);
            this.moveDownButton.TabIndex = 23;
            this.moveDownButton.Text = "Move Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(737, 247);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(71, 106);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // keyboardInputgroupBox
            // 
            this.keyboardInputgroupBox.Controls.Add(this.onScreenKeyboardButton);
            this.keyboardInputgroupBox.Location = new System.Drawing.Point(12, 188);
            this.keyboardInputgroupBox.Name = "keyboardInputgroupBox";
            this.keyboardInputgroupBox.Size = new System.Drawing.Size(390, 121);
            this.keyboardInputgroupBox.TabIndex = 26;
            this.keyboardInputgroupBox.TabStop = false;
            this.keyboardInputgroupBox.Text = "Keyboard Input";
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(737, 359);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(71, 106);
            this.deleteAllButton.TabIndex = 27;
            this.deleteAllButton.Text = "Delete\r\nAll";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.deleteAllButton_Click);
            // 
            // AutoClickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 561);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.keyboardInputgroupBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.commandListBox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.ShortcutsLabel);
            this.Controls.Add(this.intervalsGroupBox);
            this.Controls.Add(this.timeBreakGroupBox);
            this.Controls.Add(this.mouseInputGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "AutoClickerForm";
            this.Text = "AutoClicker";
            this.mouseInputGroupBox.ResumeLayout(false);
            this.mouseInputGroupBox.PerformLayout();
            this.timeBreakGroupBox.ResumeLayout(false);
            this.timeBreakGroupBox.PerformLayout();
            this.intervalsGroupBox.ResumeLayout(false);
            this.intervalsGroupBox.PerformLayout();
            this.ShortcutsLabel.ResumeLayout(false);
            this.ShortcutsLabel.PerformLayout();
            this.keyboardInputgroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox inputTypeComboBox;
        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.Button addTimeButton;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label inputTypeLabel;
        private System.Windows.Forms.GroupBox mouseInputGroupBox;
        private System.Windows.Forms.GroupBox timeBreakGroupBox;
        private System.Windows.Forms.GroupBox intervalsGroupBox;
        private System.Windows.Forms.Label intervalsLabel;
        private System.Windows.Forms.TextBox intervalsTextBox;
        private System.Windows.Forms.CheckBox infiniteCheckBox;
        private System.Windows.Forms.GroupBox ShortcutsLabel;
        private System.Windows.Forms.ComboBox startShortcutComboBox1;
        private System.Windows.Forms.Label stopShortcutLabel;
        private System.Windows.Forms.ComboBox stopShortcutComboBox1;
        private System.Windows.Forms.Label startShortcutLabel;
        private System.Windows.Forms.ComboBox startShortcutComboBox2;
        private System.Windows.Forms.ComboBox stopShortcutComboBox2;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.ListBox commandListBox;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.TextBox repeatTextBox;
        private System.Windows.Forms.Button onScreenKeyboardButton;
        private System.Windows.Forms.GroupBox keyboardInputgroupBox;
        private System.Windows.Forms.Label currYDynamicLabel;
        private System.Windows.Forms.Label currXDynamicLabel;
        private System.Windows.Forms.Label currentYlabel;
        private System.Windows.Forms.Label currentXlabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteAllButton;
    }
}

