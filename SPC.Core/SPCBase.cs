using System;
using System.Linq;

namespace SPC.Core
{
    public abstract class SPCBase
    {
        private readonly PlcComm _PlcComm;

        public PlcWatcher PlcWatcher { get; private set; }

        public DeviceManager DeviceManager { get; private set; }

        public PlcCommandManager CommandManager { get; private set; }

        public SPCBase()
        {
            _PlcComm = new Melsec();
            SPCContainer.SetSPC(this);
        }
        public SPCBase(PlcComm plcComm)
        {
            _PlcComm = plcComm;
            SPCContainer.SetSPC(this);
        }

        public void SetUp()
        {
            SetUp(BuildPlcWatcher(), BuildDeviceManager(), BuildPlcCommandManger());
        }

        public void SetUp(PlcWatcher watcher, DeviceManager devManager, PlcCommandManager commandManager = null)
        {
            PlcWatcher = watcher;
            DeviceManager = devManager;
            CommandManager = commandManager;

            if (PlcWatcher == null)
                throw new NullReferenceException("PlcWathcer is NULL");
            if (DeviceManager == null)
                throw new NullReferenceException("DeviceManager is NULL");

            PlcWatcher.Comm = _PlcComm;
            DeviceManager.Comm = _PlcComm;

            DeviceManager.SetUp();
            //CommandManager?.SetUp();


            // watcher <> manager connect
            foreach (DeviceContainerBase devContainer in DeviceManager)
            {
                var readBlock = PlcWatcher.GetReadBlock(devContainer.ReadBlockKey);
                if (readBlock != null)
                {
                    _PlcComm.PlcConnected += devContainer.PlcConnected;
                    readBlock.BeforeRead += devContainer.BeforeRead;
                    readBlock.AfterRead += devContainer.AfterRead;
                }
            }


            _PlcComm.PlcConnected += PlcConnected;
            PlcWatcher.BeforeRead += BeforeRead;
            PlcWatcher.AfterRead += AfterRead;

        }

        public bool Start()
        {
            if (PlcWatcher == null)
                throw new NullReferenceException("PlcWathcer is NULL");

            // watcher start
            return PlcWatcher.Start();
        }

        private void PlcConnected()
        {
            // Do Something

            OnPlcConnected();
        }


        private void BeforeRead()
        {
            // Do Something

            OnBeforeRead();
        }

        private void AfterRead()
        {
            if (CommandManager != null)
            {
                foreach (var command in CommandManager.OfType<IRecvPlcCommand>())
                {
                    if (command.CanExecute())
                        command.Execute();
                }
            }

            OnAfterRead();
        }

        public virtual void OnPlcConnected()
        {

        }

        public virtual void OnBeforeRead()
        {

        }

        public virtual void OnAfterRead()
        {

        }


        public void SendCommand(string commandName, PlcCommandParameter commandParameter)
        {
            var command = CommandManager
                .OfType<ISendPlcCommand>()
                .FirstOrDefault(d => d.GetType().Name == commandName);

            if (command != null)
                command.AddCommandParameter(commandParameter);
        }

        public virtual PlcCommandManager BuildPlcCommandManger()
        {
            return null;
        }

        public virtual PlcWatcher BuildPlcWatcher()
        {
            return null;
        }

        public virtual DeviceManager BuildDeviceManager()
        {
            return null;
        }

    }

}
