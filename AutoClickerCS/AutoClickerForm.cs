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

            moveUpButton.Enabled = false;
            moveDownButton.Enabled = false;
            deleteButton.Enabled = false;

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
                //new InputSender.MouseInput
                //{
                //    dx = 100,
                //    dy = 100,
                //    dwFlags = (uint)InputSender.MouseEventF.Move

                //}
                //});


                //-----------------------
                //Thread.Sleep(1000);
                //InputSender.ClickKey(17); // W
                //-----------------------

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

                foreach (string command in commands)
                {
                    if (isCancelled)
                        return;

                    char[] separators = { ' ', ';'};

                    string[] splitCommand = command.Split(separators);

                    int repeat = 1;

                    if(splitCommand[0]!="Time") //if command = time, instruction should be executed once and then go to next instruction
                    {
                        repeat = Convert.ToInt32(splitCommand[splitCommand.Length - 1]);
                    }

                    for(int j = 0; j < repeat; j++) //number of key repeat is at the end of the string
                    {
                        switch (splitCommand[0])
                        {
                            case "Mouse":
                                switch (splitCommand[1])
                                {
                                    //fall through
                                    case "Move":
                                        InputSender.SendMouseInput(new InputSender.MouseInput[]
                                        {
                                        new InputSender.MouseInput
                                        {
                                            dx = Convert.ToInt32(splitCommand[2]),
                                            dy = Convert.ToInt32(splitCommand[3]),
                                            dwFlags = (uint)InputSender.MouseEventF.Move
                                        }
                                        });
                                        break;
                                    case "SetPosition":
                                        InputSender.SetCursorPosition(Convert.ToInt32(splitCommand[2]), Convert.ToInt32(splitCommand[3]));
                                        break;
                                    default:
                                        InputSender.MouseEventF mouseKeyCode = (InputSender.MouseEventF)Enum.Parse(typeof(InputSender.MouseEventF), splitCommand[1]);
                                        InputSender.SendMouseInput(new InputSender.MouseInput[]
                                        {
                                        new InputSender.MouseInput
                                        {
                                            dwFlags = (uint)mouseKeyCode
                                        }
                                        });
                                        break;
                                }
                                break;

                            case "Keyboard":
                                InputSender.KeyboardKeys keyboardKeyCode = (InputSender.KeyboardKeys)Enum.Parse(typeof(InputSender.KeyboardKeys), splitCommand[2]);
                                switch (splitCommand[1])
                                {
                                    case "KeyDown":
                                        InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                        {
                                                    new InputSender.KeyboardInput
                                                    {
                                                        wScan = (ushort)keyboardKeyCode,
                                                        dwFlags = (uint)(InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode),
                                                        dwExtraInfo = InputSender.GetMessageExtraInfo()
                                                    }
                                        });
                                        break;
                                    case "KeyUp":
                                        InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                        {
                                                    new InputSender.KeyboardInput
                                                    {
                                                        wScan = (ushort)keyboardKeyCode,
                                                        dwFlags = (uint)(InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode),
                                                        dwExtraInfo = InputSender.GetMessageExtraInfo()
                                                    }
                                        });

                                        break;
                                    case "Click":
                                        InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                        {
                                        new InputSender.KeyboardInput
                                        {
                                            wScan = 0xe0,
                                            dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.Scancode),
                                        },
                                        new InputSender.KeyboardInput
                                        {
                                            wScan = 0x38,
                                            dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.Scancode)
                                        }
                                        });
                                        InputSender.ClickKey((ushort)keyboardKeyCode);
                                        InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                        {
                                        new InputSender.KeyboardInput
                                        {
                                            wScan = 0xe0,
                                            dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode),
                                        },
                                        new InputSender.KeyboardInput
                                        {
                                            wScan = 0x38,
                                            dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode),
                                        }
                                        });
                                        break;
                                }
                                break;
                            case "Time":
                                Thread.Sleep(Convert.ToInt32(splitCommand[1]));
                                break;
                        }

                        if (isCancelled)
                            return;
                    }
                }
                
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
            if (IsDigitsOnly(newInterval) && newInterval != "")
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
                inputTypeComboBox.DataSource = Enum.GetValues(typeof(InputSender.KeyType));
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

            if ((sender as ComboBox).SelectedItem.ToString() == "KeyUp" || (sender as ComboBox).SelectedItem.ToString() == "KeyDown" || (sender as ComboBox).SelectedItem.ToString() == "Click")
            {
                keyLabel.Visible = true;
                keyComboBox.Visible = true;
                onScreenKeyboardButton.Visible = true;
            }
            else
            {
                keyLabel.Visible = false;
                keyComboBox.Visible = false;
                onScreenKeyboardButton.Visible = false;
            }
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            string command = "";

            command += inputDeviceComboBox.SelectedItem.ToString() + " " + inputTypeComboBox.SelectedItem.ToString();

            if (inputTypeComboBox.SelectedItem.ToString() == "Move" || inputTypeComboBox.SelectedItem.ToString() == "SetPosition")
            {
                command += " " + xTextBox.Text.ToString() + " " + yTextBox.Text.ToString();
            }
            else if (inputTypeComboBox.SelectedItem.ToString() == "KeyUp" || inputTypeComboBox.SelectedItem.ToString() == "KeyDown" || inputTypeComboBox.SelectedItem.ToString() == "Click")
            {
                command += " " + keyComboBox.SelectedItem.ToString();
            }

            if (IsDigitsOnly(repeatTextBox.Text.ToString()) && repeatTextBox.Text.ToString() != "")
            {
                command += " " + repeatTextBox.Text.ToString();
            }
            else
            {
                command += " " + 1;
            }


            commands.Add(command);
            refresh_commandListBox();

        }

        private void addTimeButton_Click(object sender, EventArgs e)
        {
            string command = "Time " + timeTextBox.Text.ToString();
            commands.Add(command);
            refresh_commandListBox();
        }

        private void refresh_commandListBox()
        {
            commandListBox.Items.Clear();
            foreach(string command in commands)
            {
                commandListBox.Items.Add(command);
            }

            if(commands.Count>1)
            {
                moveUpButton.Enabled = true;
                moveDownButton.Enabled = true;
            }
            else
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
            }

            if (commands.Count > 0)
            {
                deleteButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = false;
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
            commandListBox.SelectedIndex = index - 1;
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
            commandListBox.SelectedIndex = index + 1;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int index = commandListBox.SelectedIndex;
            commands.RemoveAt(index);
            refresh_commandListBox();
        }

        private void onScreenKeyboardButton_Click(object sender, EventArgs e)
        {
            KeyboardForm keyboardForm = new KeyboardForm();
            keyboardForm.ShowDialog();
        }
    }
}
