using SampleEqp;

namespace SampleEqp.WPF
{
    public class GlassDataEditorViewModel : NotifyPropertyChanged
    {
        public GlassData GlassData { get; private set; } = new GlassData();

        public string HPanelId
        {
            get => GlassData.HPanelId;
            set => GlassData.HPanelId = value;
        }

        public string EPanelId
        {
            get => GlassData.EPanelId;
            set => GlassData.EPanelId = value;
        }

        public string LotId
        {
            get => GlassData.LotId;
            set => GlassData.LotId = value;
        }

        public string BatchId
        {
            get => GlassData.BatchId;
            set => GlassData.BatchId = value;
        }

        public string JobId
        {
            get => GlassData.JobId;
            set => GlassData.JobId = value;
        }

        public string PortId
        {
            get => GlassData.PortId;
            set => GlassData.PortId = value;
        }

        public string SlotId
        {
            get => GlassData.SlotId;
            set => GlassData.SlotId = value;
        }

        public string ProductType
        {
            get => GlassData.ProductType;
            set => GlassData.ProductType = value;
        }

        public string ProductKind
        {
            get => GlassData.ProductKind;
            set => GlassData.ProductKind = value;
        }

        public string ProductId
        {
            get => GlassData.ProductId;
            set => GlassData.ProductId = value;
        }

        public string RunspecId
        {
            get => GlassData.RunspecId;
            set => GlassData.RunspecId = value;
        }

        public string LayerId
        {
            get => GlassData.LayerId;
            set => GlassData.LayerId = value;
        }

        public string StepId
        {
            get => GlassData.StepId;
            set => GlassData.StepId = value;
        }

        public string Ppid
        {
            get => GlassData.Ppid;
            set => GlassData.Ppid = value;
        }

        public string FlowId
        {
            get => GlassData.FlowId;
            set => GlassData.FlowId = value;
        }

        public ushort GlassSize
        {
            get => GlassData.GlassSize;
            set => GlassData.GlassSize = value;
        }

        public ushort GlassThickness
        {
            get => GlassData.GlassThickness;
            set => GlassData.GlassThickness = value;
        }

        public ushort GlassState
        {
            get => GlassData.GlassState;
            set => GlassData.GlassState = value;
        }

        public string GlassOrder
        {
            get => GlassData.GlassOrder;
            set => GlassData.GlassOrder = value;
        }

        public string Comment
        {
            get => GlassData.Comment;
            set => GlassData.Comment = value;
        }

        public string UseCount
        {
            get => GlassData.UseCount;
            set => GlassData.UseCount = value;
        }

        public string Judgement
        {
            get => GlassData.Judgement;
            set => GlassData.Judgement = value;
        }

        public string ReasonCode
        {
            get => GlassData.ReasonCode;
            set => GlassData.ReasonCode = value;
        }

        public string InsFlag
        {
            get => GlassData.InsFlag;
            set => GlassData.InsFlag = value;
        }

        public string EncFlag
        {
            get => GlassData.EncFlag;
            set => GlassData.EncFlag = value;
        }

        public string PreRunFlag
        {
            get => GlassData.PreRunFlag;
            set => GlassData.PreRunFlag = value;
        }

        public string TurnDir
        {
            get => GlassData.TurnDir;
            set => GlassData.TurnDir = value;
        }

        public string FlipState
        {
            get => GlassData.FlipState;
            set => GlassData.FlipState = value;
        }

        public string WorkState
        {
            get => GlassData.WorkState;
            set => GlassData.WorkState = value;
        }

        public string MultiUse
        {
            get => GlassData.MultiUse;
            set => GlassData.MultiUse = value;
        }

        public string PairGlassId
        {
            get => GlassData.PairGlassId;
            set => GlassData.PairGlassId = value;
        }

        public string PairPpid
        {
            get => GlassData.PairPpid;
            set => GlassData.PairPpid = value;
        }

        public string OptionName1
        {
            get => GlassData.OptionName1;
            set => GlassData.OptionName1 = value;
        }

        public string OptionValue1
        {
            get => GlassData.OptionValue1;
            set => GlassData.OptionValue1 = value;
        }

        public string OptionName2
        {
            get => GlassData.OptionName2;
            set => GlassData.OptionName2 = value;
        }

        public string OptionValue2
        {
            get => GlassData.OptionValue2;
            set => GlassData.OptionValue2 = value;
        }

        public string OptionName3
        {
            get => GlassData.OptionName3;
            set => GlassData.OptionName3 = value;
        }

        public string OptionValue3
        {
            get => GlassData.OptionValue3;
            set => GlassData.OptionValue3 = value;
        }

        public string OptionName4
        {
            get => GlassData.OptionName4;
            set => GlassData.OptionName4 = value;
        }

        public string OptionValue4
        {
            get => GlassData.OptionValue4;
            set => GlassData.OptionValue4 = value;
        }

        public string OptionName5
        {
            get => GlassData.OptionName5;
            set => GlassData.OptionName5 = value;
        }

        public string OptionValue5
        {
            get => GlassData.OptionValue5;
            set => GlassData.OptionValue5 = value;
        }

        public ushort CSIF
        {
            get => GlassData.CSIF;
            set => GlassData.CSIF = value;
        }

        public ushort AS
        {
            get => GlassData.AS;
            set => GlassData.AS = value;
        }

        public ushort APS
        {
            get => GlassData.APS;
            set => GlassData.APS = value;
        }

        public ushort UniqueId
        {
            get => GlassData.UniqueId;
            set => GlassData.UniqueId = value;
        }

        public ushort BitSignal
        {
            get => GlassData.BitSignal;
            set => GlassData.BitSignal = value;
        }

    }
}
