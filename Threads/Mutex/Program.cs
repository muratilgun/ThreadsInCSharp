namespace Mutex
{
    internal class Program
    {
        private static System.Threading.Mutex _mutex = new System.Threading.Mutex();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }

            // throw exception
            //Thread.Sleep(3000);
            //_mutex.ReleaseMutex();

            Console.ReadKey();
        }

        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
            _mutex.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed...");
            _mutex.ReleaseMutex();
        }
    }
}