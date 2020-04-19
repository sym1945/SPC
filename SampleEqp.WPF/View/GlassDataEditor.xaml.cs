using System.Windows;

namespace SampleEqp.WPF
{
    /// <summary>
    /// GlassDataEditor.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GlassDataEditor : Window
    {
        public GlassDataEditor()
        {
            InitializeComponent();
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
