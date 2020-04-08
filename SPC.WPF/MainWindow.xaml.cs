using SPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPC.WPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private Core.SPC _Spc;

        public DeviceListViewModel DeviceListViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // plc watcher init (config load)
            var plcWatcher = new PlcWatcher
            {
                new PlcReadBlock() { Device = eDevice.B, StartAddress = 0x0000, Size = 100, Key = 1},
                new PlcReadBlock() { Device = eDevice.B, StartAddress = 0x0100, Size = 100, Key = 2},
                new PlcReadBlock() { Device = eDevice.W, StartAddress = 0x0000, Size = 100, Key = 3},
            };

            // dev manager init (config load)
            var deviceManager = new DeviceManager
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

            // command init (config load)
            var commandManager = new PlcCommandManager
            {
                new PlcCommand()
                {
                    Container = "CIM_RECV_BITS",
                    Device = "RecvAble",
                    Trigger = CommandTrigger.BitOn,
                    Command ="RecvAbleOnHandshakeAction"
                },

                //new PlcCommand()
                //{
                //    Container = "CIM_SEND_BITS",
                //    Device = "SendAble",
                //    Trigger = CommandTrigger.BitOn,
                //    Command ="SendAbleOnHandshakeAction"
                //}
            };


            _Spc = new Core.SPC();
            _Spc.SetUp(plcWatcher, deviceManager, commandManager);
            _Spc.Start();


            DeviceListViewModel = new DeviceListViewModel(_Spc.DeviceManager);

            DataContext = this;
        }
    }
}
