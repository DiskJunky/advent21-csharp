using advent21_csharp.Console.Helpers;

namespace advent21_csharp.Console.Challenges
{
    /// <summary>
    /// The challenge implementation for the second part of the second day.
    /// </summary>
    public class Day02_Part2 : IChallenge
    {
        /// <summary>
        /// Executes the challenge results for the second part of the second day.
        /// </summary>
        public void Run()
        {
            string filePath = Path.Combine("Tests", "Data", "day02.txt");
            var readings = new DirectionReader(filePath).Load();
            int horizontalDistance = 0;
            int aim = 0;
            int verticalDistance = 0;
            foreach (var reading in readings)
            {
                switch (reading.MovementDirection)
                {
                    case MovementDirection.Forward:
                        horizontalDistance += reading.Distance;
                        verticalDistance += (aim * reading.Distance);
                        break;

                    case MovementDirection.Up:
                        aim -= reading.Distance;
                        break;

                    case MovementDirection.Down:
                        aim += reading.Distance;
                        break;
                }
            }

            int total = horizontalDistance * verticalDistance;
            System.Console.WriteLine($"{GetType().Name}: Position at [{horizontalDistance},{verticalDistance}], " +
                                     $"totalled: {total:G}.");
        }
    }
}
