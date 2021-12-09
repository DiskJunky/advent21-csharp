namespace advent21_csharp.Console.Tests.Challenges
{
    /// <summary>
    /// The challenge implementation for the second part of the first day.
    /// </summary>
    public class Day01_Part2 : IChallenge
    {
        /// <summary>
        /// Executes the challenge results for the second part of the first day.
        /// </summary>
        public void Run()
        {
            string filePath = Path.Combine("Tests", "Data", "day1.txt");
            var soundingReader = new SoundingReader(filePath);
            var readings = soundingReader.Load();

            // count how many increased from the second setting
            int lastReading = 0;
            int increaseCount = 0;
            int queueCapacity = 3;
            var queue = new Queue<int>(queueCapacity);
            for (int i = 0; i < readings.Count; i++)
            {
                if (queue.Count >= queueCapacity) queue.Dequeue();
                queue.Enqueue(readings[i]);
                if (queue.Count < queueCapacity) continue;
                
                int current = queue.ToArray().Sum();
                if (lastReading == 0) lastReading = current;    // don't count the first reading as an increase
                
                if (current > lastReading) increaseCount++;
                lastReading = current;
            }

            System.Console.WriteLine($"{GetType().Name}: Found [{increaseCount}] sounding sets that increased.");
        }
    }
}
