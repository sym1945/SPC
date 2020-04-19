namespace SPC.Core
{
    public static class SPCContainer
    {
        private static SPC Instance;

        public static SPC GetSPC()
        {
            return Instance;
        }

        public static void SetSPC(SPC spc)
        {
            Instance = spc;
        }
    }
}
