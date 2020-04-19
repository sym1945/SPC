namespace SampleEqp
{
    public class Core
    {
        public Equipment Equipment { get; private set; }

        public PlcHandler PlcHandler { get; private set; }


        public Core()
        {
            Equipment = new Equipment();
            PlcHandler = new PlcHandler();

            Equipment.PrstChanged += Equipment_PrstChanged;
            Equipment.GlassDataAdded += Equipment_GlassDataAdded;
            Equipment.GlassDataRemoved += Equipment_GlassDataRemoved;
            Equipment.ProcessDone += Equipment_ProcessDone;
        }

        
        public void Start()
        {
            PlcHandler.Start();
        }

        private void Equipment_GlassDataRemoved(Equipment eqp, GlassData glass)
        {
            PlcHandler.CommandGlassUnload(glass);
        }

        private void Equipment_GlassDataAdded(Equipment eqp, GlassData glass)
        {
            PlcHandler.CommandGlassLoad(glass);
        }

        private void Equipment_PrstChanged(Equipment eqp)
        {
            PlcHandler.WriteProcessState(eqp.Prst);
        }

        private void Equipment_ProcessDone()
        {
            PlcHandler.CommandProcessEnd();
        }

    }


}
