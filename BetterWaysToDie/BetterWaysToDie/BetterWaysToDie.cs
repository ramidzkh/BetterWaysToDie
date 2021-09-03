using BetterWaysToDie.Builder;
using BetterWaysToDie.Mod;
using BetterWaysToDie.Registry;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                testMesh.ShaderName = "Game/Debug Stability";
                testMesh.TexDiffuse = mainTexture;
                testMesh.TexNormal = normalTexture;
                testMesh.meshType = VoxelMesh.EnumMeshType.Blocks;
                testMesh.CreateNormalMap = false;
                testMesh.TextureAtlasClass = nameof(TextureAtlas);

                registry["testMesh"] = testMesh;
            };

            Registry<Block>.Event += registry =>
            {
                new BlockBuilder<Block>("test")
                    .Inherit(registry["woodFrameMaster"])
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
