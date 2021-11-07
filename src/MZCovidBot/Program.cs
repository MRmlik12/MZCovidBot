namespace MZCovidBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Startup().Run().GetAwaiter().GetResult();
        }
    }
}