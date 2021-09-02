using SharpILMixins.Annotations;

namespace BetterWaysToDie.Mixins.Accessor
{
    [Accessor(typeof(WorldStaticData))]
    public class WorldStaticDataAccessor
    {
        public static MeshDescriptionCollection meshDescCol;
    }
}
