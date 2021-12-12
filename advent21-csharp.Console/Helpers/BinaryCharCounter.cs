namespace advent21_csharp.Console.Helpers
{
    /// <summary>
    /// This class is used to track the frequency of binary digits.
    /// </summary>
    internal class BinaryCharCounter
    {
        private readonly int[] _counter = {0, 0};

        /// <summary>
        /// This increments the count of the <see cref="digit"/> supplied.
        /// </summary>
        /// <param name="digit">The binary digit to track.</param>
        /// <exception cref="ArgumentException">Thrown if the value supplied is not a binary digit.</exception>
        public void Track(char digit)
        {
            if (digit != '0' && digit != '1')
            {
                throw new ArgumentException("Value must be a 1 or a 0.", nameof(digit));
            }

            int index = int.Parse(digit.ToString());
            _counter[index]++;
        }

        /// <summary>
        /// Gets the most frequent digit of those tracked.
        /// </summary>
        public int MostFrequent 
        { get { return _counter[0] > _counter[1] ? 0 : 1; } }

        /// <summary>
        /// Gets the least frequent digit of those tracked.
        /// </summary>
        public int LeastFrequent
        { get { return Math.Abs(MostFrequent - 1); } }

        /// <summary>
        /// Returns a string representation of the current state of the <see cref="BinaryCharCounter"/> instance.
        /// </summary>
        /// <returns>The string representation of the instance.</returns>
        public override string ToString()
        {
            return $"Most: {MostFrequent}, Least: {LeastFrequent}";
        }
    }
}
