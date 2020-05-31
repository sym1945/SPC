using System;
using System.Linq;

namespace SPC.Core
{

    public abstract class Spc<TConfiguration, TDeviceManager>
        where TDeviceManager : SpcDeviceManager
        where TConfiguration : SpcConfiguration<TDeviceManager>, new()
    {
        public SpcCommunication Commnunication { get; private set; }

        public SpcDeviceWatcher Watcher { get; private set; }

        public SpcCommandManager Commands { get; private set; }

        public TDeviceManager Devices { get; private set; }

        public TConfiguration Configuration { get; private set; }


        public Spc()
        {
            Configuration = new TConfiguration();
        }

        public void SetUp()
        {
            SetUp(
                Configuration.BuildCommunication(),
                Configuration.BuildDeviceWatcher(),
                Configuration.BuildDeviceManager(),
                Configuration.BuildCommandManager()
                );
        }

        public void SetUp(SpcCommunication comm, SpcDeviceWatcher watcher, SpcDeviceManager devManager, SpcCommandManager commandManager = null)
        {
            Commnunication = comm;
            Watcher = watcher;
            Devices = (TDeviceManager)devManager;
            Commands = commandManager;

            if (Commnunication == null)
                throw new NullReferenceException("SPC Commnunication is NULL");
            if (Watcher == null)
                throw new NullReferenceException("SPC Device Watcher is NULL");
            if (Devices == null)
                throw new NullReferenceException("SPC Device Manager is NULL");

            Watcher.Comm = Commnunication;
            Devices.Comm = Commnunication;

            Devices.SetUp();
            //CommandManager?.SetUp();

            // watcher <> manager connect
            foreach (SpcDeviceContainerBase devContainer in Devices)
            {
                var readBlock = Watcher.GetReadBlock(devContainer.ReadBlockKey);
                if (readBlock != null)
                {
                    Commnunication.PlcConnected += devContainer.PlcConnected;
                    readBlock.BeforeRead += devContainer.BeforeRead;
                    readBlock.AfterRead += devContainer.AfterRead;
                }
            }


            Commnunication.PlcConnected += PlcConnected;
            Watcher.BeforeRead += BeforeRead;
            Watcher.AfterRead += AfterRead;

        }

        public bool Start()
        {
            if (Watcher == null)
                throw new NullReferenceException("PlcWathcer is NULL");

            // watcher start
            return Watcher.Start();
        }

        public bool Stop()
        {
            if (Watcher == null)
                return true;

            Watcher.Stop();
            return true;
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
            if (Commands != null)
            {
                foreach (var command in Commands.OfType<IRecvPlcCommand>())
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
            var command = Commands
                .OfType<ISendPlcCommand>()
                .FirstOrDefault(d => d.GetType().Name == commandName);

            if (command != null)
                command.AddCommandParameter(commandParameter);
        }

    }




    public class SPCSameple : Spc<SpcConfigurationSample, SpcDeviceManagerSample>
    {
    }

    public abstract class SpcConfiguration<TDeviceManager>
        where TDeviceManager : SpcDeviceManager
    {
        public SpcConfiguration()
        {
            // TODO: Read Xml
        }

        public abstract SpcCommunication BuildCommunication();

        public abstract SpcDeviceWatcher BuildDeviceWatcher();

        public abstract TDeviceManager BuildDeviceManager();

        public virtual SpcCommandManager BuildCommandManager()
        {
            return null;
        }
    }


    public class SpcConfigurationSample : SpcConfiguration<SpcDeviceManagerSample>
    {
        public override SpcCommunication BuildCommunication()
        {
            return new Melsec();
        }

        public override SpcDeviceManagerSample BuildDeviceManager()
        {
            return new SpcDeviceManagerSample();
        }

        public override SpcDeviceWatcher BuildDeviceWatcher()
        {
            return new SpcDeviceWatcher();
        }
    }

    public class AnotherDevcieManager : SpcDeviceManager
    {
    }

    public class SpcDeviceManagerSample : SpcDeviceManager
    {
    }
}