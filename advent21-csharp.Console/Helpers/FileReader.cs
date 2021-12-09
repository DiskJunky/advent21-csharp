namespace advent21_csharp.Console.Helpers
{
    /// <summary>
    /// This will load a text file from the specified location.
    /// </summary>
    public class FileReader
    {
        private string? _filePath;

        /// <summary>
        /// Initializes the <c type="FileReader"></c> with the specified value in <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">The file name and path of the file to load.</param>
        public FileReader(string? filePath)
        {
            FilePath = filePath;
        }

        public string? FilePath { get => _filePath; protected set => _filePath = value; }

        /// <summary>
        /// Load the file specified in FilePath and returns them.
        /// </summary>
        /// <returns>The list of lines in the data.</returns>
        public List<string> Load()
        {
            var dataLines = new List<string?>(File.ReadAllLines(FilePath));
            var lines = dataLines.Where(s => !string.IsNullOrWhiteSpace(s))
                                 .ToList();

            return lines;
        }
    }
}
