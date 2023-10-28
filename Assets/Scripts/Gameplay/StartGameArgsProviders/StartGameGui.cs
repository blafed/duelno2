using UnityEngine;

namespace Duelno.Gameplay.StartGameArgsProviders
{
    using Fusion;
    using UnityEngine;

    class StartGameGui : StartGameArgsProvider
    {


        [Min(1)]
        public int level = 1;

        public override StartGameArgs GetStartGameArgs()
        {
            return args;
        }

        StartGameArgs args;

        private void Awake()
        {
            gameplayRunner.autoStartGame = false;
            args = new StartGameArgs()
            {
                GameMode = (GameMode)(-1),
                SessionName = "test-room",
                Scene = level,
            };
        }

        void OnGUI()
        {
            if (!gameplayRunner.hasStartedGame)
            {

                if (GUI.Button(new Rect(0, 0, 200, 40), "Host"))
                {
                    args.GameMode = GameMode.Host;
                }
                if (GUI.Button(new Rect(0, 40, 200, 40), "Join"))
                {
                    args.GameMode = GameMode.Client;
                }

                if (GUI.Button(new Rect(0, 80, 200, 40), "Single"))
                {
                    args.GameMode = GameMode.Single;
                }
                if (args.GameMode != (GameMode)(-1))
                    gameplayRunner.StartGame();
            }
        }

    }
}