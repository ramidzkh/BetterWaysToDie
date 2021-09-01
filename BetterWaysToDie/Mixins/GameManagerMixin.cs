using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using UnityEngine;

namespace BetterWaysToDie.Mixins
{
    [Mixin(typeof(GameManager))]
    public abstract class GameManagerMixin
    {
        [Shadow] private World m_World;

        [Shadow] private PersistentPlayerList persistentPlayers;

        [Shadow]
        protected abstract string getPersistentPlayerID(ClientInfo _cInfo);

        [Shadow]
        protected abstract SpawnPointList GetSpawnPointList();

        [Inject(GameManagerTargets.Methods.StartAsServer, AtLocation.Head)]
        private void onSinglePlayerStart()
        {
            Debug.LogError("We are starting with a 'Integrated' Server");
        }

        [Inject(GameManagerTargets.Methods.StartAsClient, AtLocation.Head)]
        private void onMultiPlayerClientStart()
        {
            Debug.LogError("We are starting with a Client connecting to a remote server");
        }
    }

    [Mixin("GameManager/<StartAsServer>d__135")]
    public abstract class StartAsServerMixin
    {
        [Inject(_StartAsServer_d__135Targets.Methods.MoveNext, AtLocation.Invoke,
            Target = _StartAsServer_d__135Targets.Methods.MoveNextInjects.File_Exists_String)]
        private void RegenerateBlockAndItemIds()
        {
            if (Mod.ModManager.IsDevelopmentEnvironment())
            {
                var blockIdMap = GameUtils.GetSaveGameDir() + "/" + Constants.cFileBlockMappings;
                var itemIdMap = GameUtils.GetSaveGameDir() + "/" + Constants.cFileItemMappings;
                Block.nameIdMapping = new NameIdMapping(blockIdMap, Block.MAX_BLOCKS);
                if (!Block.nameIdMapping.LoadFromFile())
                {
                    Log.Warning("Could not load block-name-mappings file '" + blockIdMap + "'!");
                    Block.nameIdMapping = null;
                }

                ItemClass.nameIdMapping = new NameIdMapping(itemIdMap, ItemClass.MAX_ITEMS);
                if (!ItemClass.nameIdMapping.LoadFromFile())
                {
                    Log.Warning("Could not load item-name-mappings file '" + itemIdMap + "'!");
                    ItemClass.nameIdMapping = null;
                }
            }
        }
    }
}
