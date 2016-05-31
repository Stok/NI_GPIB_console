using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Console
{
    public partial class ConsoleWindow : Form
    {
        Controller controller;

        public ConsoleWindow(Controller c)
        {
            InitializeComponent();
            controller = c;
        }

        public void WriteToConsole(string text)
        {
            outputTextbox.AppendText(" >>  " + text + "\n");
        }

        private void clearConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            outputTextbox.Clear();
        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                controller.SendToGPIBDevice(inputTextBox.Text);
                inputTextBox.Text = "";
            }
        }
    }
}
