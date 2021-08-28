using BetterWaysToDie.Gui;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using UnityEngine;

namespace BetterWaysToDie.Mixins.Gui {
    [Mixin(typeof(MainMenuMono))]
    public class MainMenuMonoMixin {
        [Shadow] private NGUIWindowManager nguiWindowManager;

        [Inject(MainMenuMonoTargets.Methods.Start, AtLocation.Invoke,
            Target = MainMenuMonoTargets.Methods.StartInjects.Cursor_set_visible_Boolean)]
        private void StartMenuEntrypoint() {
            Debug.Log(EnumNGUIWindow.Version);
            var label = nguiWindowManager.GetWindow(EnumNGUIWindow.Version).GetComponent<UILabel>();
            Debug.Log(label.fontSize);
            Debug.Log(label.transform.localScale);
            Debug.Log(label.transform.position);
            label.text += "\nThis Is a Test";
            
            var windowManager = ((GameManager.Instance as object) as GameManagerAccessor).windowManager;
            var testGuiWindow = new TestGuiWindow(GameManager.Instance);
            windowManager.Add("testWindow", testGuiWindow);
            testGuiWindow.open();
        }
    }
}