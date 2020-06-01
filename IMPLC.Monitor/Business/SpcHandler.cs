using SPC.Core;

namespace IMPLC.Monitor
{
    public class SpcHandler : SpcBase
    {
        public SpcHandler(string uri) : base(new SpcHandleConfiguration(uri))
        {
        }
    }

}