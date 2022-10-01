namespace TaskCompletionSource
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            Console.WriteLine("Hello, World!");
            var tsc = new TaskCompletionSource<bool>();
            new Thread(() =>
            {
                Thread.Sleep(1000);
                tsc.TrySetResult(true);

            }).Start();

            var a = tsc.Task.Result;

        }
    }
}