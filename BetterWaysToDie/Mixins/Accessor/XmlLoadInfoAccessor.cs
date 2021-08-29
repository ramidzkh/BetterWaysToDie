using System;
using System.Collections;
using SharpILMixins.Annotations;

namespace BetterWaysToDie.Mixins.Accessor
{
    [Accessor("WorldStaticData/XmlLoadInfo")]
    public abstract class XmlLoadInfoAccessor
    {
        public readonly string XmlName;
        public readonly string LoadStepLocalizationKey;
        public readonly bool LoadAtStartup;
        public readonly bool SendToClients;
        public readonly bool IgnoreMissingFile;
        public readonly bool AllowReloadDuringGame;
        public readonly Func<XmlFile, IEnumerator> LoadMethod;
        public readonly System.Action CleanupMethod;
        public readonly Func<IEnumerator> ExecuteAfterLoad;
        public readonly System.Action<XmlFile> ReloadDuringGameMethod;
        public byte[] CompressedXmlData;
        public bool WasReceivedFromServer;
    }
}
