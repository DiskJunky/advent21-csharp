using advent21_csharp.Console.Tests.Challenges;

namespace advent21_csharp.Console
{
    /// <summary>
    /// This runs the various challenge results.
    /// </summary>
    public static class Program
    {
        public static void Main(params string[] args)
        {
            // execute the challenge results
            (new Day01()).Run();
            (new Day02()).Run();
        }
    }

}
