using advent21_csharp.Console.Challenges;
using advent21_csharp.Console.Helpers;

namespace advent21_csharp.Console
{
    /// <summary>
    /// This runs the various challenge results.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main program entry point.
        /// </summary>
        /// <param name="args">The arguments passed into the program.</param>
        public static void Main(params string[] args)
        {
            var challenges = ReflectionHelper.GetImplementationsOf<IChallenge>();
            foreach (var challengeType in challenges)
            {
                var challenge = Activator.CreateInstance(challengeType) as IChallenge;
                challenge?.Run();
            }
        }
    }
}
