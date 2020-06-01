using SPC.Core;

namespace SampleEqp
{
    public class PlcDeviceManager : SpcDeviceManager
    {
        public PlcCommandBits PlcCommandBits { get; private set; }

        public PlcStatusWords PlcStatusWords { get; private set; }

        public PlcLoadGlassData PlcLoadGlassData { get; private set; }

        public PlcUnloadGlassData PlcUnloadGlassData { get; private set; }

        public CimReplyBits CimReplyBits { get; private set; }



        public PlcDeviceManager()
        {
            PlcCommandBits = new PlcCommandBits();
            PlcStatusWords = new PlcStatusWords();
            PlcLoadGlassData = new PlcLoadGlassData();
            PlcUnloadGlassData = new PlcUnloadGlassData();
            CimReplyBits = new CimReplyBits();

            Add(PlcCommandBits);
            Add(PlcStatusWords);
            Add(PlcLoadGlassData);
            Add(PlcUnloadGlassData);
            Add(CimReplyBits);
        }

    }
}
