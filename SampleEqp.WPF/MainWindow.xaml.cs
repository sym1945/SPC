using SampleEqp;
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

namespace SampleEqp.WPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private Equipment _Eqp = new Equipment();


        public EqpStatusViewModel EqpStatusViewModel { get; set; }

        public GlassExistenceViewModel GlassExistenceViewModel { get; set; }

        public ProcessCommandViewModel ProcessCommandViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            EqpStatusViewModel = new EqpStatusViewModel(_Eqp);
            GlassExistenceViewModel = new GlassExistenceViewModel(_Eqp);
            ProcessCommandViewModel = new ProcessCommandViewModel(_Eqp);

            DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //// plc watcher init (config load)
            //var plcWatcher = new PlcWatcher
            //{
            //    new PlcReadBlock() { Device = eDevice.B, StartAddress = 0x0000, Size = 100, Key = 1},
            //    new PlcReadBlock() { Device = eDevice.B, StartAddress = 0x0100, Size = 100, Key = 2},
            //    new PlcReadBlock() { Device = eDevice.W, StartAddress = 0x0000, Size = 100, Key = 3},
            //};


            //// command init (config load)
            //var commandManager = new PlcCommandManager
            //{
            //    new PlcCommand()
            //    {
            //        Container = "CIM_SEND_BITS",
            //        Device = "SendAble",
            //        Trigger = CommandTrigger.BitOn,
            //        Command ="RecvAbleOnHandshakeAction"
            //    },

            //    new PlcCommand()
            //    {
            //        Container = "CIM_SEND_BITS",
            //        Device = "SendAble",
            //        Trigger = CommandTrigger.BitOn,
            //        Command ="SendAbleOnHandshakeAction"
            //    }
            //};


            //_Spc = new Core.SPC();
            //_Spc.SetUp(plcWatcher, deviceManager, commandManager);
            //_Spc.Start();

            


            //DeviceListViewModel = new DeviceListViewModel(_Spc.DeviceManager);

            //DataContext = this;
        }
    }
}
