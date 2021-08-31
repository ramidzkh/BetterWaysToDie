using System;
using System.Collections.Generic;
using BetterWaysToDie.Registry;

namespace BetterWaysToDie.Builder
{
    public class BlockBuilder<T>
        where T : Block, new()
    {
        private readonly string _name;
        private readonly T _block = new T();

        public BlockBuilder(string name)
        {
            _name = name;
        }

        public BlockBuilder<T> Direct(Action<T> action)
        {
            action(_block);
            return this;
        }

        public BlockBuilder<T> Inherit(Block block)
        {
            return Inherit(block, new[] { Block.PropCreativeMode });
        }

        public BlockBuilder<T> Inherit(Block block, IEnumerable<string> exclude)
        {
            _block.Properties.CopyFrom(block.Properties, new HashSet<string>(exclude));
            _block.RepairItems.AddRange(block.RepairItems);

            foreach (var (dropEvent, list) in block.itemsToDrop)
            {
                foreach (var s in list)
                {
                    _block.AddDroppedId(dropEvent,
                        s.name,
                        s.minCount,
                        s.maxCount,
                        s.prob,
                        s.stickChance,
                        s.toolCategory,
                        s.tag);
                }
            }

            return Place(block.BlockPlacementHelper)
                .Material(block.blockMaterial)
                .Shape(block.shape)
                .Mesh(MeshDescription.meshes[block.shape.MeshIndex])
                .StackNumber(block.Stacknumber)
                //.Light(block.GetLightValue())
                .EconomicValue(block.EconomicValue)
                .Collide((Collide) block.BlockingType)
                .PathSolid(block.IsPathSolid)
                //.Texture()
                .Tag(block.BlockTag)
                .StabilityFull(block.StabilityFull)
                .StabilityIgnore(block.StabilityIgnore);
        }

        public BlockBuilder<T> Place(BlockPlacement placement)
        {
            _block.BlockPlacementHelper = placement;
            return this;
        }

        public BlockBuilder<T> Material(MaterialBlock material)
        {
            _block.blockMaterial = material;
            return this;
        }

        public BlockBuilder<T> Shape(BlockShape shape)
        {
            _block.shape = shape;
            return this;
        }

        // ShapeMinBB

        public BlockBuilder<T> Mesh(MeshDescription mesh)
        {
            _block.shape.MeshIndex = (byte) Array.IndexOf(MeshDescription.meshes, mesh);
            _block.MeshIndex = (byte) _block.shape.MeshIndex;
            return this;
        }

        public BlockBuilder<T> StackNumber(int stack)
        {
            _block.Stacknumber = stack;
            return this;
        }

        public BlockBuilder<T> Light(float light)
        {
            _block.SetLightValue(light);
            return this;
        }

        public BlockBuilder<T> EconomicValue(float value)
        {
            _block.EconomicValue = value;
            return this;
        }

        public BlockBuilder<T> Collide(Collide collide)
        {
            _block.BlockingType = (int) collide;
            return this;
        }

        public BlockBuilder<T> PathSolid(bool solid)
        {
            _block.IsPathSolid = solid;
            return this;
        }

        public BlockBuilder<T> Texture(int texture)
        {
            _block.SetSideTextureId(texture);
            return this;
        }

        public BlockBuilder<T> Texture(BlockFace face, int texture)
        {
            _block.SetSideTextureId(face, texture);
            return this;
        }

        public BlockBuilder<T> Tag(BlockTags tag)
        {
            _block.BlockTag = tag;
            return this;
        }

        public BlockBuilder<T> StabilityFull(bool full)
        {
            _block.StabilityFull = full;
            return this;
        }

        public BlockBuilder<T> StabilityIgnore(bool ignore)
        {
            _block.StabilityIgnore = ignore;
            return this;
        }

        public BlockBuilder<T> Repair(ItemClass item, int value)
        {
            _block.RepairItems.Add(new Block.SItemNameCount { ItemName = item.GetItemName(), Count = value });
            return this;
        }

        public BlockBuilder<T> Drop(ItemClass drop, EnumDropEvent dropEvent, int min = 1, int max = 1,
            float probability = 1, float stickChance = 1, string toolCategory = null, string tag = "")
        {
            _block.AddDroppedId(dropEvent, drop.GetItemName(), min, max, probability, stickChance, toolCategory, tag);
            return this;
        }

        public T Register(IRegistry<Block> registry)
        {
            _block.shape.Init(_block);
            _block.Init();
            registry[_name] = _block;
            return _block;
        }
    }

    [Flags]
    public enum Collide
    {
        Sight = 1,
        Movement = 2,
        Bullet = 4,
        Rocket = 8,
        Melee = 16,
        Arrow = 32
    }
}
