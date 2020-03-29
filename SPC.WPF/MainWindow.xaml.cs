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

        public TestDeviceViewModel TestDeviceViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _Spc = new Core.SPC();
            _Spc.SetUp();
            //_Spc.Start();

            var bitDevContainer = _Spc.DeviceManager.GetDeviceContainer<BitDeviceContainer>(1);
            var wordDevContainer = _Spc.DeviceManager.GetDeviceContainer<WordDeviceContainer>(3);
            TestDeviceViewModel = new TestDeviceViewModel(bitDevContainer, wordDevContainer);

            DataContext = this;

            short[] arr1 = new short[2] { 1, 2 };
            short[] arr2 = new short[5];

            Array.Copy(arr1, arr2, arr2.Length);

        }
    }
}
