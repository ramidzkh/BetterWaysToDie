using SharpILMixins.Annotations;
using UnityEngine;

namespace BetterWaysToDie.Mixins.Accessor
{
    [Accessor("GUIWindowConsole/ConsoleLine")]
    public struct GUIWindowConsole_ConsoleLineAccessor
    {
        public string text;
        public LogType type;
        public string stackTrace;
    }
}
