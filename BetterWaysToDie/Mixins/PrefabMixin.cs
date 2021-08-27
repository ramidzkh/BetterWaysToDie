using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using SharpILMixins.Annotations.Parameters;

namespace BetterWaysToDie.Mixins {
    [Mixin(typeof(Prefab))]
    public class PrefabMixin {
        [Inject(PrefabTargets.Methods.GetBlock, AtLocation.Head)]
        [Unique]
        private BlockValue GetBlock(int x, int y, int z, [InjectCancelParam] out bool cancel) {
            cancel = (x ^ y ^ z) % 2 == 0;
            return BlockValue.Air;
        }
    }
}
