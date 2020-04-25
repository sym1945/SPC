namespace SPC.Core
{
    public interface IRecvPlcCommand
    {
        bool CanExecute();

        void Execute();
    }
}