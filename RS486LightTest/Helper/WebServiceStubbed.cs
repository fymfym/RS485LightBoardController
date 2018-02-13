using System;
using System.Collections.Generic;
using System.Text;

namespace RS486LightTest.Helper
{
    public class WebServiceStubbed : RS485Light.ILedWebService
    {
        public byte Address;
        public byte Intensity;
        public byte Data;

        public bool SendData(byte Address, byte Intensity, byte Data)
        {
            this.Address = Address;
            this.Intensity = Intensity;
            this.Data = Data;
            return true;
        }
    }
}
