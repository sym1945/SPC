using SampleEqp;

namespace SPC.WPF
{
    public class GlassDataEditorViewModel : NotifyPropertyChanged
    {
        public GlassData GlassData { get; private set; } = new GlassData();

        public string HPanelId
        {
            get => GlassData.HPanelId;
            set => GlassData.HPanelId = value;
        }

        public int SlotNo
        {
            get => GlassData.SlotNo;
            set => GlassData.SlotNo = value;
        }

    }
}
