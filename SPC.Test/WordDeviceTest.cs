using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPC.Core;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void WriteBoolArrayValueTest()
        {
            var writeBits = new List<bool>
            {
                false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,
                true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true
            };

            var wordDev = new WordBoolArrayDevice { Length = 2 };
            wordDev.Value = writeBits;

            CollectionAssert.AreEqual(writeBits.ToShort().ToList(), wordDev.WriteData);

            wordDev.SetValue(1, true);
            writeBits[1] = true;

            wordDev.SetValue(17, false);
            writeBits[17] = false;

            CollectionAssert.AreEqual(writeBits.ToShort().ToList(), wordDev.WriteData);
        }

        [TestMethod]
        public void WriteByteArrayValueTest()
        {
            var wrtieBytes = new List<byte>
            {
                byte.MinValue, byte.MinValue,
                byte.MaxValue, byte.MaxValue
            };

            var wordDev = new WordByteArrayDevice { Length = 2 };
            wordDev.Value = wrtieBytes;

            CollectionAssert.AreEqual(wrtieBytes.ToShort().ToList(), wordDev.WriteData);

            wordDev.SetValue(1, 127);
            wrtieBytes[1] = 127;

            wordDev.SetValue(3, 95);
            wrtieBytes[3] = 95;

            CollectionAssert.AreEqual(wrtieBytes.ToShort().ToList(), wordDev.WriteData);
        }

        [TestMethod]
        public void WriteUshortArrayValueTest()
        {
            var wrtieUshorts = new List<ushort>
            {
                ushort.MinValue,
                ushort.MaxValue
            };

            var wordDev = new WordUShortArrayDevice { Length = 2 };
            wordDev.Value = wrtieUshorts;

            CollectionAssert.AreEqual(wrtieUshorts.ToShort().ToList(), wordDev.WriteData);

            wordDev.SetValue(0, 100);
            wrtieUshorts[0] = 100;

            wordDev.SetValue(1, 3000);
            wrtieUshorts[1] = 3000;

            CollectionAssert.AreEqual(wrtieUshorts.ToShort().ToList(), wordDev.WriteData);
        }

    }
}
