using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoClickerCS
{
    class AutoClicker
    {
        Thread AC;

        public bool running;
        public bool cancelled;

        public int intervals = 1;

        public CommandCreator commandCreator;
        public AutoClickerForm autoClickerForm;

        public AutoClicker(AutoClickerForm autoClickerForm)
        {
            this.autoClickerForm = autoClickerForm;
            commandCreator = new CommandCreator(autoClickerForm);
        }

        //Start autoclicker
        public void Start()
        {
            if (!running)
            {
                if (cancelled)
                    cancelled = false;
                running = true;
                AC = new Thread(Run);
                AC.Start();
            }
            autoClickerForm.ChangeRunningLayout();
        }

        //stop/cancel autoclicker
        public void Stop()
        {
            if (AC.IsAlive && running)
            {
                cancelled = true;
                running = false;
            }
            autoClickerForm.ChangeRunningLayout();
        }

        //Run each command in commands list
        private void Run()
        {
            int tmpIntervals = intervals;

            for (int i = 0; i < intervals; i++)
            {
                if (cancelled)
                    return;
                autoClickerForm.UpdateFormText(i + 1);

                // More about extended keys -> https://www.win.tue.nl/~aeb/linux/kbd/scancodes-6.html#microsoft
                //// Scancodes -> https://www.win.tue.nl/~aeb/linux/kbd/scancodes-1.html

                foreach (string command in commandCreator.commands) //we cycle through every command
                {
                    if (cancelled)
                        return;

                    char[] separators = { ' ', ';' };

                    string[] splitCommand = command.Split(separators);

                    int repeat = 1;

                    if (splitCommand[0] != "Time") //if command = time, instruction should be executed once and then go to next instruction
                    {
                        repeat = Convert.ToInt32(splitCommand[splitCommand.Length - 1]);
                    }

                    for (int j = 0;  j < repeat; j++) //number of key repeat is at the end of the string
                    {
                        //Special behavior is needed for these two keys
                        if(splitCommand[1] =="PRTS")
                        {
                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                            {
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0x2a,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0x37,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                }
                            });
                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                            {
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0x2a,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0x37,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                }
                            });
                            continue;
                        }
                        else if(splitCommand[1] == "PAUS")
                        {
                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                            {
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0x46,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xc6,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyDown | InputSender.KeyEventF.Scancode)
                                }
                            });
                            InputSender.SendKeyboardInput(new InputSender.KeyboardInput[]
                            {
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0x46,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xe0,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                },
                                new InputSender.KeyboardInput
                                {
                                    wScan = 0xc6,
                                    dwFlags = (uint)(InputSender.KeyEventF.ExtendedKey | InputSender.KeyEventF.KeyUp | InputSender.KeyEventF.Scancode)
                                }
                            });
                            continue;
                        }

                        //switch based on each word of command
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

                        if (cancelled)
                            return;
                    }
                }

                if (cancelled)
                    return;

                if (autoClickerForm.CheckInfiniteIntervals()) //run forever if infinite intervals checked
                    intervals++;
                else
                {
                    intervals = tmpIntervals;
                }
            }
            Stop();
        }
    }
}
