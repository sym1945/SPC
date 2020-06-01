using SPC.Core;

namespace SampleEqp
{
    public class GlassCommandParam : SpcCommandParameter
    {
        public GlassData GlassData { get; }

        public GlassCommandParam(GlassData glassData)
        {
            GlassData = glassData;
        }
    }
}