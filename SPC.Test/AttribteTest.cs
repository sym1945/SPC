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
            var sampleDevContainer = new SampleDeviceContainer();

            Assert.AreEqual(2, sampleDevContainer.Count);
            Assert.AreEqual(nameof(SampleDeviceContainer), sampleDevContainer.Key);

            Assert.AreEqual(0x0001, sampleDevContainer.Int.Address);
            Assert.AreEqual(0x0003, sampleDevContainer.Short.Address);

            Assert.AreEqual(EDevice.W, sampleDevContainer.Int.Device);
            Assert.AreEqual(EDevice.W, sampleDevContainer.Short.Device);

        }

        [TestMethod]
        public void DeviceContainerAttributeTest2()
        {
            var sampleDevContainer = new SampleDeviceContainer2();

            Assert.AreEqual(2, sampleDevContainer.Count);
            Assert.AreEqual(nameof(SampleDeviceContainer2), sampleDevContainer.Key);

            Assert.AreEqual(0x0030 + 0x0001, sampleDevContainer.Int.Address);
            Assert.AreEqual(0x0030 + 0x0003, sampleDevContainer.Short.Address);

            Assert.AreEqual(EDevice.W, sampleDevContainer.Int.Device);
            Assert.AreEqual(EDevice.W, sampleDevContainer.Short.Device);
        }


        [TestMethod]
        public void WordDeviceArrayContainerAttributeTest()
        {
            var wordShortArray = new WordShortArray();

            for (int i = 0; i < wordShortArray.Count; i++)
            {
                var wordShort = wordShortArray.GetDevice(i);
                wordShort.Value = (short)i;
            }

            Assert.AreEqual(10, wordShortArray.Count);

            Assert.AreEqual(0x0010 + 9, wordShortArray.GetDevice(9).Address);

            CollectionAssert.AreEqual(
                new short[1]
                {
                    0x0009
                }
                , wordShortArray.GetDevice(9).WriteBufferData);
        }

        [TestMethod]
        public void BitDeviceArrayContainerAttributeTest()
        {
            var bitArray = new BitArray();

            Assert.AreEqual(10, bitArray.Count);

            var bit = bitArray.GetDevice(9);
            bit.UpdateValue(true);

            Assert.IsTrue(bit.Value);

            Assert.AreEqual(0x0020 + 9, bitArray.GetDevice(9).Address);
        }

    }


    [SpcDeviceArrayContainer(EDevice.W, EDeviceType.Word, 10, "1", StartAddress = 0x0010)]
    public class WordShortArray : WordDeviceArrayContainer<WordShortDevice>
    {

    }


    [SpcDeviceArrayContainer(EDevice.B, EDeviceType.Word, 10, "1", StartAddress = 0x0020)]
    public class BitArray : BitDeviceArrayContainer
    {
    }


    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, "1")]
    public class SampleDeviceContainer : WordDeviceContainer
    {
        [SpcDevice(0x0001)]
        public WordIntDevice Int { get; private set; }

        [SpcDevice(0x0003)]
        public WordShortDevice Short { get; private set; }
    }


    public class SampleDeviceContainer2 : WordDeviceContainer
    {
        [SpcDevice(0x0001)]
        public WordIntDevice Int { get; private set; }

        [SpcDevice(0x0003)]
        public WordShortDevice Short { get; private set; }

        public SampleDeviceContainer2() : base(EDevice.W, 0x0030, "1")
        {

        }
    }

}
