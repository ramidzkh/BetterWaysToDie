using SharpILMixins.Annotations;

namespace BetterWaysToDie.Mixins {
    
    [Accessor(typeof(GameManager))]
    public abstract class GameManagerAccessor {
        public GUIWindowManager windowManager;
    }
}