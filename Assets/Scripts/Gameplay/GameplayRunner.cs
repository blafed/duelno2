using UnityEngine.SceneManagement;
namespace Duelno.Gameplay
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Fusion;
    using Fusion.Sockets;
    using UnityEngine;
    using Spawners;
    using InputSystem;

    /// <summary>
    /// Responsiple for loading the gameplay scene and start the gameplay mode
    /// </summary>
    [RequireComponent(typeof(NetworkRunner))]
    public class GameplayRunner : SingletonScene<GameplayRunner>, INetworkRunnerCallbacks
    {

        public bool autoStartGame = true;
        public event System.Action<StartGameArgs> onGameStarted;
        public NetworkRunner runner { get; private set; }

        public bool hasStartedGame { get; private set; }

        public INetworkSceneManager networkSceneManager { get; private set; }


        [SerializeField]
        StartGameArgsProvider startGameArgsProvider;

        public List<PlayerRef> players = new List<PlayerRef>();






        protected override void OnAwake()
        {
            base.OnAwake();

            runner = GetComponent<NetworkRunner>();
            networkSceneManager = GetComponent<INetworkSceneManager>();
            if (!startGameArgsProvider)
                startGameArgsProvider = GetComponent<StartGameArgsProvider>();
        }
        private void Start()
        {
            if (!startGameArgsProvider)
            {
                Debug.LogError("No StartGameArgsProvider found on this", this);
                return;
            }
            if (networkSceneManager == null)
            {
                Debug.LogError("No INetworkSceneManager found on this", this);
            }
            if (autoStartGame)
            {
                StartGame();
            }
        }

        public void QuitGame()
        {

        }





        public async void StartGame()
        {
            hasStartedGame = true;
            // new StartGameArgs()
            // {
            //     GameMode = mode,
            //     SessionName = "TestRoom",
            //     Scene = SceneManager.GetActiveScene().buildIndex,
            //     SceneManager = networkSceneManager
            // }
            runner.ProvideInput = true;
            var startGameArgs = startGameArgsProvider.GetStartGameArgs();
            startGameArgs.SceneManager = networkSceneManager;
            await runner.StartGame(startGameArgs);
            onGameStarted?.Invoke(startGameArgs);
        }

        void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {

            if (runner.IsServer)
            {
                var spawners = FindObjectsOfType<PlayerSpawner>();
                if (spawners.Length == 0)
                    Debug.LogError("No PlayerSpawner found in scene", this);

                players.Add(player);
                foreach (var spawner in spawners)
                {
                    spawner.SpawnPlayer(players.Count - 1, player);
                }

            }
        }

        void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            players.Remove(player);
        }
        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            InputManager.o.UpdateInput();
            var data = InputManager.o.fixedPlayerInputData;
            InputManager.o.ResetFixedState();
            input.Set(data);

            // TODO: Implement OnInput
        }
        void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner)
        {
        }

        void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner)
        {
        }

        void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
        }

        void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner)
        {
            print("OnSceneLoadDone");

        }

        void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner)
        {

        }
    }

    public abstract class StartGameArgsProvider : MonoBehaviour
    {
        GameplayRunner _gameplayRunner;

        protected GameplayRunner gameplayRunner => gameObject.CachedComponent(ref _gameplayRunner);
        public abstract StartGameArgs GetStartGameArgs();
    }


}