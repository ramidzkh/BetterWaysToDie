using System.Collections.Generic;
using BetterWaysToDie.Registry;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;

namespace BetterWaysToDie.Mixins
{
    [Mixin(typeof(Block))]
    public class BlockMixin
    {
        [Shadow] private static Dictionary<string, Block> nameToBlock;
        [Shadow] private static Dictionary<string, Block> nameToBlockCaseInsensitive;

        [Inject(BlockTargets.Methods.AssignIds, AtLocation.Head)]
        [Unique]
        private static void PostXmlCreateBlocks()
        {
            var registry = new DictionaryRegistry<Block>();

            // Copy existing blocks over
            foreach (var pair in nameToBlock)
            {
                registry[pair.Key] = pair.Value;
            }

            // Invoke registry event
            Registry<Block>.Invoke(registry);

            // Copy blocks back over
            nameToBlock.Clear();
            nameToBlockCaseInsensitive.Clear();

            foreach (var pair in registry.GetEntries())
            {
                nameToBlock.Add(pair.Key, pair.Value);
                nameToBlockCaseInsensitive.Add(pair.Key, pair.Value);
            }
        }
    }
}
