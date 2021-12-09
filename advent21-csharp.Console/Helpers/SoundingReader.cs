namespace advent21_csharp.Console.Helpers
{
    /// <summary>
    /// This class is used to read data from a data source that contains sounding data.
    /// </summary>
    public class SoundingReader : FileReader
    {
        /// <summary>
        /// The default constructor used.
        /// </summary>
        /// <param name="filePath">The full path of the file to load.</param>
        public SoundingReader(string? filePath) : base(filePath)
        {
        }

        /// <summary>
        /// Load the file specified in FilePath and returns them.
        /// </summary>
        /// <returns>The list of soundings in the data.</returns>
        public List<int> Load()
        {
            List<string> soundings = base.Load();

            soundings = new List<string?>(File.ReadAllLines(FilePath));
            var intSoundings = soundings.Where(s => !string.IsNullOrWhiteSpace(s))
                                        .Select(s => int.Parse(s))
                                        .ToList<int>();

            return intSoundings;
        }
    }
}
