using System.Diagnostics;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;

namespace BetterWaysToDie.Mixins.Gui {
    [Mixin(typeof(MainMenuMono))]
    public class MainMenuMonoMixin {
        [Shadow] private NGUIWindowManager nguiWindowManager;

        [Inject(MainMenuMonoTargets.Methods.Start,
            AtLocation.Invoke,
            Target = MainMenuMonoTargets.Methods.StartInjects.Cursor_set_visible_Boolean)]
        [Unique]
        private void StartMenuEntrypoint()
        {
            // TODO: Is this really the best place for mod initialization?
            Mod.ModManager.Initialize();

            var label = nguiWindowManager.GetWindow(EnumNGUIWindow.Version).GetComponent<UILabel>();
            label.text += "\nThis Is a Test";
        }
    }
}