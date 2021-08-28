using BetterWaysToDie.Gui;
using BetterWaysToDie.Mixins.Accessor;
using BetterWaysToDie.Mod;
using BetterWaysToDie.Registry;

namespace BetterWaysToDie.BetterWaysToDie
{
    public class BetterWaysToDie : IMod
    {
        public void Initialize()
        {
            PostXmlBlockEvent.Event += registry =>
            {
                registry.RegisterBlock(
                    "test_block",
                    null,
                    typeof(BlockForge),
                    "Mstone_scrap",
                    new BlockShapeCube()
                );
            };
            
            var windowManager = ((GameManager.Instance as object) as GameManagerAccessor).windowManager;
            var testGuiWindow = new TestGuiWindow(GameManager.Instance);
            windowManager.Add("testWindow", testGuiWindow);
            // testGuiWindow.open();
        }
    }
}
