using SPC.Core;

namespace SampleEqp
{
    public class A3GlassDataContainer : WordDeviceContainer
    {
        public string HPanelId
        {
            get => this[nameof(HPanelId)].AsString().Value;
            set => this[nameof(HPanelId)].AsString().Value = value;
        }

        public string EPanelId
        {
            get => this[nameof(EPanelId)].AsString().Value;
            set => this[nameof(EPanelId)].AsString().Value = value;
        }

        public string LotId
        {
            get => this[nameof(LotId)].AsString().Value;
            set => this[nameof(LotId)].AsString().Value = value;
        }

        public string BatchId
        {
            get => this[nameof(BatchId)].AsString().Value;
            set => this[nameof(BatchId)].AsString().Value = value;
        }

        public string JobId
        {
            get => this[nameof(JobId)].AsString().Value;
            set => this[nameof(JobId)].AsString().Value = value;
        }

        public string PortId
        {
            get => this[nameof(PortId)].AsString().Value;
            set => this[nameof(PortId)].AsString().Value = value;
        }

        public string SlotId
        {
            get => this[nameof(SlotId)].AsString().Value;
            set => this[nameof(SlotId)].AsString().Value = value;
        }

        public string ProductType
        {
            get => this[nameof(ProductType)].AsString().Value;
            set => this[nameof(ProductType)].AsString().Value = value;
        }

        public string ProductKind
        {
            get => this[nameof(ProductKind)].AsString().Value;
            set => this[nameof(ProductKind)].AsString().Value = value;
        }

        public string ProductId
        {
            get => this[nameof(ProductId)].AsString().Value;
            set => this[nameof(ProductId)].AsString().Value = value;
        }

        public string RunspecId
        {
            get => this[nameof(RunspecId)].AsString().Value;
            set => this[nameof(RunspecId)].AsString().Value = value;
        }

        public string LayerId
        {
            get => this[nameof(LayerId)].AsString().Value;
            set => this[nameof(LayerId)].AsString().Value = value;
        }

        public string StepId
        {
            get => this[nameof(StepId)].AsString().Value;
            set => this[nameof(StepId)].AsString().Value = value;
        }

        public string Ppid
        {
            get => this[nameof(Ppid)].AsString().Value;
            set => this[nameof(Ppid)].AsString().Value = value;
        }

        public string FlowId
        {
            get => this[nameof(FlowId)].AsString().Value;
            set => this[nameof(FlowId)].AsString().Value = value;
        }

        public ushort GlassSize
        {
            get => this[nameof(GlassSize)].AsUShort().Value;
            set => this[nameof(GlassSize)].AsUShort().Value = value;
        }

        public ushort GlassThickness
        {
            get => this[nameof(GlassThickness)].AsUShort().Value;
            set => this[nameof(GlassThickness)].AsUShort().Value = value;
        }

        public ushort GlassState
        {
            get => this[nameof(GlassState)].AsUShort().Value;
            set => this[nameof(GlassState)].AsUShort().Value = value;
        }

        public string GlassOrder
        {
            get => this[nameof(GlassOrder)].AsString().Value;
            set => this[nameof(GlassOrder)].AsString().Value = value;
        }

        public string Comment
        {
            get => this[nameof(Comment)].AsString().Value;
            set => this[nameof(Comment)].AsString().Value = value;
        }

        public string UseCount
        {
            get => this[nameof(UseCount)].AsString().Value;
            set => this[nameof(UseCount)].AsString().Value = value;
        }

        public string Judgement
        {
            get => this[nameof(Judgement)].AsString().Value;
            set => this[nameof(Judgement)].AsString().Value = value;
        }

        public string ReasonCode
        {
            get => this[nameof(ReasonCode)].AsString().Value;
            set => this[nameof(ReasonCode)].AsString().Value = value;
        }

        public string InsFlag
        {
            get => this[nameof(InsFlag)].AsString().Value;
            set => this[nameof(InsFlag)].AsString().Value = value;
        }

        public string EncFlag
        {
            get => this[nameof(EncFlag)].AsString().Value;
            set => this[nameof(EncFlag)].AsString().Value = value;
        }

        public string PreRunFlag
        {
            get => this[nameof(PreRunFlag)].AsString().Value;
            set => this[nameof(PreRunFlag)].AsString().Value = value;
        }

        public string TurnDir
        {
            get => this[nameof(TurnDir)].AsString().Value;
            set => this[nameof(TurnDir)].AsString().Value = value;
        }

        public string FlipState
        {
            get => this[nameof(FlipState)].AsString().Value;
            set => this[nameof(FlipState)].AsString().Value = value;
        }

        public string WorkState
        {
            get => this[nameof(WorkState)].AsString().Value;
            set => this[nameof(WorkState)].AsString().Value = value;
        }

        public string MultiUse
        {
            get => this[nameof(MultiUse)].AsString().Value;
            set => this[nameof(MultiUse)].AsString().Value = value;
        }

        public string PairGlassId
        {
            get => this[nameof(PairGlassId)].AsString().Value;
            set => this[nameof(PairGlassId)].AsString().Value = value;
        }

        public string PairPpid
        {
            get => this[nameof(PairPpid)].AsString().Value;
            set => this[nameof(PairPpid)].AsString().Value = value;
        }

        public string OptionName1
        {
            get => this[nameof(OptionName1)].AsString().Value;
            set => this[nameof(OptionName1)].AsString().Value = value;
        }

        public string OptionValue1
        {
            get => this[nameof(OptionValue1)].AsString().Value;
            set => this[nameof(OptionValue1)].AsString().Value = value;
        }

        public string OptionName2
        {
            get => this[nameof(OptionName2)].AsString().Value;
            set => this[nameof(OptionName2)].AsString().Value = value;
        }

        public string OptionValue2
        {
            get => this[nameof(OptionValue2)].AsString().Value;
            set => this[nameof(OptionValue2)].AsString().Value = value;
        }

        public string OptionName3
        {
            get => this[nameof(OptionName3)].AsString().Value;
            set => this[nameof(OptionName3)].AsString().Value = value;
        }

        public string OptionValue3
        {
            get => this[nameof(OptionValue3)].AsString().Value;
            set => this[nameof(OptionValue3)].AsString().Value = value;
        }

        public string OptionName4
        {
            get => this[nameof(OptionName4)].AsString().Value;
            set => this[nameof(OptionName4)].AsString().Value = value;
        }

        public string OptionValue4
        {
            get => this[nameof(OptionValue4)].AsString().Value;
            set => this[nameof(OptionValue4)].AsString().Value = value;
        }

        public string OptionName5
        {
            get => this[nameof(OptionName5)].AsString().Value;
            set => this[nameof(OptionName5)].AsString().Value = value;
        }

        public string OptionValue5
        {
            get => this[nameof(OptionValue5)].AsString().Value;
            set => this[nameof(OptionValue5)].AsString().Value = value;
        }

        public ushort CSIF
        {
            get => this[nameof(CSIF)].AsUShort().Value;
            set => this[nameof(CSIF)].AsUShort().Value = value;
        }

        public ushort AS
        {
            get => this[nameof(AS)].AsUShort().Value;
            set => this[nameof(AS)].AsUShort().Value = value;
        }

        public ushort APS
        {
            get => this[nameof(APS)].AsUShort().Value;
            set => this[nameof(APS)].AsUShort().Value = value;
        }

        public ushort UniqueId
        {
            get => this[nameof(UniqueId)].AsUShort().Value;
            set => this[nameof(UniqueId)].AsUShort().Value = value;
        }

        public ushort BitSignal
        {
            get => this[nameof(BitSignal)].AsUShort().Value;
            set => this[nameof(BitSignal)].AsUShort().Value = value;
        }




        public A3GlassDataContainer(eDevice device, short startAddress, string key, int readBlockKey) 
            : base(device, startAddress, key, readBlockKey)
        {
            Add(new WordStringDevice { Offset = 0x0000, Length = 8, Key = nameof(HPanelId) });
            Add(new WordStringDevice { Offset = 0x0008, Length = 8, Key = nameof(EPanelId) });
            Add(new WordStringDevice { Offset = 0x0010, Length = 8, Key = nameof(LotId) });
            Add(new WordStringDevice { Offset = 0x0018, Length = 8, Key = nameof(BatchId) });
            Add(new WordStringDevice { Offset = 0x0020, Length = 8, Key = nameof(JobId) });
            Add(new WordStringDevice { Offset = 0x0028, Length = 2, Key = nameof(PortId) });
            Add(new WordStringDevice { Offset = 0x002A, Length = 1, Key = nameof(SlotId) });
            Add(new WordStringDevice { Offset = 0x002B, Length = 2, Key = nameof(ProductType) });
            Add(new WordStringDevice { Offset = 0x002D, Length = 2, Key = nameof(ProductKind) });
            Add(new WordStringDevice { Offset = 0x002F, Length = 8, Key = nameof(ProductId) });
            Add(new WordStringDevice { Offset = 0x0037, Length = 8, Key = nameof(RunspecId) });
            Add(new WordStringDevice { Offset = 0x003F, Length = 4, Key = nameof(LayerId) });
            Add(new WordStringDevice { Offset = 0x0043, Length = 4, Key = nameof(StepId) });
            Add(new WordStringDevice { Offset = 0x0047, Length = 10, Key = nameof(Ppid) });
            Add(new WordStringDevice { Offset = 0x0051, Length = 10, Key = nameof(FlowId) });
            Add(new WordUShortDevice { Offset = 0x005B, Length = 2, Key = nameof(GlassSize) });
            Add(new WordUShortDevice { Offset = 0x005D, Length = 1, Key = nameof(GlassThickness) });
            Add(new WordUShortDevice { Offset = 0x005E, Length = 1, Key = nameof(GlassState) });
            Add(new WordStringDevice { Offset = 0x005F, Length = 2, Key = nameof(GlassOrder) });
            Add(new WordStringDevice { Offset = 0x0061, Length = 8, Key = nameof(Comment) });
            Add(new WordStringDevice { Offset = 0x0069, Length = 2, Key = nameof(UseCount) });
            Add(new WordStringDevice { Offset = 0x006B, Length = 2, Key = nameof(Judgement) });
            Add(new WordStringDevice { Offset = 0x006D, Length = 2, Key = nameof(ReasonCode) });
            Add(new WordStringDevice { Offset = 0x006F, Length = 1, Key = nameof(InsFlag) });
            Add(new WordStringDevice { Offset = 0x0070, Length = 1, Key = nameof(EncFlag) });
            Add(new WordStringDevice { Offset = 0x0071, Length = 1, Key = nameof(PreRunFlag) });
            Add(new WordStringDevice { Offset = 0x0072, Length = 1, Key = nameof(TurnDir) });
            Add(new WordStringDevice { Offset = 0x0073, Length = 1, Key = nameof(FlipState) });
            Add(new WordStringDevice { Offset = 0x0074, Length = 2, Key = nameof(WorkState) });
            Add(new WordStringDevice { Offset = 0x0076, Length = 8, Key = nameof(MultiUse) });
            Add(new WordStringDevice { Offset = 0x007E, Length = 8, Key = nameof(PairGlassId) });
            Add(new WordStringDevice { Offset = 0x0086, Length = 10, Key = nameof(PairPpid) });
            Add(new WordStringDevice { Offset = 0x0090, Length = 20, Key = nameof(OptionName1) });
            Add(new WordStringDevice { Offset = 0x00A4, Length = 20, Key = nameof(OptionValue1) });
            Add(new WordStringDevice { Offset = 0x00B8, Length = 20, Key = nameof(OptionName2) });
            Add(new WordStringDevice { Offset = 0x00CC, Length = 20, Key = nameof(OptionValue2) });
            Add(new WordStringDevice { Offset = 0x00E0, Length = 20, Key = nameof(OptionName3) });
            Add(new WordStringDevice { Offset = 0x00F4, Length = 20, Key = nameof(OptionValue3) });
            Add(new WordStringDevice { Offset = 0x0108, Length = 20, Key = nameof(OptionName4) });
            Add(new WordStringDevice { Offset = 0x011C, Length = 20, Key = nameof(OptionValue4) });
            Add(new WordStringDevice { Offset = 0x0130, Length = 20, Key = nameof(OptionName5) });
            Add(new WordStringDevice { Offset = 0x0144, Length = 20, Key = nameof(OptionValue5) });
            Add(new WordUShortDevice { Offset = 0x0158, Length = 2, Key = nameof(CSIF) });
            Add(new WordUShortDevice { Offset = 0x015A, Length = 2, Key = nameof(AS) });
            Add(new WordUShortDevice { Offset = 0x015C, Length = 2, Key = nameof(APS) });
            Add(new WordUShortDevice { Offset = 0x015E, Length = 2, Key = nameof(UniqueId) });
            Add(new WordUShortDevice { Offset = 0x0160, Length = 2, Key = nameof(BitSignal) });
        }



    }
}
