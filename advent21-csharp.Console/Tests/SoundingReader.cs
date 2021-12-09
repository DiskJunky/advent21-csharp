using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent21_csharp.Console.Tests
{
    /// <summary>
    /// This class is used to read data from a data source that contains sounding data.
    /// </summary>
    public class SoundingReader
    {
        private string? _filePath;

        /// <summary>
        /// Initializes the <c type="SoundingReader"></c> with the specifiedl value in <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">The file name and path of the file to load.</param>
        public SoundingReader(string? filePath)
        {
            FilePath = filePath;
        }
        
        public string? FilePath { get => _filePath; protected set => _filePath = value; }

        /// <summary>
        /// Load the file specified in FilePath and returns them.
        /// </summary>
        /// <returns>The list of soundings in the data.</returns>
        public List<int> Load()
        {
            List<string?> soundings = new List<string?>();

            soundings = new List<string?>(File.ReadAllLines(FilePath));
            var intSoundings = soundings.Where(s => !string.IsNullOrWhiteSpace(s))
                                        .Select(s => int.Parse(s))
                                        .ToList<int>();

            return intSoundings;
        }
    }
}
