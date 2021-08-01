using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AutoClickerCS
{
    public class CommandCreator
    {
        public List<string> commands = new List<string>();
        AutoClickerForm autoClickerForm;

        public CommandCreator(AutoClickerForm autoClickerForm)
        {
            this.autoClickerForm = autoClickerForm;
        }

        public void addCommand(string command)
        {
            commands.Add(command);
            autoClickerForm.refresh_commandListBox();
        }

        //move command up on the list
        public bool moveCommandUp(int index)
        {
            string tmpString;
            if (index != 0)
            {
                tmpString = commands[index - 1];
                commands[index - 1] = commands[index];
                commands[index] = tmpString;
                autoClickerForm.refresh_commandListBox();
                return true;
            }
            return false;
        }

        //move command down on the list
        public bool moveCommandDown(int index)
        {
            string tmpString;
            if (index != commands.Count - 1)
            {
                tmpString = commands[index + 1];
                commands[index + 1] = commands[index];
                commands[index] = tmpString;
                autoClickerForm.refresh_commandListBox();
                return true;
            }
            return false;
        }

        public void deleteCommand(int index)
        {
            if(index!=-1)
            {
                commands.RemoveAt(index);
                autoClickerForm.refresh_commandListBox();
            }
        }

        public void exportCommandsToTxt(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach(var command in commands)
                {
                    sw.WriteLine(command);
                }
            }
        }

        public void importCommandsFromTxt(string fileName)
        {
            commands.Clear();
            
            string line = "";

            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    commands.Add(line);
                }
            }

            autoClickerForm.refresh_commandListBox();
        }
    }
}
