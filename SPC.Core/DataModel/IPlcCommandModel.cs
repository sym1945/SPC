using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public interface IPlcCommandModel
    {
        bool OnTrigger();
        bool OffTrigger();
        void OnTriggerAction();
        void OffTriggerAction();

    }
}
