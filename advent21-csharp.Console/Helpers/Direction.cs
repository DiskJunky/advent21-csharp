namespace advent21_csharp.Console.Helpers
{
    /// <summary>
    /// This class provides details abotu a navigation direction.
    /// </summary>
    internal class Direction
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
        /// <param name="serializedDirection">The serialized direction to get details from.</param>
        public Direction(string serializedDirection)
        {
            if (string.IsNullOrWhiteSpace(serializedDirection))
            {
                throw new ArgumentNullException(nameof(serializedDirection));
            }

            var words = serializedDirection.Split(' ');
            if (words.Length < 2)
            {
                throw new ArgumentException("There is not enough data to parse. There must be at least two space separated values.", nameof(serializedDirection));
            }

            // parse the movement direction
            if (!Enum.TryParse(words[0], ignoreCase: true, out MovementDirection movementDirection))
            {
                throw new ArgumentException($"Unable to parse value [{words[0]}] as a {nameof(MovementDirection)}", serializedDirection);
            }
            MovementDirection = movementDirection;

            // parse the value
            if (!int.TryParse(words[1], out int distance))
            {
                throw new ArgumentException($"Unable to parse value [{words[0]}] as a {nameof(MovementDirection)}", serializedDirection);
            }
            Distance = distance;
        }

        /// <summary>
        /// Gets or sets the movemet direction.
        /// </summary>
        public MovementDirection MovementDirection
        {
            get => _movementDirection;
            protected set => _movementDirection = value;
        }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int Distance
        {
            get => _distance;
            set => _distance = value;
        }
    }
}
