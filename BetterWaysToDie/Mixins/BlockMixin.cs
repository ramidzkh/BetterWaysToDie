using System.Collections.Generic;
using BetterWaysToDie.Registry;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;

namespace BetterWaysToDie.Mixins
{
    /// <summary>
    /// Allows us to hook in and create/modify blocks without using any XML
    /// </summary>
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
            foreach (var (key, value) in nameToBlock)
            {
                registry[key] = value;
            }

            // Invoke registry event
            Registry<Block>.Invoke(registry);

            // Copy blocks back over
            nameToBlock.Clear();
            nameToBlockCaseInsensitive.Clear();

            foreach (var (key, value) in registry.GetEntries())
            {
                nameToBlock.Add(key, value);
                nameToBlockCaseInsensitive.Add(key, value);
            }
        }
    }
}
