using System;
using System.Collections.Generic;
using System.Text;

namespace RS485Light
{
    public interface ILedWebService
    {
        bool SendData(byte Address, byte Intensity, byte Data);
    }
}
