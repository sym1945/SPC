namespace SampleEqp
{
    public static class WordWriteHelper
    {
        public static void WriteGlassData(this A3GlassDataContainer dataContainer, GlassData glassData)
        {
            dataContainer.HPanelId.Value = glassData.HPanelId;
            dataContainer.EPanelId.Value = glassData.EPanelId;
            dataContainer.LotId.Value = glassData.LotId;
            dataContainer.BatchId.Value = glassData.BatchId;
            dataContainer.JobId.Value = glassData.JobId;
            dataContainer.PortId.Value = glassData.PortId;
            dataContainer.SlotId.Value = glassData.SlotId;
            dataContainer.ProductType.Value = glassData.ProductType;
            dataContainer.ProductKind.Value = glassData.ProductKind;
            dataContainer.ProductId.Value = glassData.ProductId;
            dataContainer.RunspecId.Value = glassData.RunspecId;
            dataContainer.LayerId.Value = glassData.LayerId;
            dataContainer.StepId.Value = glassData.StepId;
            dataContainer.Ppid.Value = glassData.Ppid;
            dataContainer.FlowId.Value = glassData.FlowId;
            dataContainer.GlassSize.Value = glassData.GlassSize;
            dataContainer.GlassThickness.Value = glassData.GlassThickness;
            dataContainer.GlassState.Value = glassData.GlassState;
            dataContainer.GlassOrder.Value = glassData.GlassOrder;
            dataContainer.Comment.Value = glassData.Comment;
            dataContainer.UseCount.Value = glassData.UseCount;
            dataContainer.Judgement.Value = glassData.Judgement;
            dataContainer.ReasonCode.Value = glassData.ReasonCode;
            dataContainer.InsFlag.Value = glassData.InsFlag;
            dataContainer.EncFlag.Value = glassData.EncFlag;
            dataContainer.PreRunFlag.Value = glassData.PreRunFlag;
            dataContainer.TurnDir.Value = glassData.TurnDir;
            dataContainer.FlipState.Value = glassData.FlipState;
            dataContainer.WorkState.Value = glassData.WorkState;
            dataContainer.MultiUse.Value = glassData.MultiUse;
            dataContainer.PairGlassId.Value = glassData.PairGlassId;
            dataContainer.PairPpid.Value = glassData.PairPpid;
            dataContainer.OptionName1.Value = glassData.OptionName1;
            dataContainer.OptionValue1.Value = glassData.OptionValue1;
            dataContainer.OptionName2.Value = glassData.OptionName2;
            dataContainer.OptionValue2.Value = glassData.OptionValue2;
            dataContainer.OptionName3.Value = glassData.OptionName3;
            dataContainer.OptionValue3.Value = glassData.OptionValue3;
            dataContainer.OptionName4.Value = glassData.OptionName4;
            dataContainer.OptionValue4.Value = glassData.OptionValue4;
            dataContainer.OptionName5.Value = glassData.OptionName5;
            dataContainer.OptionValue5.Value = glassData.OptionValue5;
            dataContainer.CSIF.Value = glassData.CSIF;
            dataContainer.AS.Value = glassData.AS;
            dataContainer.APS.Value = glassData.APS;
            dataContainer.UniqueId.Value = glassData.UniqueId;
            dataContainer.BitSignal.Value = glassData.BitSignal;
        }
    }
}