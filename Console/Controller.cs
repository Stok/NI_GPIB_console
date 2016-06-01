using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NI_VISA_GPIB;
using System.Threading;

namespace Console
{
    public class Controller
    {
        ConsoleWindow window;
        GPIBInstrument gpib;


        public Controller()
        {
            window = new ConsoleWindow(this);
            Application.Run(window);
        }


        internal void QueryGPIBDevice(string tt)
        {
            string text = tt + "\n";
            window.WriteToConsole("Writing \"" + text + "\" to device.");
            gpib.Write(text);
            window.WriteToConsole("Complete. Reading response:");
            string response = gpib.Read();
            window.WriteToConsole(response);

        }

        internal void ConnectToGPIBDevice()
        {
            window.WriteToConsole("Connecting...");
            gpib = new GPIBInstrument("GPIB0::8::INSTR");
            string stb = gpib.Connect();
            window.WriteToConsole("GPIB device returned \"" + stb + "\" as a status byte.");
        }

        internal void DisconnectToGPIBDevice()
        {
            gpib.Disconnect();
        }

        internal void Quit()
        {
            Application.Exit();
        }


    }
}