using BetterWaysToDie.Mixins.Accessor;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using SharpILMixins.Annotations.Parameters;
using UnityEngine;

namespace BetterWaysToDie.Mixins.Gui
{
    [Mixin(typeof(GUIWindowConsole))]
    public class GUIWindowConsoleMixin
    {
        [Shadow] private GUIStyle labelStyle;

        [Unique]
        private void DrawLabel(string name)
        {
            GUILayout.Label(name, labelStyle);
            GUILayout.Space(-10f);
        }

        [Inject(GUIWindowConsoleTargets.Methods.OnGUI,
            AtLocation.Invoke,
            Target = GUIWindowConsoleTargets.Methods.OnGUIInjects.GUILayout_Label_String_GUIStyle_GUILayoutOption_,
            Shift = Shift.After)]
        [Unique]
        private void PrintStackTraceLines(bool _inputActive,
            [InjectLocal(10)] GUIWindowConsole_ConsoleLineAccessor consoleLine)
        {
            if (!string.IsNullOrEmpty(consoleLine.stackTrace) &&
                (consoleLine.type == LogType.Error || consoleLine.type == LogType.Exception))
                DrawLabel(consoleLine.stackTrace);
        }

        [Redirect(Method = GUIWindowConsoleTargets.Methods.OnGUI,
            At = AtLocation.Invoke,
            Target = GUIWindowConsoleTargets.Methods.OnGUIInjects.GUI_Box_Rect_String)]
        [Unique]
        private static void ChangeBackgroundColour(Rect rect, string text)
        {
            GUI.Box(rect, "");
            GUI.Box(rect, "");
            GUI.Box(rect, "");
            GUI.Box(rect, "");
            GUI.Box(rect, "");
            //TODO: maybe add a proper skin? this just draws multiple rectangles. not the best idea.
        }
    }
}
