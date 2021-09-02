using BetterWaysToDie.Mixins.Accessor;
using BetterWaysToDie.Registry;
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
        private static readonly int NormalMapTexture = Shader.PropertyToID("Normal Map");
        private const int ModifiedMaxMeshes = 1; //TODO: properly do this

        [Inject(_Init_d__10Targets.Methods.MoveNext, AtLocation.Invoke,
            Target = _Init_d__10Targets.Methods.MoveNextInjects
                .MeshDescriptionCollection_LoadTextureArraysForQuality_Boolean)]
        private void injectCustomMeshes()
        {
            Log.Out("Converting Meshes");
            var registry = new DictionaryRegistry<MeshDescription>();

            foreach (var meshDescription in WorldStaticDataAccessor.meshDescCol.meshes)
            {
                registry[meshDescription.Name] = meshDescription;
            }

            Registry<MeshDescription>.Invoke(registry);
            var meshes = new MeshDescription[registry.GetEntries().Count];

            //FIXME: this sucks. Not sure of a better way which doesnt suck though. using a for loop with #GetEntries() is hard
            var i = 0;
            foreach (var pair in registry.GetEntries())
            {
                pair.Value.Name = pair.Key;
                meshes[i] = pair.Value;
                i++;
            }

            WorldStaticDataAccessor.meshDescCol.meshes = meshes;
        }
    }
}
