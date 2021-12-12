namespace advent21_csharp.Console.Helpers
{
    /// <summary>
    /// This is used to compare two instances of type T.
    /// </summary>
    internal class TypeComparer : IComparer<Type>
    {
        /// <summary>
        /// This compares two instances of type Type.
        /// </summary>
        /// <param name="x">The first instance to compare.</param>
        /// <param name="y">The second instance to compare.</param>
        /// <returns>The result of the comparison.</returns>
        public int Compare(Type? x, Type? y)
        {
            return -string.CompareOrdinal(x?.FullName, y?.FullName);
        }
    }

}
