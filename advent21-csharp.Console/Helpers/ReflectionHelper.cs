namespace advent21_csharp.Console.Helpers
{
    /// <summary>
    /// This class is used to perform various tasks on assemblies.
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// This returns a list of implementations of the specified interface
        /// </summary>
        /// <typeparam name="T">The type of interface to get implementations of.</typeparam>
        /// <returns>The list of found implementations.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<Type> GetImplementationsOf<T>()
            where T : class
        {
            // check if T is an interface
            var tType = typeof(T);
            if (!tType.IsInterface)
            {
                string paramName = nameof(T);
                throw new ArgumentException($"Type {paramName} must be an interface", paramName);
            }

            // get all implementations of the interface that exist in the current
            // assembly
            var type = typeof(T);
            var types = AppDomain.CurrentDomain
                                 .GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => type.IsAssignableFrom(p)
                                             && !p.IsInterface)
                                 .ToList();
            types.Sort(new TypeComparer());

            return types;
        }
    }
}
