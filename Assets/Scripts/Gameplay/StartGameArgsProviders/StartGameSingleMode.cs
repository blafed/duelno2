namespace Duelno.Gameplay.StartGameArgsProviders
{
    using Fusion;
    using UnityEngine;

    class StartGameSingleMode : StartGameArgsProvider
    {

        [Min(1)]
        public int level = 1;

        public override StartGameArgs GetStartGameArgs()
        {
            return new StartGameArgs()
            {
                GameMode = GameMode.Single,
                SessionName = "single-player-room",
                Scene = level,
            };
        }
    }
}