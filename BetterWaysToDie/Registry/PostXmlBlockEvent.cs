namespace BetterWaysToDie.Registry
{
    public delegate void Callback(BlockRegistry registry);

    public static class PostXmlBlockEvent
    {
        public static event Callback Event;

        internal static void Invoke()
        {
            Event?.Invoke(Registries.BlockRegistry);
        }
    }
}
