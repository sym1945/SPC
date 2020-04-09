using SPC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.WPF
{
    public class SendGlassData : PlcCommandParameter
    {
        public string GlassId { get; set; }
    }
}
