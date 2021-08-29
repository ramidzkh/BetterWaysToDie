using SharpILMixins.Annotations;

namespace BetterWaysToDie.Mixins.Steam
{
    //TODO: only disable steam when debugging. don't want piracy
    [Mixin(typeof(global::Steam))]
    public class SteamMixin
    {
        [Overwrite]
        public static void InitClientAPI()
        {
        }

        [Overwrite]
        public static void InitCallbacks(bool _dedicated)
        {
        }

        [Overwrite]
        public static string GetCountry()
        {
            return "??";
        }

        [Overwrite]
        public static string GetAppLanguage()
        {
            return "english";
        }
        
        [Overwrite]
        protected void Update()
        {
        }
        
        [Overwrite]
        protected void LateUpdate()
        {
        }
    }
}