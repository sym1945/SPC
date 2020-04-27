namespace SPC.Core
{
    public abstract class RecvBitChange<T> : RecvPlcCommand<T>
        where T: SPCBase
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