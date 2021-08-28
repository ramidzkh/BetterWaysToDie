namespace BetterWaysToDie.Registry {
    
    public class Registries {
        public static readonly Registries instance = new Registries();

        protected internal readonly BlockRegistry BlockRegistry = new BlockRegistry();
    }
}