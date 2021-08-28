using BetterWaysToDie.Gui;
using BetterWaysToDie.Mixins;
using BetterWaysToDie.Mixins.Accessor;
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
                registry["a"] = new Block();
                registry["b"] = new Block();
            };

            var windowManager = GameManager.Instance.As<GameManagerAccessor>().windowManager;
            var testGuiWindow = new TestGuiWindow(GameManager.Instance);
            windowManager.Add("testWindow", testGuiWindow);
            // testGuiWindow.open();
        }
    }
}
