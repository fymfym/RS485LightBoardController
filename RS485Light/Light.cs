using System;
using System.Collections.Generic;

namespace RS485Light
{
    public class Light
    {
        ILedWebService _webService;
        const byte ADDRESSOFFSET = 16;

        public enum ELedRings
        {
            Inner = 16,
            Midle = 32,
            Outer = 64,
            Corner = 128
        }

        public enum E7SegmentsDigit
        {
            Digit1,
            Digit2
        }

        public enum E7SegmentSegments
        {
            SegmentA = 0,
            SegmentB = 1,
            SegmentC = 2,
            SegmentD = 3,
            SegmentE = 4,
            SegmentF = 5,
            SegmentG = 6
        }

        public Light(ILedWebService WebService)
        {
            _webService = WebService;
        }

        /// <summary>
        /// Write a number on the intended 7 Segment
        /// 0-99 Write the numbers in the 7-segment
        /// 100 Write 00 in 7-Segment
        /// </summary>
        /// <param name="Address">Address of the print</param>
        /// <param name="Intensity">Intensity for all segments between 0 and 240</param>
        /// <param name="Number">The number to write in the two digits on the print</param>
        public void WriteTwoDigits(byte Address, byte Intensity, byte Number)
        {
            if (Number < 0) throw new Exception("Number below valid value");
            if (Number > 100) throw new Exception("Number below valid value");

            SendData(Address, Intensity, ValidateData(Number));
        }

        /// <summary>
        /// Turn on the single segments
        /// </summary>
        /// <param name="Address">Address of the print</param>
        /// <param name="Digit">The digit to apply segmetn list to</param>
        /// <param name="Intensity">Intensity for all segments between 0 and 240</param>
        /// <param name="SegmentList">List of Segments to turn on</param>
        public void TurnOnSegments(byte Address, E7SegmentsDigit Digit, byte Intensity, IEnumerable<E7SegmentSegments> SegmentList)
        {
            int DataValue = 0;
            foreach (var i in SegmentList)
                DataValue += (int)i;

            DataValue = Apply7SegmentDigit(Digit, DataValue);
            SendData(Address, Intensity, ValidateData(DataValue));
        }

        /// <summary>
        /// Turn off the single segments
        /// </summary>
        /// <param name="Address">Address of the print</param>
        /// <param name="Digit">The digit to apply segmetn list to</param>
        /// <param name="Intensity">Intensity for all segments between 0 and 240</param>
        /// <param name="SegmentList">List of Segments to turn off</param>
        public void TurnOffSegments(byte Address, E7SegmentsDigit Digit, byte Intensity, IEnumerable<E7SegmentSegments> SegmentList)
        {
            var DataValue = 0;
            foreach (var i in SegmentList)
                DataValue += (int)i;
            DataValue = 0x10 + Apply7SegmentDigit(Digit, DataValue);
            SendData(Address, Intensity, ValidateData(DataValue));
        }

        /// <summary>
        /// Turn on/off a LED print
        /// </summary>
        /// <param name="Address">Address of the print</param>
        /// <param name="Intensity">Intensity for all LED rings between 0 and 240</param>
        /// <param name="LedRingList">A list of LED rings to set</param>
        public void SetLed(byte Address, byte Intensity, IEnumerable<ELedRings> LedRingList)
        {
            var DataValue = 0;
            foreach (var i in LedRingList)
                DataValue += (int)i;
            SendData(Address, Intensity, ValidateData(DataValue));
        }

        byte Apply7SegmentDigit(E7SegmentsDigit Digit, int Data)
        {
            byte data = ValidateData(Data);
            switch (Digit)
            {
                case E7SegmentsDigit.Digit1:
                    return (byte)(data + 0x80);
                case E7SegmentsDigit.Digit2:
                    return (byte)(data + 0xA0);
            }
            return 0;
        }
        byte ValidateData(int Data)
        {
            if (Data < 1) throw new Exception("Data must not be below 1");
            if (Data > 240) throw new Exception("Data must not be above 63");
            return (byte)(Data);
        }

        byte ValidateAddress(byte Address)
        {
            if (Address < 1) throw new Exception("Address must not be below 1");
            if (Address > 63) throw new Exception("Address must not be above 63");
            return (byte)(Address + ADDRESSOFFSET);
        }

        byte ValidateIntensity(byte Intensity)
        {
            if (Intensity < 1) throw new Exception("Intensity must not be below 1");
            if (Intensity > 63) throw new Exception("Intensity must not be above 63");
            return (byte)(Intensity + ADDRESSOFFSET);
        }

        void SendData(byte Address, byte Intensity, byte Data)
        {
            _webService.SendData(Address, Intensity, Data);
        }
    }
}
