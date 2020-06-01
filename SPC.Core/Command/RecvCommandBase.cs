namespace SPC.Core
{
    public abstract class RecvCommandBase<T> : SpcCommandBase<T>, ISpcRecvCommand
        where T : SpcBase
    {
        public abstract bool CanExecute();

        public abstract void Execute();
    }
}