namespace SPC.Core
{
    public abstract class SendCommandBase<TParam, TSpc> : SendCommandBase<TSpc>
        where TParam : SpcCommandParameter
        where TSpc : SpcBase
    {
        public abstract void AddCommandParameter(TParam commandParameter);

        public override void AddCommandParameter(SpcCommandParameter commandParameter)
        {
            AddCommandParameter((TParam)commandParameter);
        }
    }

    public abstract class SendCommandBase<T> : SpcCommandBase<T>, ISpcSendCommand
        where T: SpcBase
    {
        public abstract void AddCommandParameter(SpcCommandParameter commandParameter);
    }
}