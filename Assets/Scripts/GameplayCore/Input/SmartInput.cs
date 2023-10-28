using UnityEngine;

namespace Duelno.Gameplay.InputSystem
{
    public interface ISmartInput
    {
        float motion { get; }
        bool isJump { get; }
        bool isAim { get; }
        bool isAttack { get; }
        Vector2 aim { get; }
    }
}