namespace AutoResetEvent
{
    internal class Program
    {
        private static System.Threading.AutoResetEvent _are = new System.Threading.AutoResetEvent(true);
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }

            Thread.Sleep(3000);
            //_are.Set();
            Console.ReadKey();
        }

        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
            _are.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed...");
            _are.Set();
        }
    }
}