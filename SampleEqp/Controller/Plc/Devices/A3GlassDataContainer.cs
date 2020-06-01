using SPC.Core;

namespace SampleEqp
{
    public class A3GlassDataContainer : WordDeviceContainer
    {
        [SpcDevice(0x0000, length:8)]
        public WordStringDevice HPanelId { get; protected set; }

        [SpcDevice(0x0008, length: 8)]
        public WordStringDevice EPanelId { get; protected set; }

        [SpcDevice(0x0010, length: 8)]
        public WordStringDevice LotId { get; protected set; }

        [SpcDevice(0x0018, length: 8)]
        public WordStringDevice BatchId { get; protected set; }

        [SpcDevice(0x0020, length: 8)]
        public WordStringDevice JobId { get; protected set; }

        [SpcDevice(0x0028, length: 2)]
        public WordStringDevice PortId { get; protected set; }

        [SpcDevice(0x002A, length: 1)]
        public WordStringDevice SlotId { get; protected set; }

        [SpcDevice(0x002B, length: 2)]
        public WordStringDevice ProductType { get; protected set; }

        [SpcDevice(0x002D, length: 2)]
        public WordStringDevice ProductKind { get; protected set; }

        [SpcDevice(0x002F, length: 8)]
        public WordStringDevice ProductId { get; protected set; }

        [SpcDevice(0x0037, length: 8)]
        public WordStringDevice RunspecId { get; protected set; }

        [SpcDevice(0x003F, length: 4)]
        public WordStringDevice LayerId { get; protected set; }

        [SpcDevice(0x0043, length: 4)]
        public WordStringDevice StepId { get; protected set; }

        [SpcDevice(0x0047, length: 10)]
        public WordStringDevice Ppid { get; protected set; }

        [SpcDevice(0x0051, length: 10)]
        public WordStringDevice FlowId { get; protected set; }

        [SpcDevice(0x005B)]
        public WordUShortDevice GlassSize { get; protected set; }

        [SpcDevice(0x005D)]
        public WordUShortDevice GlassThickness { get; protected set; }

        [SpcDevice(0x005E)]
        public WordUShortDevice GlassState { get; protected set; }

        [SpcDevice(0x005F, length: 2)]
        public WordStringDevice GlassOrder { get; protected set; }

        [SpcDevice(0x0061, length: 8)]
        public WordStringDevice Comment { get; protected set; }

        [SpcDevice(0x0069, length: 2)]
        public WordStringDevice UseCount { get; protected set; }

        [SpcDevice(0x006B, length: 2)]
        public WordStringDevice Judgement { get; protected set; }

        [SpcDevice(0x006D, length: 2)]
        public WordStringDevice ReasonCode { get; protected set; }

        [SpcDevice(0x006F, length: 1)]
        public WordStringDevice InsFlag { get; protected set; }

        [SpcDevice(0x0070, length: 1)]
        public WordStringDevice EncFlag { get; protected set; }

        [SpcDevice(0x0071, length: 1)]
        public WordStringDevice PreRunFlag { get; protected set; }

        [SpcDevice(0x0072, length: 1)]
        public WordStringDevice TurnDir { get; protected set; }

        [SpcDevice(0x0073, length: 1)]
        public WordStringDevice FlipState { get; protected set; }

        [SpcDevice(0x0074, length: 2)]
        public WordStringDevice WorkState { get; protected set; }

        [SpcDevice(0x0076, length: 8)]
        public WordStringDevice MultiUse { get; protected set; }

        [SpcDevice(0x007E, length: 8)]
        public WordStringDevice PairGlassId { get; protected set; }

        [SpcDevice(0x0086, length: 10)]
        public WordStringDevice PairPpid { get; protected set; }

        [SpcDevice(0x0090, length: 20)]
        public WordStringDevice OptionName1 { get; protected set; }

        [SpcDevice(0x00A4, length: 20)]
        public WordStringDevice OptionValue1 { get; protected set; }

        [SpcDevice(0x00B8, length: 20)]
        public WordStringDevice OptionName2 { get; protected set; }

        [SpcDevice(0x00CC, length: 20)]
        public WordStringDevice OptionValue2 { get; protected set; }

        [SpcDevice(0x00E0, length: 20)]
        public WordStringDevice OptionName3 { get; protected set; }

        [SpcDevice(0x00F4, length: 20)]
        public WordStringDevice OptionValue3 { get; protected set; }

        [SpcDevice(0x0108, length: 20)]
        public WordStringDevice OptionName4 { get; protected set; }

        [SpcDevice(0x011C, length: 20)]
        public WordStringDevice OptionValue4 { get; protected set; }

        [SpcDevice(0x0130, length: 20)]
        public WordStringDevice OptionName5 { get; protected set; }

        [SpcDevice(0x0144, length: 20)]
        public WordStringDevice OptionValue5 { get; protected set; }

        [SpcDevice(0x0158)]
        public WordUIntDevice CSIF { get; protected set; }

        [SpcDevice(0x015A)]
        public WordUIntDevice AS { get; protected set; }

        [SpcDevice(0x015C)]
        public WordUIntDevice APS { get; protected set; }

        [SpcDevice(0x015E)]
        public WordUIntDevice UniqueId { get; protected set; }

        [SpcDevice(0x0160)]
        public WordUIntDevice BitSignal { get; protected set; }



        public A3GlassDataContainer()
        {
        }

    }
}
