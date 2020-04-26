﻿namespace SPC.Core
{
    public abstract class RecvPlcCommand<T> : PlcCommandBase<T>, IRecvPlcCommand
        where T : SPCBase
    {
        public abstract bool CanExecute();

        public abstract void Execute();
    }
}