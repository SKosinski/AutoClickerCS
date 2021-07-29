using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoClickerCS
{
    public partial class KeyboardForm : Form
    {
        string currentKey = "q";
        CommandCreator commandCreator;
        Object disabledKey;

        Dictionary<string, string> keyNames = new Dictionary<string, string>
        {
            ["1"] = "Key1",
            ["2"] = "Key2",
            ["3"] = "Key3",
            ["4"] = "Key4",
            ["5"] = "Key5",
            ["6"] = "Key6",
            ["7"] = "Key7",
            ["8"] = "Key8",
            ["9"] = "Key9",
            ["0"] = "Key0",
            ["-"] = "MinusSign",
            ["="] = "EqualSign",
            ["["] = "OpenBracket",
            ["]"] = "CloseBracket",
            [";"] = "Semicolon",
            ["'"] = "Apostrophe",
            ["`"] = "BackwardApostrophe",
            ["\\"] = "BackwardSlash",
            [","] = "Comma",
            ["."] = "Period",
            ["/"] = "ForwardSlash",
            ["N-"] = "NumMinus",
            ["N+"] = "NumPlus",
        };

        public KeyboardForm(CommandCreator commandCreator)
        {
            InitializeComponent();

            this.commandCreator = commandCreator;

            defaultRadioButton.Checked = true;

            inputTypeComboBox.DataSource = Enum.GetValues(typeof(InputSender.KeyType));

            var addControls = Controls.Find("addKeyButton", true);
            foreach (var c in Controls)
            {
                if(c is Button)
                {
                    if( ((Button)c).Text != "Add Key")
                    {
                        ((Button)c).Click += (sender, e) =>
                        {
                            currentKey = (sender as Button).Text.ToString();

                            if (disabledKey != null)
                                ((Button)disabledKey).Enabled = true;
                            ((Button)c).Enabled = false;
                            disabledKey = c;
                            this.Select();
                            addControls[0].Focus();

                        };
                    }
                }
            }
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            string command = "";  

            if (shiftRadioButton.Checked)
            {
                command = "Keyboard KeyDown LSHIFT 1";
                commandCreator.addCommand(command);

            }
            else if (raltRadioButton.Checked)
            {
                command = "Keyboard KeyDown RALT 1";
                commandCreator.addCommand(command);
            }
            else if (lctrlRadioButton.Checked)
            {
                command = "Keyboard KeyDown LCTRL 1";
                commandCreator.addCommand(command);
            }

            string currentKeyTransfered;

            if (keyNames.TryGetValue(currentKey, out currentKeyTransfered))
            {
                command = "Keyboard " + inputTypeComboBox.SelectedItem.ToString() + " " + currentKeyTransfered;
            }
            else
            {
                command = "Keyboard " + inputTypeComboBox.SelectedItem.ToString() + " " + currentKey;
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


            if (shiftRadioButton.Checked)
            {
                command = "Keyboard KeyUp LSHIFT 1";
                commandCreator.addCommand(command);

            }
            else if (raltRadioButton.Checked)
            {
                command = "Keyboard KeyUp RALT 1";
                commandCreator.addCommand(command);
            }
            else if (lctrlRadioButton.Checked)
            {
                command = "Keyboard KeyUp LCTRL 1";
                commandCreator.addCommand(command);
            }
        }

        private void KeyboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
