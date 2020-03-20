using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core.DataModel
{
    public abstract class PlcCommandModel : IPlcCommandModel
    {
        virtual public bool OffTrigger()
        {
            throw new NotImplementedException();
        }

        virtual public void OffTriggerAction()
        {
            throw new NotImplementedException();
        }

        virtual public bool OnTrigger()
        {
            throw new NotImplementedException();
        }

        virtual public void OnTriggerAction()
        {
            throw new NotImplementedException();
        }

        abstract protected void OnTriggerActionStarter();

    }
}
