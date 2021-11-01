namespace MZCovidBot
{
    class Program
    {
        static void Main(string[] args)
            => new Startup().Run().GetAwaiter().GetResult();
    }
}
