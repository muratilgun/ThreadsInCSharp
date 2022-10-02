namespace JoinThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1. #####");
            }).Start();
            Console.WriteLine("2. #####");

            var blockingThread = new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("3. #####");

            });

            blockingThread.Start();
            blockingThread.Join();
            Console.WriteLine("4. #####");

            // Console.ReadLine();

        }
    }
}