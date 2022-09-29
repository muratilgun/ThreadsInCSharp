namespace Lock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(DoWork).Start();
            }

            Console.ReadKey();
        }


        public static void DoWork()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting..");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed..");

        }
    }
}