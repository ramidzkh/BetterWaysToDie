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
            //FIXME: since the 7 days to die dev's can't code, we need to name our worlds "Playtesting" otherwise adding blocks and items will not be updated
            Debug.LogError("We are starting with a 'Integrated' Server");
        }

        [Inject(GameManagerTargets.Methods.StartAsClient, AtLocation.Head)]
        private void onMultiPlayerClientStart()
        {
            Debug.LogError("We are starting with a Client connecting to a remote server");
        }
    }
}
