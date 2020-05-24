using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

}