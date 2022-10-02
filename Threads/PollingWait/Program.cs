namespace PollingWait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before polling thread");
            var pollComplete = false;

            var pollingThread = new Thread(() =>
            {
                Console.WriteLine("Inside polling thread");
                Thread.Sleep(500);
                //Set complete
                pollComplete = true;    
            });

            pollingThread.Start();

            while (!pollComplete)
            {
                Console.WriteLine("Polling...");
                Thread.Sleep(10);
            }

            Console.WriteLine("After polling thread");
            Console.ReadLine();
        }
    }
}