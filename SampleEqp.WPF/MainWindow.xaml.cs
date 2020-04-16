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
        private Core _Core = new Core();


        public EqpStatusViewModel EqpStatusViewModel { get; set; }

        public GlassExistenceViewModel GlassExistenceViewModel { get; set; }

        public ProcessCommandViewModel ProcessCommandViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            var eqp = _Core.Equipment;

            EqpStatusViewModel = new EqpStatusViewModel(eqp);
            GlassExistenceViewModel = new GlassExistenceViewModel(eqp);
            ProcessCommandViewModel = new ProcessCommandViewModel(eqp);

            DataContext = this;

            Loaded += (sender, e) =>
            {
                //_Core.Start();
            };
        }

    }
}
