using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
