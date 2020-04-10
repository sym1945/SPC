using SPC.Core;

namespace SampleEqp
{
    public class A3GlassDataContainer : WordDeviceContainer
    {
        


        public A3GlassDataContainer(eDevice device, short startAddress, string key, int readBlockKey) 
            : base(device, startAddress, key, readBlockKey)
        {
            Add(new WordStringDevice { Offset = 0x0000, Length = 8, Key = "HPanelId" });
            Add(new WordStringDevice { Offset = 0x0008, Length = 8, Key = "EPanelId" });
            Add(new WordStringDevice { Offset = 0x0010, Length = 8, Key = "LotId" });
            Add(new WordStringDevice { Offset = 0x0018, Length = 8, Key = "BatchId" });
            Add(new WordStringDevice { Offset = 0x0020, Length = 8, Key = "JobId" });
            Add(new WordStringDevice { Offset = 0x0028, Length = 2, Key = "PortId" });
            Add(new WordStringDevice { Offset = 0x002A, Length = 1, Key = "SlotId" });
            Add(new WordStringDevice { Offset = 0x002B, Length = 2, Key = "ProductType" });
            Add(new WordStringDevice { Offset = 0x002D, Length = 2, Key = "ProductKind" });
            Add(new WordStringDevice { Offset = 0x002F, Length = 8, Key = "ProductId" });
            Add(new WordStringDevice { Offset = 0x0037, Length = 8, Key = "RunspecId" });
            Add(new WordStringDevice { Offset = 0x003F, Length = 4, Key = "LayerId" });
            Add(new WordStringDevice { Offset = 0x0043, Length = 4, Key = "StepId" });
            Add(new WordStringDevice { Offset = 0x0047, Length = 10, Key = "Ppid" });
            Add(new WordStringDevice { Offset = 0x0051, Length = 10, Key = "FlowId" });
            Add(new WordUShortDevice { Offset = 0x005B, Length = 2, Key = "GlassSize" });
            Add(new WordUShortDevice { Offset = 0x005D, Length = 1, Key = "GlassThickness" });
            Add(new WordUShortDevice { Offset = 0x005E, Length = 1, Key = "GlassState" });
            Add(new WordStringDevice { Offset = 0x005F, Length = 2, Key = "GlassOrder" });
            Add(new WordStringDevice { Offset = 0x0061, Length = 8, Key = "Comment" });
            Add(new WordStringDevice { Offset = 0x0069, Length = 2, Key = "UseCount" });
            Add(new WordStringDevice { Offset = 0x006B, Length = 2, Key = "Judgement" });
            Add(new WordStringDevice { Offset = 0x006D, Length = 2, Key = "ReasonCode" });
            Add(new WordStringDevice { Offset = 0x006F, Length = 1, Key = "InsFlag" });
            Add(new WordStringDevice { Offset = 0x0070, Length = 1, Key = "EncFlag" });
            Add(new WordStringDevice { Offset = 0x0071, Length = 1, Key = "PreRunFlag" });
            Add(new WordStringDevice { Offset = 0x0072, Length = 1, Key = "TurnDir" });
            Add(new WordStringDevice { Offset = 0x0073, Length = 1, Key = "FlipState" });
            Add(new WordStringDevice { Offset = 0x0074, Length = 2, Key = "WorkState" });
            Add(new WordStringDevice { Offset = 0x0076, Length = 8, Key = "MultiUse" });
            Add(new WordStringDevice { Offset = 0x007E, Length = 8, Key = "PairGlassId" });
            Add(new WordStringDevice { Offset = 0x0086, Length = 10, Key = "PairPpid" });
            Add(new WordStringDevice { Offset = 0x0090, Length = 20, Key = "OptionName1" });
            Add(new WordStringDevice { Offset = 0x00A4, Length = 20, Key = "OptionValue1" });
            Add(new WordStringDevice { Offset = 0x00B8, Length = 20, Key = "OptionName2" });
            Add(new WordStringDevice { Offset = 0x00CC, Length = 20, Key = "OptionValue2" });
            Add(new WordStringDevice { Offset = 0x00E0, Length = 20, Key = "OptionName3" });
            Add(new WordStringDevice { Offset = 0x00F4, Length = 20, Key = "OptionValue3" });
            Add(new WordStringDevice { Offset = 0x0108, Length = 20, Key = "OptionName4" });
            Add(new WordStringDevice { Offset = 0x011C, Length = 20, Key = "OptionValue4" });
            Add(new WordStringDevice { Offset = 0x0130, Length = 20, Key = "OptionName5" });
            Add(new WordStringDevice { Offset = 0x0144, Length = 20, Key = "OptionValue5" });
            Add(new WordUShortDevice { Offset = 0x0158, Length = 2, Key = "CSIF" });
            Add(new WordUShortDevice { Offset = 0x015A, Length = 2, Key = "AS" });
            Add(new WordUShortDevice { Offset = 0x015C, Length = 2, Key = "APS" });
            Add(new WordUShortDevice { Offset = 0x015E, Length = 2, Key = "UniqueId" });
            Add(new WordUShortDevice { Offset = 0x0160, Length = 2, Key = "BitSignal" });
            Add(new WordUShortDevice { Offset = 0x0162, Length = 6, Key = "Reserved" });
        }
    }
}
