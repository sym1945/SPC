using System.Windows;
using System.Windows.Controls;

namespace SampleEqp.WPF
{
    /// <summary>
    /// LabelTextBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LabelTextBox : UserControl
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label"
                , typeof(string)
                , typeof(LabelTextBox)
                , new PropertyMetadata("Label"));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text"
                , typeof(string)
                , typeof(LabelTextBox)
                , new FrameworkPropertyMetadata("Text", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public LabelTextBox()
        {
            InitializeComponent();
        }
    }
}
