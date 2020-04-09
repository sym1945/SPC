using SPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEqp
{
    public class GlassDataContainer : WordDeviceContainer
    {
        public GlassDataContainer(eDevice device, short startAddress, string key, int readBlockKey) 
            : base(device, startAddress, key, readBlockKey)
        {
            Add(new WordDevice { Offset = 0x0000, Length = 6, Key = "HPanelId" });
            Add(new WordDevice { Offset = 0x003A, Length = 1, Key = "Thinckness" });
        }
    }
}
