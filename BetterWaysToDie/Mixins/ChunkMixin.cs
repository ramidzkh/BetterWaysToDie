using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using SharpILMixins.Annotations.Parameters;

namespace BetterWaysToDie.Mixins
{
    [Mixin(typeof(Chunk))]
    public class ChunkMixin
    {
        [Inject(ChunkTargets.Methods.GetBlock_Vector3i, AtLocation.Head)]
        [Unique]
        private BlockValue GetBlock(Vector3i pos, [InjectCancelParam] out bool cancel)
        {
            cancel = pos.x % 2 == 0;
            return BlockValue.Air;
        }
    }
}
