namespace SPC.Core
{
    public static class SPCContainer
    {
        private static SPC Instance;

        public static SPC GetSPC()
        {
            return Instance;
        }

        public static T GetSPC<T>()
            where T : SPC
        {
            //TODO: SPC 타입별로 관리
            return (T)Instance;
        }

        public static void SetSPC(SPC spc)
        {
            Instance = spc;
        }
    }
}
