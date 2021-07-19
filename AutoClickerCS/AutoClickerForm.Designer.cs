
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
            this.inputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.inputTypeComboBox = new System.Windows.Forms.ComboBox();
            this.addKeyButton = new System.Windows.Forms.Button();
            this.addTimeButton = new System.Windows.Forms.Button();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.inputDeviceLabel = new System.Windows.Forms.Label();
            this.inputTypeLabel = new System.Windows.Forms.Label();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.keyComboBox = new System.Windows.Forms.ComboBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.timeBreakGroupBox = new System.Windows.Forms.GroupBox();
            this.intervalsGroupBox = new System.Windows.Forms.GroupBox();
            this.inifiniteCheckBox = new System.Windows.Forms.CheckBox();
            this.intervalsTextBox = new System.Windows.Forms.TextBox();
            this.intervalsLabel = new System.Windows.Forms.Label();
            this.ShortcutsLabel = new System.Windows.Forms.GroupBox();
            this.startShortcutComboBox2 = new System.Windows.Forms.ComboBox();
            this.stopShortcutComboBox2 = new System.Windows.Forms.ComboBox();
            this.plusLabel2 = new System.Windows.Forms.Label();
            this.startShortcutComboBox1 = new System.Windows.Forms.ComboBox();
            this.stopShortcutLabel = new System.Windows.Forms.Label();
            this.plusLabel1 = new System.Windows.Forms.Label();
            this.stopShortcutComboBox1 = new System.Windows.Forms.ComboBox();
            this.startShortcutLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.commandListBox = new System.Windows.Forms.ListBox();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.inputGroupBox.SuspendLayout();
            this.timeBreakGroupBox.SuspendLayout();
            this.intervalsGroupBox.SuspendLayout();
            this.ShortcutsLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(216, 393);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 51);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(312, 393);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(90, 51);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // inputDeviceComboBox
            // 
            this.inputDeviceComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.inputDeviceComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.inputDeviceComboBox.FormattingEnabled = true;
            this.inputDeviceComboBox.Items.AddRange(new object[] {
            "Mouse",
            "Keyboard"});
            this.inputDeviceComboBox.Location = new System.Drawing.Point(154, 20);
            this.inputDeviceComboBox.Name = "inputDeviceComboBox";
            this.inputDeviceComboBox.Size = new System.Drawing.Size(167, 28);
            this.inputDeviceComboBox.TabIndex = 5;
            this.inputDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.inputTypeComboBox_SelectedIndexChanged);
            // 
            // inputTypeComboBox
            // 
            this.inputTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.inputTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.inputTypeComboBox.FormattingEnabled = true;
            this.inputTypeComboBox.Items.AddRange(new object[] {
            "Mouse",
            "Keyboard"});
            this.inputTypeComboBox.Location = new System.Drawing.Point(154, 54);
            this.inputTypeComboBox.Name = "inputTypeComboBox";
            this.inputTypeComboBox.Size = new System.Drawing.Size(167, 28);
            this.inputTypeComboBox.TabIndex = 6;
            this.inputTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.inputKeyComboBox_SelectedIndexChanged);
            // 
            // addKeyButton
            // 
            this.addKeyButton.Location = new System.Drawing.Point(327, 19);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(40, 63);
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
            this.timeTextBox.Text = "10";
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
            // inputDeviceLabel
            // 
            this.inputDeviceLabel.AutoSize = true;
            this.inputDeviceLabel.Location = new System.Drawing.Point(25, 23);
            this.inputDeviceLabel.Name = "inputDeviceLabel";
            this.inputDeviceLabel.Size = new System.Drawing.Size(57, 20);
            this.inputDeviceLabel.TabIndex = 11;
            this.inputDeviceLabel.Text = "Device:";
            // 
            // inputTypeLabel
            // 
            this.inputTypeLabel.AutoSize = true;
            this.inputTypeLabel.Location = new System.Drawing.Point(25, 57);
            this.inputTypeLabel.Name = "inputTypeLabel";
            this.inputTypeLabel.Size = new System.Drawing.Size(43, 20);
            this.inputTypeLabel.TabIndex = 12;
            this.inputTypeLabel.Text = "Type:";
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.keyComboBox);
            this.inputGroupBox.Controls.Add(this.yLabel);
            this.inputGroupBox.Controls.Add(this.yTextBox);
            this.inputGroupBox.Controls.Add(this.keyLabel);
            this.inputGroupBox.Controls.Add(this.xLabel);
            this.inputGroupBox.Controls.Add(this.xTextBox);
            this.inputGroupBox.Controls.Add(this.inputDeviceComboBox);
            this.inputGroupBox.Controls.Add(this.inputTypeLabel);
            this.inputGroupBox.Controls.Add(this.inputTypeComboBox);
            this.inputGroupBox.Controls.Add(this.inputDeviceLabel);
            this.inputGroupBox.Controls.Add(this.addKeyButton);
            this.inputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(390, 129);
            this.inputGroupBox.TabIndex = 13;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input";
            // 
            // keyComboBox
            // 
            this.keyComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.keyComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.keyComboBox.FormattingEnabled = true;
            this.keyComboBox.Items.AddRange(new object[] {
            "Mouse",
            "Keyboard"});
            this.keyComboBox.Location = new System.Drawing.Point(154, 88);
            this.keyComboBox.Name = "keyComboBox";
            this.keyComboBox.Size = new System.Drawing.Size(167, 28);
            this.keyComboBox.TabIndex = 18;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(186, 96);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(20, 20);
            this.yLabel.TabIndex = 16;
            this.yLabel.Text = "Y:";
            this.yLabel.Visible = false;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(212, 93);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(111, 27);
            this.yTextBox.TabIndex = 15;
            this.yTextBox.Text = "0";
            this.yTextBox.Visible = false;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(25, 91);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(36, 20);
            this.keyLabel.TabIndex = 17;
            this.keyLabel.Text = "Key:";
            this.keyLabel.Visible = false;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(27, 96);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(21, 20);
            this.xLabel.TabIndex = 14;
            this.xLabel.Text = "X:";
            this.xLabel.Visible = false;
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(54, 93);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(111, 27);
            this.xTextBox.TabIndex = 13;
            this.xTextBox.Text = "0";
            this.xTextBox.Visible = false;
            // 
            // timeBreakGroupBox
            // 
            this.timeBreakGroupBox.Controls.Add(this.timeLabel);
            this.timeBreakGroupBox.Controls.Add(this.addTimeButton);
            this.timeBreakGroupBox.Controls.Add(this.timeTextBox);
            this.timeBreakGroupBox.Location = new System.Drawing.Point(12, 147);
            this.timeBreakGroupBox.Name = "timeBreakGroupBox";
            this.timeBreakGroupBox.Size = new System.Drawing.Size(390, 85);
            this.timeBreakGroupBox.TabIndex = 14;
            this.timeBreakGroupBox.TabStop = false;
            this.timeBreakGroupBox.Text = "Time Break";
            // 
            // intervalsGroupBox
            // 
            this.intervalsGroupBox.Controls.Add(this.inifiniteCheckBox);
            this.intervalsGroupBox.Controls.Add(this.intervalsTextBox);
            this.intervalsGroupBox.Controls.Add(this.intervalsLabel);
            this.intervalsGroupBox.Location = new System.Drawing.Point(12, 238);
            this.intervalsGroupBox.Name = "intervalsGroupBox";
            this.intervalsGroupBox.Size = new System.Drawing.Size(390, 58);
            this.intervalsGroupBox.TabIndex = 15;
            this.intervalsGroupBox.TabStop = false;
            this.intervalsGroupBox.Text = "Intervals";
            // 
            // inifiniteCheckBox
            // 
            this.inifiniteCheckBox.AutoSize = true;
            this.inifiniteCheckBox.Location = new System.Drawing.Point(290, 23);
            this.inifiniteCheckBox.Name = "inifiniteCheckBox";
            this.inifiniteCheckBox.Size = new System.Drawing.Size(77, 24);
            this.inifiniteCheckBox.TabIndex = 14;
            this.inifiniteCheckBox.Text = "Infinite";
            this.inifiniteCheckBox.UseVisualStyleBackColor = true;
            this.inifiniteCheckBox.CheckedChanged += new System.EventHandler(this.inifiniteCheckBox_CheckedChanged);
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
            this.ShortcutsLabel.Controls.Add(this.startShortcutComboBox2);
            this.ShortcutsLabel.Controls.Add(this.stopShortcutComboBox2);
            this.ShortcutsLabel.Controls.Add(this.plusLabel2);
            this.ShortcutsLabel.Controls.Add(this.startShortcutComboBox1);
            this.ShortcutsLabel.Controls.Add(this.stopShortcutLabel);
            this.ShortcutsLabel.Controls.Add(this.plusLabel1);
            this.ShortcutsLabel.Controls.Add(this.stopShortcutComboBox1);
            this.ShortcutsLabel.Controls.Add(this.startShortcutLabel);
            this.ShortcutsLabel.Location = new System.Drawing.Point(12, 302);
            this.ShortcutsLabel.Name = "ShortcutsLabel";
            this.ShortcutsLabel.Size = new System.Drawing.Size(390, 85);
            this.ShortcutsLabel.TabIndex = 16;
            this.ShortcutsLabel.TabStop = false;
            this.ShortcutsLabel.Text = "Shortcuts";
            // 
            // startShortcutComboBox2
            // 
            this.startShortcutComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.startShortcutComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.startShortcutComboBox2.FormattingEnabled = true;
            this.startShortcutComboBox2.Location = new System.Drawing.Point(276, 20);
            this.startShortcutComboBox2.Name = "startShortcutComboBox2";
            this.startShortcutComboBox2.Size = new System.Drawing.Size(91, 28);
            this.startShortcutComboBox2.TabIndex = 19;
            this.startShortcutComboBox2.Text = "shortcut";
            // 
            // stopShortcutComboBox2
            // 
            this.stopShortcutComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.stopShortcutComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.stopShortcutComboBox2.FormattingEnabled = true;
            this.stopShortcutComboBox2.Items.AddRange(new object[] {
            "Mouse",
            "Keyboard"});
            this.stopShortcutComboBox2.Location = new System.Drawing.Point(276, 47);
            this.stopShortcutComboBox2.Name = "stopShortcutComboBox2";
            this.stopShortcutComboBox2.Size = new System.Drawing.Size(91, 28);
            this.stopShortcutComboBox2.TabIndex = 20;
            this.stopShortcutComboBox2.Text = "shortcut";
            // 
            // plusLabel2
            // 
            this.plusLabel2.AutoSize = true;
            this.plusLabel2.Location = new System.Drawing.Point(251, 50);
            this.plusLabel2.Name = "plusLabel2";
            this.plusLabel2.Size = new System.Drawing.Size(19, 20);
            this.plusLabel2.TabIndex = 18;
            this.plusLabel2.Text = "+";
            // 
            // startShortcutComboBox1
            // 
            this.startShortcutComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.startShortcutComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.startShortcutComboBox1.FormattingEnabled = true;
            this.startShortcutComboBox1.Location = new System.Drawing.Point(154, 20);
            this.startShortcutComboBox1.Name = "startShortcutComboBox1";
            this.startShortcutComboBox1.Size = new System.Drawing.Size(91, 28);
            this.startShortcutComboBox1.TabIndex = 5;
            this.startShortcutComboBox1.Text = "shortcut";
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
            // plusLabel1
            // 
            this.plusLabel1.AutoSize = true;
            this.plusLabel1.Location = new System.Drawing.Point(251, 23);
            this.plusLabel1.Name = "plusLabel1";
            this.plusLabel1.Size = new System.Drawing.Size(19, 20);
            this.plusLabel1.TabIndex = 17;
            this.plusLabel1.Text = "+";
            // 
            // stopShortcutComboBox1
            // 
            this.stopShortcutComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.stopShortcutComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.stopShortcutComboBox1.FormattingEnabled = true;
            this.stopShortcutComboBox1.Items.AddRange(new object[] {
            "Mouse",
            "Keyboard"});
            this.stopShortcutComboBox1.Location = new System.Drawing.Point(154, 47);
            this.stopShortcutComboBox1.Name = "stopShortcutComboBox1";
            this.stopShortcutComboBox1.Size = new System.Drawing.Size(91, 28);
            this.stopShortcutComboBox1.TabIndex = 6;
            this.stopShortcutComboBox1.Text = "shortcut";
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
            this.exportButton.Location = new System.Drawing.Point(114, 393);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(96, 51);
            this.exportButton.TabIndex = 18;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(12, 393);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(96, 51);
            this.importButton.TabIndex = 17;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // commandListBox
            // 
            this.commandListBox.FormattingEnabled = true;
            this.commandListBox.ItemHeight = 20;
            this.commandListBox.Items.AddRange(new object[] {
            "Mouse LeftDown",
            "Keyboard KeyDown Key1",
            "Time 10ms"});
            this.commandListBox.Location = new System.Drawing.Point(408, 12);
            this.commandListBox.Name = "commandListBox";
            this.commandListBox.Size = new System.Drawing.Size(325, 304);
            this.commandListBox.TabIndex = 19;
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(739, 12);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(71, 76);
            this.moveUpButton.TabIndex = 20;
            this.moveUpButton.Text = "Move Up";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(739, 95);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(71, 76);
            this.moveDownButton.TabIndex = 23;
            this.moveDownButton.Text = "Move Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(739, 177);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(71, 76);
            this.deleteButton.TabIndex = 24;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // AutoClickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 536);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.commandListBox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.ShortcutsLabel);
            this.Controls.Add(this.intervalsGroupBox);
            this.Controls.Add(this.timeBreakGroupBox);
            this.Controls.Add(this.inputGroupBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "AutoClickerForm";
            this.Text = "AutoClicker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            this.timeBreakGroupBox.ResumeLayout(false);
            this.timeBreakGroupBox.PerformLayout();
            this.intervalsGroupBox.ResumeLayout(false);
            this.intervalsGroupBox.PerformLayout();
            this.ShortcutsLabel.ResumeLayout(false);
            this.ShortcutsLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ComboBox inputDeviceComboBox;
        private System.Windows.Forms.ComboBox inputTypeComboBox;
        private System.Windows.Forms.Button addKeyButton;
        private System.Windows.Forms.Button addTimeButton;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label inputDeviceLabel;
        private System.Windows.Forms.Label inputTypeLabel;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.GroupBox timeBreakGroupBox;
        private System.Windows.Forms.GroupBox intervalsGroupBox;
        private System.Windows.Forms.Label intervalsLabel;
        private System.Windows.Forms.TextBox intervalsTextBox;
        private System.Windows.Forms.CheckBox inifiniteCheckBox;
        private System.Windows.Forms.GroupBox ShortcutsLabel;
        private System.Windows.Forms.ComboBox startShortcutComboBox1;
        private System.Windows.Forms.Label stopShortcutLabel;
        private System.Windows.Forms.ComboBox stopShortcutComboBox1;
        private System.Windows.Forms.Label startShortcutLabel;
        private System.Windows.Forms.ComboBox startShortcutComboBox2;
        private System.Windows.Forms.ComboBox stopShortcutComboBox2;
        private System.Windows.Forms.Label plusLabel1;
        private System.Windows.Forms.Label plusLabel2;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.ComboBox keyComboBox;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.ListBox commandListBox;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button deleteButton;
    }
}

