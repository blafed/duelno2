namespace Duelno.Gameplay.InputSystem
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "InputConfig", menuName = "Duelno/InputConfig", order = 0)]
    public class InputConfig : SingletonSO<InputConfig>
    {


        public float aimStrengthSensitive = 3f;

    }
}