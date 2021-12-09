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

            System.Console.WriteLine($"{GetType().Name}: Position at [{horizontalDistance},{verticalDistance}], " +
                                     $"totalled: {(horizontalDistance * verticalDistance).ToString("G")}.");
        }

        private enum MovementDirection
        {
            None = 0,
            Up = 1,
            Forward = 2,
            Down = 3,
        }

        private class Direction
        {
            private MovementDirection _movementDirection = MovementDirection.None;
            private int _distance = 0;

            /// <summary>
            /// This instantiates the object with the details in the serialized data.
            /// The data must be in the form;
            /// <para>
            ///     "[MovementDirection] [Distance]"
            /// </para>
            /// Where [MovementDirection] is a value of MovementDirection and [Direction]
            /// is an integer value. The values should be space delimited, on a single line.
            /// Only the first two space separates values are parsed.
            /// </summary>
            /// <param name="serializedDirection"></param>
            public Direction(string serializedDirection)
            {
                if (string.IsNullOrWhiteSpace(serializedDirection))
                {
                    throw new ArgumentNullException(nameof(serializedDirection));
                }

                var words = serializedDirection.Split(' ');
                if (words.Length < 2)
                {
                    throw new ArgumentException("There is not enough data to parse. There must be at least two space separated values.", nameof(SequencePosition));
                }

                // parse the movement direction
                MovementDirection movementDirection;
                if (!Enum.TryParse<MovementDirection>(words[0], ignoreCase: true, out movementDirection))
                {
                    throw new ArgumentException($"Unable to parse value [{words[0]}] as a {nameof(MovementDirection)}", serializedDirection);
                }
                MovementDirection = movementDirection;

                // parse the value
                int distance;
                if (!int.TryParse(words[1], out distance))
                {
                    throw new ArgumentException($"Unable to parse value [{words[0]}] as a {nameof(MovementDirection)}", serializedDirection);
                }
                Distance = distance;
            }

            public MovementDirection MovementDirection 
            { 
                get => _movementDirection; 
                protected set => _movementDirection = value; 
            }

            public int Distance 
            { 
                get => _distance; 
                set => _distance = value; 
            }
        }

        private class DirectionReader : FileReader
        {
            public DirectionReader(string? filePath) : base(filePath)
            {
            }

            public List<Direction> Load()
            {
                var directions = base.Load()
                                     .Select(l => new Direction(l))
                                     .ToList();

                return directions;
            }
        }
    }
}
