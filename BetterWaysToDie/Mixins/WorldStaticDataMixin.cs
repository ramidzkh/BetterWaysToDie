using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;

namespace BetterWaysToDie.Mixins
{
    [Mixin(typeof(WorldStaticData))]
    public class WorldStaticDataMixin
    {
        [Inject(WorldStaticDataTargets.Methods.handleReceivedConfigs, AtLocation.Return)]
        private void HandleReceivedConfigs()
        {
            // TODO: Capture IEnumerator. Maybe overwriting would be easier?
            // This would be the ideal place for all the registry events as you can load the XML entries first, call the events
            // which can modify them, and then we get the values from there and stick it back here
        }
    }
}
