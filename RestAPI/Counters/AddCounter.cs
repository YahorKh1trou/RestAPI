namespace RestAPI.Counters
{
    public class AddCounter
    {
        public int сounter = 1;
        private static AddCounter Сounter = null;
        protected AddCounter() { }
        public static AddCounter Initialize()
        {
            if (Сounter == null)
                Сounter = new AddCounter();
            return Сounter;
        }
        public int Increment()
        {
            return Сounter.сounter++;
        }
    }
}
