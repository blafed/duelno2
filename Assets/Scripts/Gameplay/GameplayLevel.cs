namespace Duelno.Gameplay
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// referencees the current gameplay level
    /// </summary>
    public class GameplayLevel : SingletonScene<GameplayLevel>
    {


        private void Start()
        {
            if (!GameplayRunner.CheckInstanceExist())
            {
                SceneManager.LoadScene(0);
            }
            else
            {
            }
        }

    }
}
