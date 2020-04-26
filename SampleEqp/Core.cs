namespace SampleEqp
{
    public class Core
    {
        public Equipment Equipment { get; private set; }

        public PlcHandler PlcHandler { get; private set; }


        public Core()
        {
            Equipment = new Equipment();
            PlcHandler = new PlcHandler(Equipment);
        }

        
        public void Start()
        {
            PlcHandler.SetUp();
            PlcHandler.Start();
        }

    }


}
