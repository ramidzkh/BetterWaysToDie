using SharpILMixins.Annotations;

namespace BetterWaysToDie.Mixins.Accessor
{
    [Accessor(typeof(GameManager))]
    public abstract class GameManagerAccessor
    {
        public GUIWindowManager windowManager;
    }
}
