using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class SPC
    {
        private PlcComm _PlcComm;
        private PlcWatcher _PlcWatcher;
        private DeviceManager _DeviceManager;
        private PlcCommandManager _CommandManager;

        public PlcWatcher PlcWatcher => _PlcWatcher;

        public DeviceManager DeviceManager => _DeviceManager;

        public PlcCommandManager CommandManager => _CommandManager;

        public SPC()
        {
            _PlcComm = new Melsec();
            SPCContainer.SetSPC(this);
        }
        public SPC(PlcComm plcComm)
        {
            _PlcComm = plcComm;
            SPCContainer.SetSPC(this);
        }


        public void SetUp(PlcWatcher watcher, DeviceManager devManager, PlcCommandManager commandManager = null)
        {
            _PlcWatcher = watcher;
            _DeviceManager = devManager;
            _CommandManager = commandManager;

            if (_PlcWatcher == null)
                throw new NullReferenceException("PlcWathcer is NULL");
            if (_DeviceManager == null)
                throw new NullReferenceException("DeviceManager is NULL");

            _PlcWatcher.Comm = _PlcComm;
            _DeviceManager.Comm = _PlcComm;

            _DeviceManager.SetUp();
            _CommandManager?.SetUp();


            // watcher <> manager connect
            foreach (DeviceContainerBase devContainer in _DeviceManager)
            {
                var readBlock = _PlcWatcher.GetReadBlock(devContainer.ReadBlockKey);
                if (readBlock != null)
                {
                    _PlcComm.PlcConnected += devContainer.PlcConnected;
                    readBlock.BeforeRead += devContainer.BeforeRead;
                    readBlock.AfterRead += devContainer.AfterRead;
                }
            }


            _PlcComm.PlcConnected += PlcConnected;
            _PlcWatcher.BeforeRead += BeforeRead;
            _PlcWatcher.AfterRead += AfterRead;

        }

        public bool Start()
        {
            if (_PlcWatcher == null)
                throw new NullReferenceException("PlcWathcer is NULL");

            // watcher start
            return _PlcWatcher.Start();
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
            // Do Something
            foreach (var commandAction in _CommandManager.CommandActions)
            {
                commandAction.Execute();
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
            var commandAction = _CommandManager.CommandActions.FirstOrDefault(d => d.GetType().Name == commandName);

            if (commandAction is SendHandshakeAction sendAction)
            {
                sendAction.AddCommandParameter(commandParameter);
            }

        }


    }

}
