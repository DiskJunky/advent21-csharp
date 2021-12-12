namespace advent21_csharp.Console.Helpers
{
    /// <summary>
    /// This reads Direction details from a file data source.
    /// </summary>
    internal class DirectionReader : FileReader
    {
        /// <summary>
        /// The default constructor used to instantiate the object.
        /// </summary>
        /// <param name="filePath">The full file path of the file containing directions.</param>
        public DirectionReader(string filePath) : base(filePath)
        {
        }

        /// <summary>
        /// Loads the file specified by the FilePath property.
        /// </summary>
        /// <returns>The deserialized contents of the file.</returns>
        public new List<Direction> Load()
        {
            var directions = base.Load()
                                 .Select(l => new Direction(l ?? string.Empty))
                                 .ToList();

            return directions;
        }
    }
}
