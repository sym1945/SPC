using SPC.Core;

namespace SampleEqp
{
    public class A3GlassDataContainer : WordDeviceContainer
    {
        [SpcDevice(0x0000, length:8)]
        public WordStringDevice HPanelId { get; private set; }

        [SpcDevice(0x0008, length: 8)]
        public WordStringDevice EPanelId { get; private set; }

        [SpcDevice(0x0010, length: 8)]
        public WordStringDevice LotId { get; private set; }

        [SpcDevice(0x0018, length: 8)]
        public WordStringDevice BatchId { get; private set; }

        [SpcDevice(0x0020, length: 8)]
        public WordStringDevice JobId { get; private set; }

        [SpcDevice(0x0028, length: 2)]
        public WordStringDevice PortId { get; private set; }

        [SpcDevice(0x002A, length: 1)]
        public WordStringDevice SlotId { get; private set; }

        [SpcDevice(0x002B, length: 2)]
        public WordStringDevice ProductType { get; private set; }

        [SpcDevice(0x002D, length: 2)]
        public WordStringDevice ProductKind { get; private set; }

        [SpcDevice(0x002F, length: 8)]
        public WordStringDevice ProductId { get; private set; }

        [SpcDevice(0x0037, length: 8)]
        public WordStringDevice RunspecId { get; private set; }

        [SpcDevice(0x003F, length: 4)]
        public WordStringDevice LayerId { get; private set; }

        [SpcDevice(0x0043, length: 4)]
        public WordStringDevice StepId { get; private set; }

        [SpcDevice(0x0047, length: 10)]
        public WordStringDevice Ppid { get; private set; }

        [SpcDevice(0x0051, length: 10)]
        public WordStringDevice FlowId { get; private set; }

        [SpcDevice(0x005B)]
        public WordUShortDevice GlassSize { get; private set; }

        [SpcDevice(0x005D)]
        public WordUShortDevice GlassThickness { get; private set; }

        [SpcDevice(0x005E)]
        public WordUShortDevice GlassState { get; private set; }

        [SpcDevice(0x005F, length: 2)]
        public WordStringDevice GlassOrder { get; private set; }

        [SpcDevice(0x0061, length: 8)]
        public WordStringDevice Comment { get; private set; }

        [SpcDevice(0x0069, length: 2)]
        public WordStringDevice UseCount { get; private set; }

        [SpcDevice(0x006B, length: 2)]
        public WordStringDevice Judgement { get; private set; }

        [SpcDevice(0x006D, length: 2)]
        public WordStringDevice ReasonCode { get; private set; }

        [SpcDevice(0x006F, length: 1)]
        public WordStringDevice InsFlag { get; private set; }

        [SpcDevice(0x0070, length: 1)]
        public WordStringDevice EncFlag { get; private set; }

        [SpcDevice(0x0071, length: 1)]
        public WordStringDevice PreRunFlag { get; private set; }

        [SpcDevice(0x0072, length: 1)]
        public WordStringDevice TurnDir { get; private set; }

        [SpcDevice(0x0073, length: 1)]
        public WordStringDevice FlipState { get; private set; }

        [SpcDevice(0x0074, length: 2)]
        public WordStringDevice WorkState { get; private set; }

        [SpcDevice(0x0076, length: 8)]
        public WordStringDevice MultiUse { get; private set; }

        [SpcDevice(0x007E, length: 8)]
        public WordStringDevice PairGlassId { get; private set; }

        [SpcDevice(0x0086, length: 10)]
        public WordStringDevice PairPpid { get; private set; }

        [SpcDevice(0x0090, length: 20)]
        public WordStringDevice OptionName1 { get; private set; }

        [SpcDevice(0x00A4, length: 20)]
        public WordStringDevice OptionValue1 { get; private set; }

        [SpcDevice(0x00B8, length: 20)]
        public WordStringDevice OptionName2 { get; private set; }

        [SpcDevice(0x00CC, length: 20)]
        public WordStringDevice OptionValue2 { get; private set; }

        [SpcDevice(0x00E0, length: 20)]
        public WordStringDevice OptionName3 { get; private set; }

        [SpcDevice(0x00F4, length: 20)]
        public WordStringDevice OptionValue3 { get; private set; }

        [SpcDevice(0x0108, length: 20)]
        public WordStringDevice OptionName4 { get; private set; }

        [SpcDevice(0x011C, length: 20)]
        public WordStringDevice OptionValue4 { get; private set; }

        [SpcDevice(0x0130, length: 20)]
        public WordStringDevice OptionName5 { get; private set; }

        [SpcDevice(0x0144, length: 20)]
        public WordStringDevice OptionValue5 { get; private set; }

        [SpcDevice(0x0158)]
        public WordUIntDevice CSIF { get; private set; }

        [SpcDevice(0x015A)]
        public WordUIntDevice AS { get; private set; }
        [SpcDevice(0x015C)]
        public WordUIntDevice APS { get; private set; }
        [SpcDevice(0x015E)]
        public WordUIntDevice UniqueId { get; private set; }
        [SpcDevice(0x0160)]
        public WordUIntDevice BitSignal { get; private set; }


        public A3GlassDataContainer()
        {
        }

    }
}
