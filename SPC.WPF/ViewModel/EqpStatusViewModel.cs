using SampleEqp;
using System.Windows;
using System.Windows.Media;

namespace SPC.WPF
{
    public class EqpStatusViewModel : NotifyPropertyChanged
    {
        public Brush EqstBackground
        {
            get
            {
                var currentApp = Application.Current;

                switch (Eqst)
                {
                    case Eqst.Normal: return (Brush)currentApp.FindResource("eqstNormalBackground");
                    case Eqst.Fault: return (Brush)currentApp.FindResource("eqstFaultBackground");
                    case Eqst.PM: return (Brush)currentApp.FindResource("eqstPMBackground");
                    default: return Brushes.White;
                }
            }
        }

        public Brush EqstForeground
        {
            get
            {
                var currentApp = Application.Current;

                switch (Eqst)
                {
                    case Eqst.Normal: return (Brush)currentApp.FindResource("eqstNormalForeground");
                    case Eqst.Fault: return (Brush)currentApp.FindResource("eqstFaultForeground");
                    case Eqst.PM: return (Brush)currentApp.FindResource("eqstPMForeground");
                    default: return Brushes.Black;
                }
            }
        }

        public Brush PrstBackground
        {
            get
            {
                var currentApp = Application.Current;

                switch (Prst)
                {
                    case Prst.Idle: return (Brush)currentApp.FindResource("prstIdleBackground");
                    case Prst.Execute: return (Brush)currentApp.FindResource("prstExecuteBackground");
                    case Prst.Pause: return (Brush)currentApp.FindResource("prstPauseBackground");
                    default: return Brushes.White;
                }
            }
        }

        public Brush PrstForeground
        {
            get
            {
                var currentApp = Application.Current;

                switch (Prst)
                {
                    case Prst.Idle: return (Brush)currentApp.FindResource("prstIdleForeground");
                    case Prst.Execute: return (Brush)currentApp.FindResource("prstExecuteForeground");
                    case Prst.Pause: return (Brush)currentApp.FindResource("prstPauseForeground");
                    default: return Brushes.Black;
                }
            }
        }


        public Eqst Eqst { get; set; } = Eqst.Normal;

        public Prst Prst { get; set; } = Prst.Idle;


        public EqpStatusViewModel(Equipment eqp)
        {
            eqp.EqstChanged += Eqp_EqstChanged;
            eqp.PrstChanged += Eqp_PrstChanged;
        }

        private void Eqp_PrstChanged(Equipment eqp)
        {
            Prst = eqp.Prst;
        }

        private void Eqp_EqstChanged(Equipment eqp)
        {
            Eqst = eqp.Eqst;
        }
    }
}
