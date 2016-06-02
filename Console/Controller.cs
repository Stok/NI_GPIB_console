using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NI_VISA_GPIB;
using System.Threading;

namespace Console
{
    public class Controller : MarshalByRefObject
    {
        ConsoleWindow window;
        GPIBInstrument gpib;
        TCPListenerWrapper tcp;


        public Controller()
        {
            window = new ConsoleWindow(this);
            tcp = new TCPListenerWrapper(this);
        }

        public void Start()
        {
            Application.Run(window);
        }

        
        public void Quit()
        {
            DisconnectGPIBDevice();
            DisactivateRemoting();
            Application.Exit();
        }

        public void WriteToConsole(string text)
        {
            window.WriteToConsole(text);
        }

        public string ToGPIBQuery(string consoleCommand)
        {
            return GPIBCommandLookup.Convert(consoleCommand);
        }

        #region GPIB
        public void ConnectToGPIBDevice()
        {
            window.WriteToConsole("Connecting...");
            gpib = new GPIBInstrument("GPIB0::8::INSTR");
            string stb = gpib.Connect();
            window.WriteToConsole("Connected: GPIB device returned \"" + stb + "\" as a status byte.");


        }

        public void QueryGPIBDevice(string tt)
        {
            string text = ToGPIBQuery(tt);
            window.WriteToConsole("Writing \"" + text + "\" to device.");
            gpib.Write(text);
            window.WriteToConsole("Complete. Reading response:");
            string response = gpib.Read();
            window.WriteToConsole(response);

        }

        public void DisconnectGPIBDevice()
        {
            gpib.Disconnect();
        }
        #endregion
      
        #region Remoting
        internal void ActivateRemoting()
        {
            //Start listening to TCP
            tcp.Start(1791);
        }

        internal void DisactivateRemoting()
        {
            tcp.StopTCPServer();
        }
        #endregion
    }
}