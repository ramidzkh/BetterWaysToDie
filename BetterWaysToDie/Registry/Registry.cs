namespace BetterWaysToDie.Registry
{
    public delegate void RegistryCallback<T>(IRegistry<T> registry);

    public static class Registry<T>
    {
        public static event RegistryCallback<T> Event;

        internal static void Invoke(IRegistry<T> registry)
        {
            Event?.Invoke(registry);
        }
    }
}
