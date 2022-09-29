namespace Semaphore
{
    internal class Program
    {
        private static System.Threading.Semaphore _semaphore = new System.Threading.Semaphore(1,1);
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }

            Console.ReadKey();
        }

        public static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
            _semaphore.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing Completed...");
            _semaphore.Release();
        }
    }

}