using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class SPC
    {
        private PlcWatcher _PlcWatcher;
        private DeviceManager _DeviceManager;
        private CommandManager _CommandManager;

        public PlcWatcher PlcWatcher => _PlcWatcher;

        public DeviceManager DeviceManager => _DeviceManager;

        public CommandManager CommandManager => _CommandManager;

        public SPC()
        {
            _PlcWatcher = new PlcWatcher();
            _DeviceManager = new DeviceManager();
            _CommandManager = new CommandManager();
            SPCContainer.SetSPC(this);
        }
        public SPC(PlcComm plcComm)
        {
            _PlcWatcher = new PlcWatcher(plcComm);
            _DeviceManager = new DeviceManager();
            _CommandManager = new CommandManager();
            SPCContainer.SetSPC(this);
        }


        public void SetUp()
        {
            // plc watcher init (config load)
            _PlcWatcher = new PlcWatcher
            {
                new PlcReadBlock() { Device = eDevice.B, StartAddress = 0, Size = 100, Key = 1},
                new PlcReadBlock() { Device = eDevice.W, StartAddress = 0, Size = 100, Key = 3},
            };

            // dev manager init (config load)
            _DeviceManager = new DeviceManager
            {
                new BitDeviceContainer(eDevice.B, 0x0000, 1, "CIM_RECV_BITS")
                {
                    new BitDevice() { Offset = 0, Key = "HeartBit"},
                    new BitDevice() { Offset = 1, Key = "RecvAble"},
                    new BitDevice() { Offset = 2, Key = "RecvStart"},
                    new BitDevice() { Offset = 3, Key = "RecvComplete"},
                },
                new BitDeviceContainer(eDevice.B, 0x0100, 2, "CIM_SEND_BITS")
                {
                    new BitDevice() { Offset = 0, Key = "HeartBit"},
                    new BitDevice() { Offset = 1, Key = "SendAble"},
                    new BitDevice() { Offset = 2, Key = "SendStart"},
                    new BitDevice() { Offset = 3, Key = "SendComplete"},
                },
                new WordDeviceContainer(eDevice.W, 0x0000, 3, "CIM_RECV_WORDS")
                {
                    new WordDevice() { Offset = 0, Length = 3, Key = "RecvGlassId"},
                    new WordDevice() { Offset = 3, Length = 1, Key = "RecvSlotNo"},
                    new WordDevice() { Offset = 4, Length = 2, Key = "RecvWorkState"},
                },
                new WordDeviceContainer(eDevice.W, 0x0100, 4, "CIM_SEND_WORDS")
                {
                    new WordDevice() { Offset = 0, Length = 12, Key = "SendGlassId"},
                    new WordDevice() { Offset = 12, Length = 1, Key = "SendSlotNo"},
                    new WordDevice() { Offset = 13, Length = 2, Key = "SendWorkState"},
                },
            };
            _DeviceManager.SetUp();

            // command init (config load)
            _CommandManager = new CommandManager
            {
                new PlcCommand()
                {
                    Container = "CIM_RECV_BITS",
                    Device = "RecvAble",
                    Trigger = CommandTrigger.BitOn,
                    Command ="RecvAbleOnHandshakeAction"
                },

                new PlcCommand()
                {
                    Container = "CIM_SEND_BITS",
                    Device = "SendAble",
                    Trigger = CommandTrigger.BitOn,
                    Command ="SendAbleOnHandshakeAction"
                }
            };
            _CommandManager.SetUp();


            // watcher <> manager connect
            foreach (DeviceContainerBase devContainer in _DeviceManager)
            {
                var readBlock = _PlcWatcher.GetReadBlock(devContainer.ReadBlockKey);
                if (readBlock != null)
                {
                    _PlcWatcher.PlcConnected += devContainer.PlcConnected;
                    readBlock.BeforeRead += devContainer.BeforeRead;
                    readBlock.AfterRead += devContainer.AfterRead;
                }

                devContainer.WriteToPlc += _PlcWatcher.WriteToPlc;
            }


            _PlcWatcher.PlcConnected += PlcConnected;
            _PlcWatcher.BeforeRead += BeforeRead;
            _PlcWatcher.AfterRead += AfterRead;
            

            // command setup

        }

        public bool Start()
        {
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


    }

}
