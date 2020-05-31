using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPC.Core;

namespace SPC.Test
{
    [TestClass]
    public class AttribteTest
    {
        [TestMethod]
        public void DeviceContainerAttributeTest()
        {
            var deviceContainerSample = new SampleDeviceContainer();

            Assert.AreEqual(EDevice.W, deviceContainerSample.Device);
            Assert.AreEqual(EDeviceType.Word, deviceContainerSample.DeviceType);
            Assert.AreEqual((uint)0x0010, deviceContainerSample.StartAddress);
            Assert.AreEqual("SAMPLE_WORDS", deviceContainerSample.Key);
            Assert.AreEqual("1", deviceContainerSample.ReadBlockKey);

            Assert.IsNotNull(deviceContainerSample.StringDev);
            Assert.IsNotNull(deviceContainerSample.IntDev);

            Assert.AreEqual(2, deviceContainerSample.Count);

            WordDevice dev = deviceContainerSample.StringDev;

            Assert.AreEqual(EDevice.W, dev.Device);
            Assert.AreEqual(EDeviceType.Word, dev.DeviceType);
            Assert.AreEqual((short)0x0010, dev.Address);
            Assert.AreEqual("StringDev", dev.Key);
            Assert.AreEqual((short)4, dev.Length);

            dev = deviceContainerSample.IntDev;

            Assert.AreEqual(EDevice.W, dev.Device);
            Assert.AreEqual(EDeviceType.Word, dev.DeviceType);
            Assert.AreEqual((short)0x0014, dev.Address);
            Assert.AreEqual("IntDev", dev.Key);
            Assert.AreEqual((short)2, dev.Length);
        }

        [TestMethod]
        public void DeviceArrayContainerAttributeTest()
        {
            var deviceContainerSample = new SampleDeviceContainer();

            Assert.AreEqual(EDevice.W, deviceContainerSample.Device);
            Assert.AreEqual(EDeviceType.Word, deviceContainerSample.DeviceType);
            Assert.AreEqual((uint)0x0010, deviceContainerSample.StartAddress);
            Assert.AreEqual("SAMPLE_WORDS", deviceContainerSample.Key);
            Assert.AreEqual("1", deviceContainerSample.ReadBlockKey);

            Assert.IsNotNull(deviceContainerSample.StringDev);
            Assert.IsNotNull(deviceContainerSample.IntDev);

            Assert.AreEqual(2, deviceContainerSample.Count);

            WordDevice dev = deviceContainerSample.StringDev;

            Assert.AreEqual(EDevice.W, dev.Device);
            Assert.AreEqual(EDeviceType.Word, dev.DeviceType);
            Assert.AreEqual((short)0x0010, dev.Address);
            Assert.AreEqual("StringDev", dev.Key);
            Assert.AreEqual((short)4, dev.Length);

            dev = deviceContainerSample.IntDev;

            Assert.AreEqual(EDevice.W, dev.Device);
            Assert.AreEqual(EDeviceType.Word, dev.DeviceType);
            Assert.AreEqual((short)0x0014, dev.Address);
            Assert.AreEqual("IntDev", dev.Key);
            Assert.AreEqual((short)2, dev.Length);
        }

    }
}
