namespace SampleEqp
{
    public static class WordWriteHelper
    {
        public static void WriteGlassData(this A3GlassDataContainer dataContainer, GlassData glassData)
        {
            dataContainer.HPanelId = glassData.HPanelId;
            dataContainer.EPanelId = glassData.EPanelId;
            dataContainer.LotId = glassData.LotId;
            dataContainer.BatchId = glassData.BatchId;
            dataContainer.JobId = glassData.JobId;
            dataContainer.PortId = glassData.PortId;
            dataContainer.SlotId = glassData.SlotId;
            dataContainer.ProductType = glassData.ProductType;
            dataContainer.ProductKind = glassData.ProductKind;
            dataContainer.ProductId = glassData.ProductId;
            dataContainer.RunspecId = glassData.RunspecId;
            dataContainer.LayerId = glassData.LayerId;
            dataContainer.StepId = glassData.StepId;
            dataContainer.Ppid = glassData.Ppid;
            dataContainer.FlowId = glassData.FlowId;
            dataContainer.GlassSize = glassData.GlassSize;
            dataContainer.GlassThickness = glassData.GlassThickness;
            dataContainer.GlassState = glassData.GlassState;
            dataContainer.GlassOrder = glassData.GlassOrder;
            dataContainer.Comment = glassData.Comment;
            dataContainer.UseCount = glassData.UseCount;
            dataContainer.Judgement = glassData.Judgement;
            dataContainer.ReasonCode = glassData.ReasonCode;
            dataContainer.InsFlag = glassData.InsFlag;
            dataContainer.EncFlag = glassData.EncFlag;
            dataContainer.PreRunFlag = glassData.PreRunFlag;
            dataContainer.TurnDir = glassData.TurnDir;
            dataContainer.FlipState = glassData.FlipState;
            dataContainer.WorkState = glassData.WorkState;
            dataContainer.MultiUse = glassData.MultiUse;
            dataContainer.PairGlassId = glassData.PairGlassId;
            dataContainer.PairPpid = glassData.PairPpid;
            dataContainer.OptionName1 = glassData.OptionName1;
            dataContainer.OptionValue1 = glassData.OptionValue1;
            dataContainer.OptionName2 = glassData.OptionName2;
            dataContainer.OptionValue2 = glassData.OptionValue2;
            dataContainer.OptionName3 = glassData.OptionName3;
            dataContainer.OptionValue3 = glassData.OptionValue3;
            dataContainer.OptionName4 = glassData.OptionName4;
            dataContainer.OptionValue4 = glassData.OptionValue4;
            dataContainer.OptionName5 = glassData.OptionName5;
            dataContainer.OptionValue5 = glassData.OptionValue5;
            dataContainer.CSIF = glassData.CSIF;
            dataContainer.AS = glassData.AS;
            dataContainer.APS = glassData.APS;
            dataContainer.UniqueId = glassData.UniqueId;
            dataContainer.BitSignal = glassData.BitSignal;
        }
    }
}