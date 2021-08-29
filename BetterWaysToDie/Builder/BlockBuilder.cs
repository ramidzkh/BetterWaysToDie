using UnityEngine;

namespace BetterWaysToDie.Builder {
    /// <summary>
    /// Makes adding blocks to the game as simple as we can make it
    /// </summary>
    public class BlockBuilder {
        private readonly string name;

        public BlockBuilder(string name)
        {
            this.name = name;
        }

        public Block Build()
        {
            // var block = new Block();
            // block.SetBlockName(name);
            // block.Init();
            return null;
        }
    }
}