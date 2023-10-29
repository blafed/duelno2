using System;
using Fusion;
using UnityEngine;

namespace Duelno.Gameplay.InputSystem
{

    [Serializable]
    public struct PlayerInputData : INetworkInput
    {
        public float movement;
        public NetworkBool isJump;
        public NetworkBool isAim;
        public NetworkBool isAttack;
        public Vector2 aim;


        public struct MyInputData : INetworkInput
        {
            public float movement;
        }
    }

}