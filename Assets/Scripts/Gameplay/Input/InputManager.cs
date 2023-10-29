using System;
using Fusion;
using UnityEngine;


namespace Duelno.Gameplay.InputSystem
{
    public interface IInputManagerModifier
    {
        void SetAimOriginPoint(Vector2 v);
    }
    public class InputManager : Singleton<InputManager>
    {

        class Modifier : IInputManagerModifier
        {
            readonly InputManager target;

            public Modifier(InputManager target)
            {
                this.target = target;
            }

            public void SetAimOriginPoint(Vector2 v)
            {
                target.startAimPosition = v;
            }
        }
        struct FixedInputState
        {
            public bool hasAttacked;

            public static readonly FixedInputState initial = new FixedInputState()
            {
                hasAttacked = false
            };
        }

        public IInputManagerModifier modifier { get; private set; }

        public float aimStrengthSensitive => InputConfig.instance.aimStrengthSensitive;

        [Header("All fields here are shown for debug purposes")]
        public float movement;
        public Vector2 aim;


        public bool isJump;
        public bool isAttack;
        public bool isAim;



        FixedInputState fixedState = new FixedInputState();


        Vector2 startAimPosition;

        public PlayerInputData playerInputData => new PlayerInputData
        {
            movement = movement,
            isJump = isJump,
            isAim = isAim,
            isAttack = isAttack,
            aim = aim
        };


        public PlayerInputData fixedPlayerInputData
        {
            get
            {
                var pid = playerInputData;
                pid.isAttack |= fixedState.hasAttacked;
                return pid;
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();

            modifier = new Modifier(this);
        }

        private void Update()
        {
            UpdateInput();
        }

        public void ResetFixedState()
        {
            this.fixedState = FixedInputState.initial;
        }


        public void UpdateInput()
        {

            movement = (Input.GetAxis("Horizontal"));
            var verticalInput = Input.GetAxis("Vertical");
            isJump = verticalInput > 0;
            if (Input.GetButtonDown("Fire1"))
            {
                startAimPosition = CameraObject.instance.camera.ScreenToWorldPoint(Input.mousePosition).toVector2();
            }
            isAim = Input.GetButton("Fire1");
            isAttack = Input.GetButtonUp("Fire1");

            if (isAttack)
            {
                fixedState.hasAttacked = true;
            }

            if (isAim)
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var originAimPosition = startAimPosition;
                var direction = (Vector2)mousePos - originAimPosition;
                aim = Vector2.ClampMagnitude(direction * aimStrengthSensitive, 1);
            }
            else
            {
                aim = Vector2.zero;
            }
        }



    }



}