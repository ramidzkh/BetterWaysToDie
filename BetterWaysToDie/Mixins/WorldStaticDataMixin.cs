using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using UnityEngine;

namespace BetterWaysToDie.Mixins
{
    [Mixin(typeof(WorldStaticData))]
    public class WorldStaticDataMixin
    {
    }

    [Mixin(WorldStaticDataTargets.Methods.Init_StateMachine)]
    public class InitMixin
    {
        [Inject(_Init_d__10Targets.Methods.MoveNext, AtLocation.Invoke,
            Target = _Init_d__10Targets.Methods.MoveNextInjects
                .MeshDescriptionCollection_LoadTextureArraysForQuality_Boolean)]
        private void injectCustomMeshes()
        {
            Debug.LogWarning("I think this worked");
        }
    }
}
