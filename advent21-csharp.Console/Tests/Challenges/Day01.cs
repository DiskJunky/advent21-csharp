using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent21_csharp.Console.Tests.Challenges
{
    /// <summary>
    /// The challenge implementation for the first day.
    /// </summary>
    public class Day01 : IChallenge
    {
        /// <summary>
        /// Executes the challenge results for the first day.
        /// </summary>
        public void Run()
        {
            string filePath = Path.Combine("Tests", "Data", "day1.txt");
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

            System.Console.WriteLine($"Found [{increaseCount}] soundings that increased.");

        }
    }
}
