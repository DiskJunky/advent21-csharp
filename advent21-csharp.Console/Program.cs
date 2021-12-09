using advent21_csharp.Console.Challenges;

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
            (new Day01_Part1()).Run();
            (new Day01_Part2()).Run();
        }
    }

}
