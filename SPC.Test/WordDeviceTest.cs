using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPC.Core;

namespace SPC.Test
{
    [TestClass]
    public class WordDeviceTest
    {
        [TestMethod]
        public void WriteStringValueTest()
        {
            var wordDev = new WordStringDevice { Length = 2 };
            wordDev.Value = "ABCD";

            CollectionAssert.AreEqual(
                new short[2]
                {
                    0x4241,
                    0x4443
                },
                wordDev.WriteData);
        }

        [TestMethod]
        public void WriteShortValueTest()
        {
            var wordDev = new WordShortDevice { Length = 1 };
            wordDev.Value = short.MinValue;

            CollectionAssert.AreEqual(
                new short[1]
                {
                    short.MinValue
                },
                wordDev.WriteData);
        }

        [TestMethod]
        public void WriteUShortValueTest()
        {
            var wordDev = new WordUShortDevice { Length = 1 };
            wordDev.Value = ushort.MaxValue;

            unchecked
            {
                CollectionAssert.AreEqual(
                    new short[1]
                    {
                        (short)ushort.MaxValue
                    },
                    wordDev.WriteData);
            }
        }

        [TestMethod]
        public void WriteIntValueTest()
        {
            var wordDev = new WordIntDevice { Length = 2 };
            wordDev.Value = int.MinValue;

            unchecked
            {
                CollectionAssert.AreEqual(
                    new short[2]
                    {
                        0x0000,
                        (short)0x8000
                    },
                    wordDev.WriteData);
            }
        }

        [TestMethod]
        public void WriteUIntValueTest()
        {
            var wordDev = new WordUIntDevice { Length = 2 };
            wordDev.Value = uint.MaxValue;

            unchecked
            {
                CollectionAssert.AreEqual(
                    new short[2]
                    {
                        (short)0xFFFF,
                        (short)0xFFFF
                    },
                    wordDev.WriteData);
            }
        }

        [TestMethod]
        public void WriteLongValueTest()
        {
            var wordDev = new WordLongDevice { Length = 4 };
            wordDev.Value = long.MinValue;

            unchecked
            {
                CollectionAssert.AreEqual(
                    new short[4]
                    {
                        (short)0x0000,
                        (short)0x0000,
                        (short)0x0000,
                        (short)0x8000
                    },
                    wordDev.WriteData);
            }
        }

        [TestMethod]
        public void WriteULongValueTest()
        {
            var wordDev = new WordULongDevice { Length = 4 };
            wordDev.Value = ulong.MaxValue;

            unchecked
            {
                CollectionAssert.AreEqual(
                    new short[4]
                    {
                        (short)0xFFFF,
                        (short)0xFFFF,
                        (short)0xFFFF,
                        (short)0xFFFF
                    },
                    wordDev.WriteData);
            }
        }

        // https://gregstoll.com/~gregstoll/floattohex/
        [TestMethod]
        public void WriteFloatValueTest()
        {
            var wordDev = new WordFloatDevice { Length = 2 };
            wordDev.Value = float.MinValue;

            unchecked
            {
                CollectionAssert.AreEqual(
                    new short[2]
                    {
                        (short)0xFFFF,
                        (short)0xFF7F,
                    },
                    wordDev.WriteData);
            }
        }

        // https://gregstoll.com/~gregstoll/floattohex/
        [TestMethod]
        public void WriteDoubleValueTest()
        {
            var wordDev = new WordDoubleDevice { Length = 4 };
            wordDev.Value = double.MaxValue;

            unchecked
            {
                CollectionAssert.AreEqual(
                    new short[4]
                    {
                        (short)0xFFFF,
                        (short)0xFFFF,
                        (short)0xFFFF,
                        (short)0x7FEF,
                    },
                    wordDev.WriteData);
            }
        }



    }
}
