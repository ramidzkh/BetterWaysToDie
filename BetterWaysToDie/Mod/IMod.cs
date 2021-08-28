namespace BetterWaysToDie.Mod
{
    /// <summary>
    /// Entrypoint into creating mods with the Better Ways To Die framework
    /// </summary>
    public interface IMod
    {
        /// <summary>
        /// Run once during early initialization. Can be used to register event listeners
        /// </summary>
        void Initialize();
    }
}
