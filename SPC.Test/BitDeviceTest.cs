using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPC.Core;

namespace SPC.Test
{
    [TestClass]
    public class BitDeviceTest
    {
        [TestMethod]
        public async Task WaitBitTestResultNotChange()
        {
            var bitDev = new BitDevice();

            var result = await bitDev.WaitBitAsync(true, 2000);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task WaitBitTestResultChange()
        {
            var bitDev = new BitDevice();

            Task.Run(async () =>
            {
                await Task.Delay(1000);
                bitDev.UpdateValue(true);
            }).DoNotAwait();

            var result = await bitDev.WaitBitAsync(true, 2000);

            Assert.IsTrue(result);
        }
    }
}
