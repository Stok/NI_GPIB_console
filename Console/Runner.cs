using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Console
{
    static class Runner
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Controller controller = new Controller();

            // publish the controller to the remoting system
            TcpChannel channel = new TcpChannel(1170);
            ChannelServices.RegisterChannel(channel, false);
            RemotingServices.Marshal(controller, "controller.rem");

            controller.Start();

            // the application is finishing - close down the remoting channel
            RemotingServices.Disconnect(controller);
            ChannelServices.UnregisterChannel(channel);
        }
    }
}
