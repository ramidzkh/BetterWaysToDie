using BetterWaysToDie.Builder;
using BetterWaysToDie.Mod;
using BetterWaysToDie.Registry;

namespace BetterWaysToDie.BetterWaysToDie
{
    public class BetterWaysToDie : IMod
    {
        public void Initialize()
        {
            Registry<Block>.Event += registry =>
            {
                new BlockBuilder<Block>("test")
                    .Inherit(registry["terrStone"])
                    .Register(registry);
            };

            // var windowManager = GameManager.Instance.As<GameManagerAccessor>().windowManager;
            // var testGuiWindow = new TestGuiWindow(GameManager.Instance);
            // windowManager.Add("testWindow", testGuiWindow);
            // testGuiWindow.Open();
        }
    }
}
