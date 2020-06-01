namespace SPC.Core
{
    public interface ISpcRecvCommand
    {
        bool CanExecute();

        void Execute();
    }
}