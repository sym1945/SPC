using System.Windows;
using System.Windows.Input;


namespace SampleEqp.WPF
{
    public class ProcessCommandViewModel : NotifyPropertyChanged
    {
        private GlassDataEditorViewModel _GlassDataEditorViewModel;
        private Equipment _Eqp;


        public ICommand SetGlassDataCommand
        {
            get => new CommandBase((parameter) =>
            {
                var glassEditorViewModel = new GlassDataEditorViewModel(_Eqp.GetGlassData());
                var glassEditorWindow = new GlassDataEditor();
                glassEditorWindow.Owner = Application.Current.MainWindow;
                glassEditorWindow.DataContext = glassEditorViewModel;
                glassEditorWindow.ShowDialog();

                _GlassDataEditorViewModel = glassEditorViewModel;
            });
        }

        public ICommand TrackInCommand
        {
            get => new CommandBase((parameter) =>
            {
                if (_GlassDataEditorViewModel == null)
                    return;

                _Eqp.AddGlassData(_GlassDataEditorViewModel.GlassData);
            });
        }

        public ICommand ProcessEndCommand
        {
            get => new CommandBase((parameter) =>
            {
                _Eqp.CompleteProcess();
            });
        }

        public ICommand TrackOutCommand
        {
            get => new CommandBase((parameter) =>
            {
                if (_GlassDataEditorViewModel == null)
                    return;

                _Eqp.RemoveGlassData(_GlassDataEditorViewModel.GlassData.HPanelId);
            });
        }


        public ProcessCommandViewModel(Equipment eqp)
        {
            _Eqp = eqp;
        }

    }
}
