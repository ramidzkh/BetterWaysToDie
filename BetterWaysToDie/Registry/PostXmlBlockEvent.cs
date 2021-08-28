using System;
using UnityEngine;

namespace BetterWaysToDie.Registry {
    public delegate void Callback(BlockRegistry registry);

    public static class PostXmlBlockEvent {
        public static event Callback Event;

        public static void invoke() {
            Event?.Invoke(Registries.instance.BlockRegistry);
        }
    }

    public class BlockRegistry {
        public Block registerBlock(
            string name,
            string extends,
            Type clazz,
            string material,
            BlockShape shape
        ) {
            var block = new Block();

            var extendingBlock = Block.GetBlockByName(extends);
            if (extendingBlock == null) {
                throw new Exception($"Block '{name}' is trying to extend a block which doesnt exist. ({extends})'");
            }
            DynamicProperties dynamicProperties = new DynamicProperties();
            // dynamicProperties.Classes

            var blockPlacement = (BlockPlacement) Activator.CreateInstance(typeof(BlockPlacementTowardsPlacerInverted));
            Debug.Log("Someone tried to register a block called " + name);
            return block;
        }
    }
}