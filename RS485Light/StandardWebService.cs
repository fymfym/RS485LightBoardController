using System;
using System.Collections.Generic;
using System.Text;

namespace RS485Light
{
    public class StandardWebService : ILedWebService
    {
        public StandardWebService(string Host, int Port)
        {

        }

        public bool SendData(byte Address, byte Intensity, byte Data)
        {
            return true;
        }
    }
}
