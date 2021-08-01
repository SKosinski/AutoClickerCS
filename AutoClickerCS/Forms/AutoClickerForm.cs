using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static AutoClickerCS.HotkeyService;

namespace AutoClickerCS
{
    public partial class AutoClickerForm : Form
    {

        KeyboardHook hook = new KeyboardHook();

        AutoClicker autoClicker;

        public AutoClickerForm()
        {
            InitializeComponent();

            autoClicker = new AutoClicker(this);

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (10); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            moveUpButton.Enabled = false;
            moveDownButton.Enabled = false;
            deleteButton.Enabled = false;
            deleteAllButton.Enabled = false;
            stopButton.Enabled = false;

            inputTypeComboBox.DataSource = Enum.GetValues(typeof(InputSender.MouseEventF));

            startShortcutComboBox1.DataSource = Enum.GetValues(typeof(HotkeyService.ModifierKeys));
            startShortcutComboBox2.DataSource = Enum.GetValues(typeof(Keys));
            stopShortcutComboBox1.DataSource = Enum.GetValues(typeof(HotkeyService.ModifierKeys));
            stopShortcutComboBox2.DataSource = Enum.GetValues(typeof(Keys));
            startShortcutComboBox1.SelectedIndex = 1;
            startShortcutComboBox2.SelectedIndex = 107;


            stopShortcutComboBox1.SelectedIndex = 1;
            stopShortcutComboBox2.SelectedIndex = 108;

            UpdateHotkeys();
        }

        //Update title of the window
        public void UpdateFormText(int currentInterval)
        {
            if(autoClicker.running)
            {
                if(infiniteCheckBox.Checked)
                {

                    this.Text = "AutoClicker (" + currentInterval.ToString() + "/∞)";
                }
                else
                {

                    this.Text = "AutoClicker (" + currentInterval.ToString() + "/" + autoClicker.intervals.ToString() + ")";
                }
            }
            else
            {
                this.Text = "AutoClicker";
            }
        }

        private void inputTypeComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == "Move" || (sender as ComboBox).SelectedItem.ToString() == "SetPosition")
            {
                xLabel.Visible = true;
                xTextBox.Visible = true;

                currentXlabel.Visible = true;
                currXDynamicLabel.Visible = true;

                yLabel.Visible = true;
                yTextBox.Visible = true;

                currentYlabel.Visible = true;
                currYDynamicLabel.Visible = true;
            }
            else
            {
                xLabel.Visible = false;
                xTextBox.Visible = false;

                currentXlabel.Visible = false;
                currXDynamicLabel.Visible = false;

                yLabel.Visible = false;
                yTextBox.Visible = false;

                currentYlabel.Visible = false;
                currYDynamicLabel.Visible = false;
            }
        }

        //timer for "update"like checking current mouse pos
        private void timer_Tick(object sender, EventArgs e)
        {
            InputSender.POINT point = InputSender.GetCursorPosition();
            currXDynamicLabel.Text = point.X.ToString();
            currYDynamicLabel.Text = point.Y.ToString();
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            string command = "";

            command += "Mouse " + inputTypeComboBox.SelectedItem.ToString();

            if (inputTypeComboBox.SelectedItem.ToString() == "Move" || inputTypeComboBox.SelectedItem.ToString() == "SetPosition")
            {
                command += " " + xTextBox.Text.ToString() + " " + yTextBox.Text.ToString();
            }

            if (Tools.IsDigitsOnly(repeatTextBox.Text.ToString()) && repeatTextBox.Text.ToString() != "")
            {
                command += " " + repeatTextBox.Text.ToString();
            }
            else
            {
                command += " " + 1;
            }

            autoClicker.commandCreator.addCommand(command);
        }

        private void onScreenKeyboardButton_Click(object sender, EventArgs e)
        {
            KeyboardForm keyboardForm = new KeyboardForm(autoClicker.commandCreator);
            keyboardForm.Show();
        }

        private void addTimeButton_Click(object sender, EventArgs e)
        {
            string command = "Time " + timeTextBox.Text.ToString();

            autoClicker.commandCreator.addCommand(command);
        }

        private void intervalsTextBox_TextChanged(object sender, EventArgs e)
        {
            string newInterval = (sender as TextBox).Text;
            newInterval = newInterval.Trim();
            if (Tools.IsDigitsOnly(newInterval) && newInterval != "")
            {
                autoClicker.intervals = Convert.ToInt32(newInterval);
            }
        }

        private void inifiniteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                intervalsTextBox.Enabled = false;
            }
            else
            {
                intervalsTextBox.Enabled = true;
            }
        }

        //hotkey service
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier.ToString() == startShortcutComboBox1.SelectedItem.ToString() && e.Key.ToString() == startShortcutComboBox2.SelectedItem.ToString())
            {
                autoClicker.Start();
            }
            else if (e.Modifier.ToString() == stopShortcutComboBox1.SelectedItem.ToString() && e.Key.ToString() == stopShortcutComboBox2.SelectedItem.ToString())
            {
                autoClicker.Stop();
            }
        }

        private void UpdateHotkeys()
        {
            hook.DisposeHotkeys();

            if (startShortcutComboBox1.Items.Count != 0 && startShortcutComboBox2.Items.Count != 0)
            {
                var key1 = Enum.Parse(typeof(HotkeyService.ModifierKeys), startShortcutComboBox1.Text.ToString());
                var key2 = Enum.Parse(typeof(Keys), startShortcutComboBox2.Text.ToString());
                hook.RegisterHotKey((HotkeyService.ModifierKeys)key1, (Keys)key2);
            }

            if (stopShortcutComboBox1.Items.Count != 0 && stopShortcutComboBox2.Items.Count != 0)
            {
                var key1 = Enum.Parse(typeof(HotkeyService.ModifierKeys), stopShortcutComboBox1.Text.ToString());
                var key2 = Enum.Parse(typeof(Keys), stopShortcutComboBox2.Text.ToString());
                hook.RegisterHotKey((HotkeyService.ModifierKeys)key1, (Keys)key2);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            UpdateHotkeys();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = commandListBox.SelectedIndex;

            if(autoClicker.commandCreator.moveCommandUp(index))
            {
                commandListBox.SelectedIndex = index - 1;
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int index = commandListBox.SelectedIndex;

            if (autoClicker.commandCreator.moveCommandDown(index))
            {
                commandListBox.SelectedIndex = index + 1;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int index = commandListBox.SelectedIndex;
            autoClicker.commandCreator.deleteCommand(index);
            if(index <= commandListBox.Items.Count - 1)
            {
                commandListBox.SelectedIndex = index;
            }
            else
            {
                commandListBox.SelectedIndex = index - 1;
            }
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            if (autoClicker.commandCreator.commands.Count > 0)
            {
                autoClicker.commandCreator.commands.Clear();
            }
            refresh_commandListBox();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    autoClicker.commandCreator.importCommandsFromTxt(Path.GetFullPath(openFileDialog.FileName));
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                autoClicker.commandCreator.exportCommandsToTxt(Path.GetFullPath(saveFileDialog1.FileName));
            }
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            autoClicker.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            autoClicker.Stop();
        }

        public void ChangeRunningLayout()
        {
            if(autoClicker.running)
            {
                startButton.Enabled = false;
                stopButton.Enabled = true;
                deleteButton.Enabled = false;
                deleteAllButton.Enabled = false;
                CheckForIllegalCrossThreadCalls = false;
            }
            else
            {
                startButton.Enabled = true;
                stopButton.Enabled = false;
                deleteButton.Enabled = true;
                deleteAllButton.Enabled = true;
                UpdateFormText(0);
            }
        }

        public bool CheckInfiniteIntervals()
        {
            if (infiniteCheckBox.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //update command listBox based on command List<>
        public void refresh_commandListBox()
        {
            commandListBox.Items.Clear();
            foreach (string command in autoClicker.commandCreator.commands)
            {
                commandListBox.Items.Add(command);
            }

            if (autoClicker.commandCreator.commands.Count > 1)
            {
                moveUpButton.Enabled = true;
                moveDownButton.Enabled = true;
            }
            else
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
            }

            if (autoClicker.commandCreator.commands.Count > 0)
            {
                deleteButton.Enabled = true;
                deleteAllButton.Enabled = true;
                commandListBox.TopIndex = commandListBox.Items.Count - 1;
            }
            else
            {
                deleteButton.Enabled = false;
                deleteAllButton.Enabled = false;
            }
        }
    }
}
