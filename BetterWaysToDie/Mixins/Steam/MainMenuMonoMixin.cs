using SharpILMixins.Annotations;

namespace BetterWaysToDie.Mixins.Steam
{
    [Mixin(typeof(MainMenuMono))]
    public class MainMenuMonoMixin
    {
        [Overwrite]
        public bool CheckLogin()
        {
            return true;
        }
    }
}