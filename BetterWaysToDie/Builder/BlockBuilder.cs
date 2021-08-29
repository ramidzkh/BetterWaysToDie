using UnityEngine;

namespace BetterWaysToDie.Builder {
    /// <summary>
    /// Makes adding blocks to the game as simple as we can make it
    /// </summary>
    public class BlockBuilder {
        public BlockBuilder(string name)
        {
            
        }

        public Block Build()
        {
            var block = new Block();
            block.Init();
            return block;
        }
    }
}