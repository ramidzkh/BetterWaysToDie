using SharpILMixins.Annotations;

namespace BetterWaysToDie.Mixins.Accessor
{
    [Accessor(typeof(WorldStaticData))]
    public static class WorldStaticDataAccessor
    {
        public static readonly XmlLoadInfoAccessor[] xmlsToLoad = new XmlLoadInfoAccessor[43];
    }
}
