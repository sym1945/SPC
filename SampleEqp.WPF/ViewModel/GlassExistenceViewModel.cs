namespace SampleEqp.WPF
{
    public class GlassExistenceViewModel : NotifyPropertyChanged
    {
        public bool IsExist { get; set; } = false;

        public string HPanelId { get; set; } = "UNKNOWN";

        public string SlotNo { get; set; } = "";


        public GlassExistenceViewModel(Equipment eqp)
        {
            eqp.GlassDataAdded += _Eqp_GlassDataAdded;
            eqp.GlassDataRemoved += _Eqp_GlassDataRemoved;
        }

        private void _Eqp_GlassDataAdded(Equipment eqp, GlassData data)
        {
            HPanelId = data.HPanelId;
            SlotNo = data.SlotId;
            IsExist = true;
        }

        private void _Eqp_GlassDataRemoved(Equipment eqp, GlassData data)
        {
            IsExist = false;
        }

        
    }
}
