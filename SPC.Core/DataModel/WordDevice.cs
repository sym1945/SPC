using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class WordDevice : IDevice
    {
        private short[] Buffer;

        public eDevice Device { get; set; }

        public eDeviceType DeviceType { get; set; }

        public short Address { get; set; }

        public short Offset { get; set; }

        public string Desc { get; set; }

        public short Length { get; set; }

        public short[] Values { get; set; }

    }
}
