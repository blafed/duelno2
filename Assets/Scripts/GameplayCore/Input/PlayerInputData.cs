using System;
using Fusion;
using UnityEngine;

namespace Duelno.Gameplay.InputSystem
{

    [Serializable]
    public struct PlayerInputData : INetworkInput, ISmartInput
    {
        public float movement;
        public NetworkBool isJump;
        public NetworkBool isAim;
        public NetworkBool isAttack;
        public Vector2 aim;

        float ISmartInput.motion => movement;
        bool ISmartInput.isJump => isJump;
        bool ISmartInput.isAim => isAim;
        bool ISmartInput.isAttack => isAttack;
        Vector2 ISmartInput.aim => aim;
    }
}