using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPC.Core;
using System.Collections.Generic;

namespace SPC.Test
{
    [TestClass]
    public class WordDevcieContainerTest
    {
        [TestMethod]
        public void BatchWriteTest()
        {
            var wordDevContainer = new WordDeviceContainer
            {
                 new WordStringDevice { Offset = 0, Length = 2, Key = "string" },
                 new WordShortDevice { Offset = 2, Length = 1, Key = "short" },
                 new WordUShortDevice { Offset = 3, Length = 1, Key = "ushort" },
                 new WordIntDevice { Offset = 4, Length = 2, Key = "int" },
                 new WordUIntDevice { Offset = 6, Length = 2, Key = "uint" },
                 new WordLongDevice { Offset = 8, Length = 4, Key = "long" },
                 new WordULongDevice { Offset = 12, Length = 4, Key = "ulong" },
                 new WordFloatDevice { Offset = 16, Length = 2, Key = "float" },
                 new WordDoubleDevice { Offset = 18, Length = 4, Key = "double" }
            };


            (wordDevContainer["string"] as WordStringDevice).Value = "ABCD";
            (wordDevContainer["short"] as WordShortDevice).Value = short.MinValue;
            (wordDevContainer["ushort"] as WordUShortDevice).Value = ushort.MaxValue;
            (wordDevContainer["int"] as WordIntDevice).Value = int.MinValue;
            (wordDevContainer["uint"] as WordUIntDevice).Value = uint.MaxValue;
            (wordDevContainer["long"] as WordLongDevice).Value = long.MinValue;
            (wordDevContainer["ulong"] as WordULongDevice).Value = ulong.MaxValue;
            (wordDevContainer["float"] as WordFloatDevice).Value = float.MinValue;
            (wordDevContainer["double"] as WordDoubleDevice).Value = double.MaxValue;


            var writeValue = DeviceContainerHelper.GetBatchWriteValues(wordDevContainer);


            List<short> expectedValue;
            unchecked
            {
                expectedValue = new List<short> 
                {
                    //string
                    0x4241,
                    0x4443,
                    //short
                    short.MinValue,
                    //ushort
                    (short)ushort.MaxValue,
                    //int
                    0x0000,
                    (short)0x8000,
                    //uint
                    (short)0xFFFF,
                    (short)0xFFFF,
                    //long
                    (short)0x0000,
                    (short)0x0000,
                    (short)0x0000,
                    (short)0x8000,
                    //ulong
                    (short)0xFFFF,
                    (short)0xFFFF,
                    (short)0xFFFF,
                    (short)0xFFFF,
                    //float
                    (short)0xFFFF,
                    (short)0xFF7F,
                    //double
                    (short)0xFFFF,
                    (short)0xFFFF,
                    (short)0xFFFF,
                    (short)0x7FEF
                };
            }


            CollectionAssert.AreEqual(expectedValue, writeValue);

        }
    }
}
