using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class WordDevice : DeviceBase
    {
        private short[] Buffer;

        public short Length { get; set; }

        public WordDeviceValue Value { get; set; }

        protected override PlcWriteInfo MakeWriteInfo()
        {
            return new WordWriteInfo
            {
                Device = Device,
                Address = Address,
                Size = Length,
                Value = new short[0]
            };
        }

    }
}
