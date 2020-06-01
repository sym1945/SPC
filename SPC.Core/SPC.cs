using System;
using System.Linq;

namespace SPC.Core
{
    public abstract class SpcBase
    {
        public SpcCommunication Commnunication { get; private set; }

        public SpcDeviceWatcher Watcher { get; private set; }

        public SpcCommandManager Commands { get; private set; }

        public SpcDeviceManager Devices { get; private set; }

        public SpcConfiguration Configuration { get; private set; }


        public SpcBase()
        {
            // TODO: Find Configuration
            SpcContainer.SetSPC(this);
        }
        public SpcBase(SpcConfiguration configuration) : this()
        {
            Configuration = configuration;
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
            Devices = devManager;
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
                foreach (var command in Commands.OfType<ISpcRecvCommand>())
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


        public void SendCommand(string commandName, SpcCommandParameter commandParameter)
        {
            var command = Commands
                .OfType<ISpcSendCommand>()
                .FirstOrDefault(d => d.GetType().Name == commandName);

            if (command != null)
                command.AddCommandParameter(commandParameter);
        }

        public TDeviceManager GetDevices<TDeviceManager>()
            where TDeviceManager : SpcDeviceManager
        {
            return (TDeviceManager)Devices;
        }

        public TConfiguration GetConfiguration<TConfiguration>()
            where TConfiguration : SpcConfiguration
        {
            return (TConfiguration)Configuration;
        }
    }


    public abstract class Spc<TDeviceManager> : SpcBase
        where TDeviceManager : SpcDeviceManager
    {
        public new TDeviceManager Devices => GetDevices<TDeviceManager>();


        public Spc(SpcConfiguration configuration) : base(configuration)
        {

        }
    }



    public abstract class Spc<TConfiguration, TDeviceManager> : Spc<TDeviceManager>
        where TDeviceManager : SpcDeviceManager
        where TConfiguration : SpcConfiguration, new()
    {
        public new TConfiguration Configuration => GetConfiguration<TConfiguration>();


        public Spc() : base(new TConfiguration())
        {

        }
    }




    public class SPCSameple : Spc<SpcConfigurationSample, SpcDeviceManagerSample>
    {
    }

    public abstract class SpcConfiguration
    {
        public SpcConfiguration()
        {
            // TODO: Read Xml
        }

        public abstract SpcCommunication BuildCommunication();

        public abstract SpcDeviceWatcher BuildDeviceWatcher();

        public abstract SpcDeviceManager BuildDeviceManager();

        public virtual SpcCommandManager BuildCommandManager()
        {
            return null;
        }
    }


    public class SpcConfigurationSample : SpcConfiguration
    {
        public override SpcCommunication BuildCommunication()
        {
            return new Melsec();
        }

        public override SpcDeviceManager BuildDeviceManager()
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