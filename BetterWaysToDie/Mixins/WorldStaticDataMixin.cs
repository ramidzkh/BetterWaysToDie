using BetterWaysToDie.Mixins.Accessor;
using SharpILMixins.Annotations;
using UnityEngine;

namespace BetterWaysToDie.Mixins
{
    [Mixin(typeof(WorldStaticData))]
    public static class WorldStaticDataMixin
    {
        /// <summary>
        /// The best way to handle this is sadly an overwrite
        /// </summary>
        /// <param name="_cInfo"> the information of the client we are sending data to</param>
        [Overwrite]
        public static void SendXmlsToClient(ClientInfo _cInfo)
        {
            foreach (XmlLoadInfoAccessor xmlLoadInfo in WorldStaticDataAccessor.xmlsToLoad)
            {
                Debug.Log("PostProcessing " + xmlLoadInfo.XmlName);
                if (xmlLoadInfo.SendToClients && xmlLoadInfo.CompressedXmlData != null)
                    _cInfo.SendPackage(NetPackageManager.GetPackage<NetPackageConfigFile>()
                        .Setup(xmlLoadInfo.XmlName, xmlLoadInfo.CompressedXmlData));
            }
        }
    }
}