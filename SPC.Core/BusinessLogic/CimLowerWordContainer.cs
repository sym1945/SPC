namespace SPC.Core
{
    public class CimLowerWordContainer : WordDeviceContainer
    {
        public string HPanelId
        {
            get => GetDevice("HPanelId").Values.ToString();
            set => SetValue("HPanelId", value);
        }
    }
}