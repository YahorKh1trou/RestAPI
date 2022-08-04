namespace RestAPI.Counters
{
    public class AddCounter
    {
        // naming convensions
        public int сounter = 1;
        private static AddCounter Сounter = null;
        private static object _lock = new object();
        protected AddCounter() { }
        // rework singleton to Thread safe implementation
        public static AddCounter Initialize()
        {
            if(Сounter == null)
            {
                lock (_lock)
                {
                    if(Сounter == null)
                    {
                        Сounter = new AddCounter();
                    }
                }
            }
            if (Сounter == null)
                Сounter = new AddCounter();
            return Сounter;
        }
        public int Increment()
        {
            // can be like this
            return сounter++;
        }
    }
}
