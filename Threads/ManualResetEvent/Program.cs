namespace ManualResetEvent
{
    internal class Program
    {
        private static System.Threading.ManualResetEvent _mre = new System.Threading.ManualResetEvent(false);
        static void Main(string[] args)
        {
            //starting writer thread
            new Thread(Write).Start();
            for (int i = 0; i < 5; i++)
            {
                new Thread(Read).Start();
            }
            Console.ReadKey();
        }

        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} Writing...");
            _mre.Reset();
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed...");
            _mre.Set();
        }
        public static void Read()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
            _mre.WaitOne();
            //Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Reading Completed...");

        }
    }
}