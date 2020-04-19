namespace SPC.Core
{
    public abstract class PlcCommandActionBase
    {
        protected DeviceManager DevManager = SPCContainer.GetSPC().DeviceManager;

        internal PlcCommand PlcCommand { get; set; }

        internal abstract void Initialize();

        public abstract bool CanExecute();

        public abstract void Execute();
    }
}

