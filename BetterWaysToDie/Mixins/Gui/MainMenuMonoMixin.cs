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
            label.text += "\nThis Is a Test";
        }
    }
}