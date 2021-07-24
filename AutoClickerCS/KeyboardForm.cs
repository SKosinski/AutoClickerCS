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
        List<Button> keyButtons = new List<Button>();
        public KeyboardForm()
        {
            InitializeComponent();
            foreach (var c in Controls)
            {
                if(c is Button)
                {
                    ((Button)c).Click += (sender, e) =>
                    {
                        
                    };
                }
            }
        }
    }
}
