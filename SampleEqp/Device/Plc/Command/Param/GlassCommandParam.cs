using SPC.Core;

namespace SampleEqp
{
    public class GlassCommandParam : PlcCommandParameter
    {
        public GlassData GlassData { get; }

        public GlassCommandParam(GlassData glassData)
        {
            GlassData = glassData;
        }
    }
}