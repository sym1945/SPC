namespace SPC.Core
{
    public abstract class RecvBitChange<T> : RecvCommandBase<T>
        where T: SpcBase
    {
        public abstract BitDevice TriggerBit { get; }

        public override bool CanExecute()
        {
            if (TriggerBit == null)
                return false;

            return TriggerBit.IsChanged;
        }

    }

}