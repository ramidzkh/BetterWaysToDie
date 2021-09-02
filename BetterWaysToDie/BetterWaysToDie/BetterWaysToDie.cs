using BetterWaysToDie.Builder;
using BetterWaysToDie.Mod;
using BetterWaysToDie.Registry;
using UnityEngine;

namespace BetterWaysToDie.BetterWaysToDie
{
    public class BetterWaysToDie : IMod
    {
        private static readonly int NormalMapTexture = Shader.PropertyToID("Normal Map");
        private MeshDescription testMesh;

        public void Initialize()
        {
            Registry<MeshDescription>.Event += registry =>
            {
                testMesh = new MeshDescription();
                var mainTexture = Mod.ModManager.LoadTexture("BetterWaysToDie.Res.wood.png", 1024, 1024);
                var normalTexture = Mod.ModManager.LoadTexture("BetterWaysToDie.Res.woodNormal.png", 1024, 1024);
                // ReSharper disable once UseObjectOrCollectionInitializer
                var _material = new Material(Shader.Find("Autodesk Interactive"));
                _material.color = Color.green;
                _material.mainTexture = mainTexture;
                _material.SetTexture(NormalMapTexture, normalTexture);

                testMesh.material = _material;
                testMesh.meshType = VoxelMesh.EnumMeshType.Blocks;
                testMesh.CreateNormalMap = false;

                registry["testMesh"] = testMesh;
            };

            Registry<Block>.Event += registry =>
            {
                new BlockBuilder<Block>("test")
                    .Inherit(registry["terrStone"])
                    .Mesh(testMesh)
                    .Register(registry);
            };

            // var windowManager = GameManager.Instance.As<GameManagerAccessor>().windowManager;
            // var testGuiWindow = new TestGuiWindow(GameManager.Instance);
            // windowManager.Add("testWindow", testGuiWindow);
            // testGuiWindow.Open();
        }
    }
}
