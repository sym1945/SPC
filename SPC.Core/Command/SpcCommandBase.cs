namespace SPC.Core
{
    public abstract class SpcCommandBase<TSpc> : ISpcCommand
        where TSpc : SpcBase
    {
        // TODO : 임시로 추가... 
        public TSpc Spc => SpcContainer.GetSPC<TSpc>();
    }

}
