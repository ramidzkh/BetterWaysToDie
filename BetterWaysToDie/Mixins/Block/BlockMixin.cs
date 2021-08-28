using BetterWaysToDie.Registry;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using UnityEngine;

namespace BetterWaysToDie.Mixins.Block {
    /// <summary>
    /// Allows us to hook in and create/modify blocks without using any XML
    /// </summary>
    [Mixin(typeof(global::Block))]
    public class BlockMixin {
        
        [Inject(BlockTargets.Methods.AssignIds, AtLocation.Head)]
        private static void postXmlCreateBlocks() {
            PostXmlBlockEvent.invoke();
            Debug.Log("We are meant to create the fuennnnnn");
        }
    }
}