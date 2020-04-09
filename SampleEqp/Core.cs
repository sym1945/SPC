using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEqp
{
    public class Core
    {
        public Equipment Equipment { get; private set; }

        public PlcHandler PlcHandler { get; private set; }


        public Core()
        {
            Equipment = new Equipment();
            PlcHandler = new PlcHandler();
        }

    }


}
