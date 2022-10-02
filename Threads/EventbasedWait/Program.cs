namespace EventbasedWait
{
    internal class Program
    {
        private static event Action EventFinished = () => { };
        static void Main(string[] args)
        {
            Console.WriteLine("Before event thread");

            var eventThread = new Thread(() =>
            {
                Console.WriteLine("Inside event thread");
                Thread.Sleep(500);

                // Fire completed event
                EventFinished();
            });

            // Hook into callback event

            EventFinished += () =>
            {
                //Called back from thread
                Console.WriteLine("Event thread callback on complete");
            };


            eventThread.Start();


            Console.WriteLine("After event thread");
            Thread.Sleep(1000);

            Console.WriteLine("***********************************************");


            Console.WriteLine("Before event method thread");

            EventThreadCallbackMethod(() =>
            {
                //Called back from thread
                Console.WriteLine("Event thread callback on complete");
            });

            Console.WriteLine("After event method thread");
            Thread.Sleep(1000);
            Console.WriteLine("***********************************************");


            Console.ReadLine();
        }

        private static void EventThreadCallbackMethod(Action completed)
        {
            new Thread(() =>
            {
                Console.WriteLine("Inside event thread method");
                Thread.Sleep(500);
                completed();
            }).Start();

        }
    }
}