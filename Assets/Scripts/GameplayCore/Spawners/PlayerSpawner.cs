using UnityEngine;
using System.Collections.Generic;

namespace Duelno.Gameplay.Spawners
{
    using Fusion;
    using UnityEngine;

    public abstract class PlayerSpawner : NetworkBehaviour
    {
        public abstract void SpawnPlayer(int index, PlayerRef player);
    }
}