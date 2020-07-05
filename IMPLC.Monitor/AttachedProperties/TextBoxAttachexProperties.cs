using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace IMPLC.Monitor
{
    public class IsFocusProperty : AttachedPropertyBase<IsFocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;

            if ((bool)e.NewValue)
                control.Focus();
        }
    }

    public class SelectAllProperty : AttachedPropertyBase<SelectAllProperty, bool>
    {
        public override async void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is TextBox textBox))
                return;

            if ((bool)e.NewValue)
            {
                await Task.Delay(50);
                textBox.SelectAll();
            }
                
        }
    }

    public class LoseFoucsWhenTypeEnterProperty : AttachedPropertyBase<LoseFoucsWhenTypeEnterProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is TextBox textBox))
                return;

            textBox.KeyDown -= TextBox_KeyDown;

            if ((bool)e.NewValue)
            {
                textBox.KeyDown += TextBox_KeyDown;
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (e.Key == Key.Enter)
            {
                textBox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }

}