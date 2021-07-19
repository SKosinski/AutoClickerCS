using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClickerCS
{
    public partial class AutoClickerForm : Form
    {

        Thread AC;

        public int intervals = 1;

        public bool running = false;

        volatile bool isCancelled = false;

        public List<string> commands = new List<string>();

        public AutoClickerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            inputDeviceComboBox.SelectedIndex = 0;

            inputTypeComboBox.DataSource = Enum.GetValues(typeof(InputSender.MouseEventF));
            keyComboBox.DataSource = Enum.GetValues(typeof(InputSender.KeyboardKeys));

        }

        private void AutoClick()
        {
            for(int i=0; i<intervals; i++)
            {
                if (isCancelled)
                    return;
                // If we want to click a special (extended) key like Volume up
                // We need to send to inputs with ExtendedKey and Scancode flags
                // First is 0xe0 and the second is the special key scancode we want
                // You can read more on that here -> https://www.win.tue.nl/~aeb/linux/kbd/scancodes-6.html#microsoft
                //InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                //{
                //new InputSender.KeyboardInput
                //{
                //    wScan = 0xe0,
                //    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.Scancode),
                //},
                //new InputSender.KeyboardInput
                //{
                //    wScan = 0x30,
                //    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.Scancode)
                //}
                //});  // Volume +

                //// Using our ClickKey wrapper to press W
                //// To see more scancodes see this site -> https://www.win.tue.nl/~aeb/linux/kbd/scancodes-1.html
                //InputSender.ClickKey(0x11); // W

                //Thread.Sleep(1000);

                //// Setting the cursor position
                //InputSender.SetCursorPosition(100, 100);

                //Thread.Sleep(1000);

                //// Getting the cursor position
                //var point = InputSender.GetCursorPosition();
                //Console.WriteLine(point.X);
                //Console.WriteLine(point.Y);

                //Thread.Sleep(1000);

                //// Setting the cursor position RELATIVE to the current position
                //InputSender.SendMouseInput(new InputSender.MouseInput[]
                //{
                //    new InputSender.MouseInput
                //    {
                //        dx = 100,
                //        dy = 100,
                //        dwFlags = (uint)InputSender.MouseEventF.Move

                //    }
                //});

                Thread.Sleep(1000);
                InputSender.ClickKey(17); // W
                //InputSender.SendMouseInput(new InputSender.MouseInput[]
                //{
                //    new InputSender.MouseInput
                //    {
                //        dwFlags = (uint)InputSender.MouseEventF.LeftDown
                //    },
                //    new InputSender.MouseInput
                //    {
                //        dwFlags = (uint)InputSender.MouseEventF.LeftUp
                //    }
                //});
                if (isCancelled)
                    return;
            }            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (isCancelled)
                isCancelled = false;

            CheckForIllegalCrossThreadCalls = false;
            AC = new Thread(AutoClick);
            AC.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if(AC.IsAlive)
            {
                isCancelled = true;
            }
        }

        private void intervalsTextBox_TextChanged(object sender, EventArgs e)
        {
            string newInterval = (sender as TextBox).Text;
            newInterval = newInterval.Trim();
            //int newIntervalInt = Convert.ToInt32(newInterval);
            if (IsDigitsOnly(newInterval))
            {
                intervals = Convert.ToInt32(newInterval);
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

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void inputTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((sender as ComboBox).SelectedItem.ToString() == "Mouse")
            {
                inputTypeComboBox.DataSource = Enum.GetValues(typeof(InputSender.MouseEventF));
            }
            else if ((sender as ComboBox).SelectedItem.ToString() == "Keyboard")
            {
                inputTypeComboBox.DataSource = Enum.GetValues(typeof(InputSender.KeyEventF));
            }

        }

        private void inputKeyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem.ToString() == "Move" || (sender as ComboBox).SelectedItem.ToString() == "SetPosition")
            {
                xLabel.Visible = true;
                xTextBox.Visible = true;

                yLabel.Visible = true;
                yTextBox.Visible = true;
            }
            else
            {
                xLabel.Visible = false;
                xTextBox.Visible = false;

                yLabel.Visible = false;
                yTextBox.Visible = false;
            }

            if ((sender as ComboBox).SelectedItem.ToString() == "KeyUp" || (sender as ComboBox).SelectedItem.ToString() == "KeyDown" || (sender as ComboBox).SelectedItem.ToString() == "ExtendedKey")
            {
                keyLabel.Visible = true;
                keyComboBox.Visible = true;
            }
            else
            {
                keyLabel.Visible = false;
                keyComboBox.Visible = false;
            }
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            string command = "";

            command += inputDeviceComboBox.SelectedItem.ToString() + ", " + inputTypeComboBox.SelectedItem.ToString();

            if (inputTypeComboBox.SelectedItem.ToString() == "Move" || inputTypeComboBox.SelectedItem.ToString() == "SetPosition")
            {
                command += ", " + xTextBox.Text.ToString() + ", " + yTextBox.Text.ToString() + ";";
            }
            else if (inputTypeComboBox.SelectedItem.ToString() == "KeyUp" || inputTypeComboBox.SelectedItem.ToString() == "KeyDown" || inputTypeComboBox.SelectedItem.ToString() == "ExtendedKey")
            {
                command += ", " + keyComboBox.SelectedItem.ToString() + ";";
            }
            else
            {
                command += ";";
            }

            commands.Add(command);
            commandListBox.Items.Add(command);

        }

        private void addTimeButton_Click(object sender, EventArgs e)
        {
            string command = "Time " + timeTextBox.Text.ToString() +"ms;";
            commands.Add(command);
            commandListBox.Items.Add(command);
        }

        private void refresh_commandListBox()
        {
            commandListBox.Items.Clear();
            foreach(string command in commands)
            {
                commandListBox.Items.Add(command);
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            string tmpString;
            int index = commandListBox.SelectedIndex;
            if (index != 0)
            {
                tmpString = commands[index - 1];
                commands[index - 1] = commands[index];
                commands[index] = tmpString;
            }
            refresh_commandListBox();
        }
        private void moveDownButton_Click(object sender, EventArgs e)
        {
            string tmpString;
            int index = commandListBox.SelectedIndex;
            if (index != commands.Count)
            {
                tmpString = commands[index + 1];
                commands[index + 1] = commands[index];
                commands[index] = tmpString;
            }
            refresh_commandListBox();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int index = commandListBox.SelectedIndex;
            commands.RemoveAt(index);
            refresh_commandListBox();
        }
    }
}
