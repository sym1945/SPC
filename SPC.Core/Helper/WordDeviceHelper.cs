namespace SPC.Core
{
    public static class WordDeviceHelper
    {
        public static WordStringDevice AsString(this WordDevice dev)
        {
            return dev as WordStringDevice;
        }

        public static WordShortDevice AsShort(this WordDevice dev)
        {
            return dev as WordShortDevice;
        }

        public static WordUShortDevice AsUShort(this WordDevice dev)
        {
            return dev as WordUShortDevice;
        }

        public static WordIntDevice AsInt(this WordDevice dev)
        {
            return dev as WordIntDevice;
        }

        public static WordUIntDevice AsUInt(this WordDevice dev)
        {
            return dev as WordUIntDevice;
        }

        public static WordLongDevice AsLong(this WordDevice dev)
        {
            return dev as WordLongDevice;
        }

        public static WordULongDevice AsULong(this WordDevice dev)
        {
            return dev as WordULongDevice;
        }

        public static WordFloatDevice AsFloat(this WordDevice dev)
        {
            return dev as WordFloatDevice;
        }

        public static WordDoubleDevice AsDouble(this WordDevice dev)
        {
            return dev as WordDoubleDevice;
        }

    }
}