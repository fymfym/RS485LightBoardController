using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RS486LightTest
{
    [TestClass]
    public class LightTest
    {
        [TestMethod]
        public void SetRoundLed()
        {
            var ws = new Helper.WebServiceStubbed();
            var x = new RS485Light.Light(ws);
            x.SetLed(1,128, new [] { RS485Light.Light.ELedRings.Inner, RS485Light.Light.ELedRings.Midle, RS485Light.Light.ELedRings.Outer});

            Assert.AreEqual(112, ws.Data);
        }

        [TestMethod]
        public void SetSquareLed()
        {
            var ws = new Helper.WebServiceStubbed();
            var x = new RS485Light.Light(ws);
            x.SetLed(1, 128, new[] { RS485Light.Light.ELedRings.Inner, RS485Light.Light.ELedRings.Midle, RS485Light.Light.ELedRings.Outer, RS485Light.Light.ELedRings.Corner });

            Assert.AreEqual(240, ws.Data);
        }

    }
}
