namespace Duelno
{
    using System;
    using System.Collections;
    using Duelno.Api;
    using Duelno.Progress;
    using UnityEngine;

    public class ProgressManager : Singleton<ProgressManager>
    {

        ProgressData progressData;
        public string playerId => progressData.playerId;

        public bool isLoaded { get; private set; }


        public event Action onLoad;

        protected override void OnAwake()
        {
            base.OnAwake();

            UserManager.instance.onLogin += LoadProgress;
        }

        void LoadProgress()
        {
            string playerId = UserManager.instance.userId;
            //TODO implement this to get the progress data
        }
    }
}