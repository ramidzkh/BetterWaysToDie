using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using SharpILMixins.Annotations.Inline;

namespace BetterWaysToDie.Mixins
{
    [Mixin(typeof(Constants))]
    public class ConstantsMixin
    {
        [Shadow] private static string cVersion;

        [Inject(".cctor", AtLocation.Tail)] // Static Constructor
        [Inline]
        private static void Crab()
        {
            cVersion += " (Better Ways To Die)";
        }
    }
}
