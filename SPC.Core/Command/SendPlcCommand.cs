namespace SPC.Core
{
    public abstract class SendPlcCommand<T> : PlcCommandBase<T>, ISendPlcCommand
        where T: SPCBase
    {
        public abstract void AddCommandParameter(PlcCommandParameter commandParameter);
    }
}