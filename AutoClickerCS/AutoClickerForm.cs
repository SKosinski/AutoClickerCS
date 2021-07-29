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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoClickerCS.HotkeyService;

namespace AutoClickerCS
{
    public partial class AutoClickerForm : Form
    {

        Thread AC;

        public int intervals = 1;

        public bool running = false;

        public CommandCreator commandCreator;

        volatile bool isCancelled = false;

        KeyboardHook hook = new KeyboardHook();

        public AutoClickerForm()
        {
            InitializeComponent();

            commandCreator = new CommandCreator(this);

            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
        }

        public void UpdateFormText(int currentInterval)
        {
            if(running)
            {
                if(infiniteCheckBox.Checked)
                {

                    this.Text = "AutoClicker (" + currentInterval.ToString() + "/∞)";
                }
                else
                {

                    this.Text = "AutoClicker (" + currentInterval.ToString() + "/" + intervals.ToString() + ")";
                }

            }
            else
            {
                this.Text = "AutoClicker";
            }
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if(e.Modifier.ToString() == startShortcutComboBox1.SelectedItem.ToString() && e.Key.ToString() == startShortcutComboBox2.SelectedItem.ToString())
            {
                Start();
            }
            else if(e.Modifier.ToString() == stopShortcutComboBox1.SelectedItem.ToString() && e.Key.ToString() == stopShortcutComboBox2.SelectedItem.ToString())
            {
                Stop();
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void timer_Tick(object sender, EventArgs e)
        {
            InputSender.POINT point = InputSender.GetCursorPosition();
            currXDynamicLabel.Text = point.X.ToString();
            currYDynamicLabel.Text = point.Y.ToString();

        }

        private void AutoClick()
        {
            int tmpIntervals = intervals;

            for(int i=0; i<intervals; i++)
            {
                if (isCancelled)
                    return;
                UpdateFormText(i + 1);
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

                foreach (string command in commandCreator.commands) //we cycle through every command
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
                                InputSender.KeyboardKeys keyboardKeyCode;
                                object obj;
                                if (!Enum.TryParse(typeof(InputSender.KeyboardKeys), splitCommand[2], true, out obj)) //if the key is not in normal enum but in special enum, we must use "extended Key" formula
                                {
                                    var specialKeyboardKeyCode = (InputSender.SpecialKeyboardKeys)Enum.Parse(typeof(InputSender.SpecialKeyboardKeys), splitCommand[2]);
                                    switch (splitCommand[1])
                                    {
                                        case "KeyDown":
                                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                            {
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = 0xe0,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode),
                                            },
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = (ushort)specialKeyboardKeyCode,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                            }
                                            });
                                            break;
                                        case "KeyUp":
                                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                            {
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = 0xe0,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode),
                                            },
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = (ushort)specialKeyboardKeyCode,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode),
                                            }
                                            });

                                            break;
                                        case "Click":
                                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                            {
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = 0xe0,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode),
                                            },
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = (ushort)specialKeyboardKeyCode,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                            }
                                            });

                                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                                            {
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = 0xe0,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode),
                                            },
                                            new InputSender.KeyboardInput
                                            {
                                                wScan = (ushort)specialKeyboardKeyCode,
                                                dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode),
                                            }
                                            });
                                            break;
                                    }
                                }
                                else
                                {
                                    keyboardKeyCode = (InputSender.KeyboardKeys)obj;
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
                                            InputSender.ClickKey((ushort)keyboardKeyCode);
                                            break;
                                    }
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

                if (infiniteCheckBox.Checked) //run forever if infinite intervals checked
                    intervals++;
                else
                {
                    intervals = tmpIntervals;
                }
            }
            Stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            if(!running)
            {
                if (isCancelled)
                    isCancelled = false;
                running = true;

                CheckForIllegalCrossThreadCalls = false;
                AC = new Thread(AutoClick);
                AC.Start();


                startButton.Enabled = false;
                stopButton.Enabled = true;
                deleteButton.Enabled = false;
                deleteAllButton.Enabled = false;
            }

        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            if (AC.IsAlive && running)
            {
                isCancelled = true;
                running = false;

                startButton.Enabled = true;
                stopButton.Enabled = false;
                deleteButton.Enabled = true;
                deleteAllButton.Enabled = true;

                UpdateFormText(0);
            }
        }

        private void intervalsTextBox_TextChanged(object sender, EventArgs e)
        {
            string newInterval = (sender as TextBox).Text;
            newInterval = newInterval.Trim();
            //int newIntervalInt = Convert.ToInt32(newInterval);
            if (Tools.IsDigitsOnly(newInterval) && newInterval != "")
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

            commandCreator.addCommand(command);

        }

        private void addTimeButton_Click(object sender, EventArgs e)
        {
            string command = "Time " + timeTextBox.Text.ToString();

            commandCreator.addCommand(command);
        }

        public void refresh_commandListBox()
        {
            commandListBox.Items.Clear();
            foreach(string command in commandCreator.commands)
            {
                commandListBox.Items.Add(command);
            }

            if(commandCreator.commands.Count>1)
            {
                moveUpButton.Enabled = true;
                moveDownButton.Enabled = true;
            }
            else
            {
                moveUpButton.Enabled = false;
                moveDownButton.Enabled = false;
            }

            if (commandCreator.commands.Count > 0)
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

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = commandListBox.SelectedIndex;

            if(commandCreator.moveCommandUp(index))
            {
                commandListBox.SelectedIndex = index - 1;
            }

        }
        private void moveDownButton_Click(object sender, EventArgs e)
        {

            int index = commandListBox.SelectedIndex;

            if (commandCreator.moveCommandDown(index))
            {
                commandListBox.SelectedIndex = index + 1;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int index = commandListBox.SelectedIndex;
            commandCreator.deleteCommand(index);
            if(index <= commandListBox.Items.Count - 1)
            {
                commandListBox.SelectedIndex = index;
            }
            else
            {
                commandListBox.SelectedIndex = index - 1;
            }
        }

        private void onScreenKeyboardButton_Click(object sender, EventArgs e)
        {
            KeyboardForm keyboardForm = new KeyboardForm(commandCreator);
            keyboardForm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateHotkeys();
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
                    commandCreator.importCommandsFromTxt(Path.GetFullPath(openFileDialog.FileName));
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                commandCreator.exportCommandsToTxt(Path.GetFullPath(saveFileDialog1.FileName));
            }

        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            if(commandCreator.commands.Count > 0)
            {
                commandCreator.commands.Clear();
            }
            refresh_commandListBox();
        }
    }
}
