using SPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEqp
{
    public static class DeviceManagerBuilder
    {

        public static DeviceManager Build()
        {
            return new DeviceManager
            {
                new BitDeviceContainer(eDevice.B, 0x0400, "PLC_COMMAND", 1)
                {
                    new BitDevice { Offset = 0x000A, Key = "GlassInspLoadStart" },
                    new BitDevice { Offset = 0x000B, Key = "GlassInspLoadPause" },
                    new BitDevice { Offset = 0x000C, Key = "GlassInspLoadEnd" },

                    new BitDevice { Offset = 0x002A, Key = "UnloadStart" },
                    new BitDevice { Offset = 0x002B, Key = "UnlondPause" },
                    new BitDevice { Offset = 0x002C, Key = "UnloadEnd" },
                },

                new BitDeviceContainer(eDevice.B, 0x0300, "CIM_REPLY", 2)
                {
                    new BitDevice { Offset = 0x003A, Key = "GlassInspLoadStartReply" },
                    new BitDevice { Offset = 0x003B, Key = "GlassInspLoadPauseReply" },
                    new BitDevice { Offset = 0x003C, Key = "GlassInspLoadEndReply" },

                    new BitDevice { Offset = 0x004A, Key = "UnloadStartReply" },
                    new BitDevice { Offset = 0x004B, Key = "UnloadPauseReply" },
                    new BitDevice { Offset = 0x004C, Key = "UnloadEndReply" },
                },

                new GlassDataContainer(eDevice.W, 0x0420, "LOAD_GLASS_DATA", 3),

                new GlassDataContainer(eDevice.W, 0x0588, "UNLOAD_GLASS_DATA", 3),

            };
        }

    }
}
