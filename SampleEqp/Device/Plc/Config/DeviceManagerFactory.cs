﻿using SPC.Core;

namespace SampleEqp
{
    public static class DeviceManagerFactory
    {

        public static SpcDeviceManager Make()
        {
            return new SpcDeviceManager
            {
                new BitDeviceContainer(EDevice.B, 0x0400, "PLC_COMMAND", 2)
                {
                    new BitDevice { Offset = 0x000A, Key = "GlassInspLoadStart" },
                    new BitDevice { Offset = 0x000B, Key = "GlassInspLoadPause" },
                    new BitDevice { Offset = 0x000C, Key = "GlassInspLoadEnd" },

                    new BitDevice { Offset = 0x002A, Key = "UnloadStart" },
                    new BitDevice { Offset = 0x002B, Key = "UnlondPause" },
                    new BitDevice { Offset = 0x002C, Key = "UnloadEnd" },
                },

                new BitDeviceContainer(EDevice.B, 0x0300, "CIM_REPLY", 1)
                {
                    new BitDevice { Offset = 0x003A, Key = "GlassInspLoadStartReply" },
                    new BitDevice { Offset = 0x003B, Key = "GlassInspLoadPauseReply" },
                    new BitDevice { Offset = 0x003C, Key = "GlassInspLoadEndReply" },

                    new BitDevice { Offset = 0x004A, Key = "UnloadStartReply" },
                    new BitDevice { Offset = 0x004B, Key = "UnloadPauseReply" },
                    new BitDevice { Offset = 0x004C, Key = "UnloadEndReply" },
                },

                new WordDeviceContainer(EDevice.W, 0x0400, "EQP_STATUS", 3)
                {
                    new WordUShortDevice { Offset = 0x0001, Length = 1, Key = "ProcessState" }
                },

                new A3GlassDataContainer(EDevice.W, 0x0420, "LOAD_GLASS_DATA", 3),

                new A3GlassDataContainer(EDevice.W, 0x0588, "UNLOAD_GLASS_DATA", 3),

            };
        }

    }
}
