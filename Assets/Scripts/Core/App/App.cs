namespace HoodedCrow.Core
{
    using System;
    using HoodedCrow.Core.Utils;
    using UnityEngine;

    public class App: Singleton<App>
    {
        private GameManager _gameManager;

        private void Update()
        {
            if (_gameManager == null)
            {
                return;
            }
            _gameManager.Tick();
        }

        public void SetGameManager(GameManager gameManager)
        {
            if (_gameManager != null)
            {
                Debug.LogError("You are trying to set GameManager when the other one is active. \nPlease check what went wrong", gameManager);
                return;
            }

            _gameManager = gameManager;
            _gameManager.Initialize();
        }

        public GameManager GetGameManager()
        {
            return _gameManager;
        }

        public static void Quit()
        {
            Debug.Log("QUIT");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
