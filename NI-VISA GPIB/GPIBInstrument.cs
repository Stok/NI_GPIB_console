using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.Visa;

namespace NI_VISA_GPIB
{
        public class GPIBInstrument
    { 
        GpibSession session;
        string address;

        public GPIBInstrument(String visaAddress)
        {
            this.address = visaAddress;
        }

        public string Connect()
        {
            session = new GpibSession(address);
            session.ReaddressingEnabled = true;
            session.IOProtocol = Ivi.Visa.IOProtocol.Normal;
            session.SendEndEnabled = true;
            session.TerminationCharacterEnabled = false;
            Ivi.Visa.StatusByteFlags flag = session.ReadStatusByte();
            return flag.ToString();
        }

        public void Disconnect()
        {
            session.Dispose();
        }

        public void Write(String command)
        {
            session.RawIO.Write(command);
        }

        public string Read()
        {
            return session.RawIO.ReadString();
        }

        public string Read(int numChars)
        {
            return session.RawIO.ReadString(numChars);
        }


        
    }
}

