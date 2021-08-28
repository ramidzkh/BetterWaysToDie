using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using SharpILMixins.Annotations.Parameters;

namespace BetterWaysToDie.Mixins {
    [Mixin(typeof(Chunk))]
    public class ChunkMixin {
        [Inject(ChunkTargets.Methods.GetBlock_Vector3i, AtLocation.Head)]
        [Unique]
        private BlockValue GetBlock(Vector3i pos, [InjectCancelParam] out bool cancel) {
            cancel = (pos.x ^ pos.y ^ pos.z) % 2 == 0;
            return BlockValue.Air;
        }

        [Inject(ChunkTargets.Methods.GetBlock_Int32_Int32_Int32, AtLocation.Head)]
        [Unique]
        private BlockValue GetBlock(int x, int y, int z, [InjectCancelParam] out bool cancel) {
            cancel = (x ^ y ^ z) % 2 == 0;
            return BlockValue.Air;
        }
    }
}