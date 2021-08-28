using BetterWaysToDie.Gui;
using BetterWaysToDie.Mixins.Accessor;
using BetterWaysToDie.Registry;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using UnityEngine;

namespace BetterWaysToDie.Mixins.Gui
{
    [Mixin(typeof(MainMenuMono))]
    public class MainMenuMonoMixin
    {
        [Shadow] private NGUIWindowManager nguiWindowManager;

        [Inject(MainMenuMonoTargets.Methods.Start,
            AtLocation.Invoke,
            Target = MainMenuMonoTargets.Methods.StartInjects.Cursor_set_visible_Boolean)]
        [Unique]
        private void StartMenuEntrypoint()
        {
            PostXmlBlockEvent.Event += registry =>
            {
                Debug.Log("Lets register some blocks, shall we?");
                registry.RegisterBlock(
                    "yourmother",
                    null,
                    typeof(BlockForge),
                    "Mstone_scrap",
                    new BlockShapeCube()
                );
            };

            var label = nguiWindowManager.GetWindow(EnumNGUIWindow.Version).GetComponent<UILabel>();
            label.text += "\nThis Is a Test";

            var windowManager = ((GameManager.Instance as object) as GameManagerAccessor).windowManager;
            var testGuiWindow = new TestGuiWindow(GameManager.Instance);
            windowManager.Add("testWindow", testGuiWindow);
            // testGuiWindow.open();
        }
    }
}
