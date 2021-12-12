using advent21_csharp.Console.Helpers;

namespace advent21_csharp.Console.Challenges
{
    /// <summary>
    /// The challenge implementation for the first part of the third day.
    /// </summary>
    public class Day03_Part1 : IChallenge
    {
        /// <summary>
        /// Executes the challenge results for the first part of the third day.
        /// </summary>
        public void Run()
        {
            string filePath = Path.Combine("Tests", "Data", "day03.txt");
            var readings = new FileReader(filePath).Load();
            if (readings == null)
            {
                System.Console.WriteLine($"Test file [{filePath}] empty.");
                return;
            }

            // peek at the first element to get a determination of the size of the binary value we need to track
            // Note: suppress check as null/empty references are taken care of by the loader
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            int digitCount = readings[0].Length;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            // init the tracker
            var frequencies = new List<BinaryCharCounter>();
            for (int f = 0; f < digitCount; f++)
            {
                frequencies.Add(new BinaryCharCounter());
            }

            // scan the readings for binary digit frequencies
            foreach (var reading in readings)
            {
                // track the frequency of each digit
                for (int i = 0; i < digitCount; i++)
                {
                    frequencies[i].Track(reading[i]);
                }
            }

            // build the binary for most and least frequent
            int mostFrequent = 0;
            int leastFrequent = 0;
            int bitMax = digitCount - 1;
            for (int i = 0; i < digitCount; i++)
            {
                int mf = frequencies[i].MostFrequent;
                int lf = frequencies[i].LeastFrequent;

                // bit shift based on size of binary
                mf = mf << (bitMax - i);
                lf = lf << (bitMax - i);

                mostFrequent += mf;
                leastFrequent += lf;
            }

            // Note: gamma=most frequent, epislon = last frequent
            long powerConsumption = mostFrequent * leastFrequent;
            System.Console.WriteLine($"{GetType().Name}: Gamma/Epsilon [{mostFrequent},{leastFrequent}], " +
                                     $"totalled: {powerConsumption:G}.");
        }
    }
}
