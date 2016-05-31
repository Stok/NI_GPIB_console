using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Console
{
    public class Controller
    {
        ConsoleWindow window;

        public Controller()
        {

        }

        public void Start()
        {
            window = new ConsoleWindow(this);
            Application.Run(window);
        }

        internal void SendToGPIBDevice(string text)
        {
            window.WriteToConsole(text);
        }
    }
}