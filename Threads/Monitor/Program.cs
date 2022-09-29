namespace Monitor
{
    internal class Program
    {
        private static object _locker = new object();

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
            try
            {
                System.Threading.Monitor.Enter(_locker);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting..");
                Thread.Sleep(2000);
                //throw new Exception("Exception");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed..");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                System.Threading.Monitor.Exit(_locker);

            }

        }
    }
}