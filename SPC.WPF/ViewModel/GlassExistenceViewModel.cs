using SampleEqp;

namespace SPC.WPF
{
    public class GlassExistenceViewModel : NotifyPropertyChanged
    {
        public bool IsExist { get; set; } = false;

        public string HPanelId { get; set; } = "UNKNOWN";

        public int SlotNo { get; set; } = 0;


        public GlassExistenceViewModel(Equipment eqp)
        {
            eqp.GlassDataAdded += _Eqp_GlassDataAdded;
            eqp.GlassDataRemoved += _Eqp_GlassDataRemoved;
        }

        private void _Eqp_GlassDataAdded(Equipment eqp, GlassData data)
        {
            HPanelId = data.HPanelId;
            SlotNo = data.SlotNo;
            IsExist = true;
        }

        private void _Eqp_GlassDataRemoved(Equipment eqp, GlassData data)
        {
            IsExist = false;
        }

        
    }
}
