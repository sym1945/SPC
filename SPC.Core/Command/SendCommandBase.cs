namespace SPC.Core
{
    public abstract class SendCommandBase<T> : SpcCommandBase<T>, ISpcSendCommand
        where T: SpcBase
    {
        public abstract void AddCommandParameter(SpcCommandParameter commandParameter);
    }
}