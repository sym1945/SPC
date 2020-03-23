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

namespace SPC
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // plc watcher init (config load)
            var plcWatcher = new PlcWatcher();

            // dev manager init (config load)
            var devManager = new DeviceManager
            {
                new BitDeviceContainer(eDevice.B, 0x0000, "CIM_RECV_BITS")
                {
                    new BitDevice() { Offset = 0, Desc = "HeartBit"},
                    new BitDevice() { Offset = 1, Desc = "RecvAble"},
                    new BitDevice() { Offset = 2, Desc = "RecvStart"},
                    new BitDevice() { Offset = 3, Desc = "RecvComplete"},
                },
                new BitDeviceContainer(eDevice.B, 0x0100, "CIM_SEND_BITS")
                {
                    new BitDevice() { Offset = 0, Desc = "HeartBit"},
                    new BitDevice() { Offset = 1, Desc = "SendAble"},
                    new BitDevice() { Offset = 2, Desc = "SendStart"},
                    new BitDevice() { Offset = 3, Desc = "SendComplete"},
                },
                new WordDeviceContainer(eDevice.W, 0x0000, "CIM_RECV_WORDS")
                {
                    new WordDevice() { Offset = 0, Length = 12, Desc = "RecvGlassId"},
                    new WordDevice() { Offset = 12, Length = 1, Desc = "RecvSlotNo"},
                    new WordDevice() { Offset = 13, Length = 2, Desc = "RecvWorkState"},
                },
                new WordDeviceContainer(eDevice.W, 0x0100, "CIM_SEND_WORDS")
                {
                    new WordDevice() { Offset = 0, Length = 12, Desc = "SendGlassId"},
                    new WordDevice() { Offset = 12, Length = 1, Desc = "SendSlotNo"},
                    new WordDevice() { Offset = 13, Length = 2, Desc = "SendWorkState"},
                },

            };

            // watcher <> manager connect
            plcWatcher.PlcConnected += devManager.OnPlcConnected;
            plcWatcher.BeginRead += devManager.OnBeginReadCycle;
            plcWatcher.EndRead += devManager.OnEndReadCycle;

            // watcher start
            plcWatcher.Start();

        }
    }
}
