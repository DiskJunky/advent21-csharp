using advent21_csharp.Console.Helpers;

namespace advent21_csharp.Console.Challenges
{
    /// <summary>
    /// The challenge implementation for the first part of the second day.
    /// </summary>
    public class Day02_Part1 : IChallenge
    {
        /// <summary>
        /// Executes the challenge results for the first part of the second day.
        /// </summary>
        public void Run()
        {
            string filePath = Path.Combine("Tests", "Data", "day01.txt");
            var soundingReader = new SoundingReader(filePath);
            var readings = soundingReader.Load();

            // count how many increased from the second setting
            int lastReading = readings[0];
            int increaseCount = 0;
            for (int i = 1; i < readings.Count; i++)
            {
                int current = readings[i];
                if (current > lastReading)
                {
                    increaseCount++;
                }
                lastReading = current;
            }

            System.Console.WriteLine($"{GetType().Name}: Found [{increaseCount}] soundings that increased.");
        }
    }
}
