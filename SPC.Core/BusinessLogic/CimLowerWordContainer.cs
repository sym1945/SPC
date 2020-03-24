namespace SPC.Core
{
    public class CimLowerWordContainer : WordDeviceContainer
    {
        public string HPanelId
        {
            get => GetDevice("HPanelId").Value.ToString();
            set => SetValue("HPanelId", value);
        }

        public int SlotNo
        {
            get => GetDevice("SlotNo").Value.ToInt32();
            set => SetValue("SlotNo", value);
        }
    }
}