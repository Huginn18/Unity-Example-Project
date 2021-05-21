namespace HoodedCrow.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameManager: MonoBehaviour
    {
        [SerializeField] private List<AModuleManager> _preloadModule = new List<AModuleManager>();
        private Dictionary<Type, AModuleManager> _activeModules = new Dictionary<Type, AModuleManager>();

        private void Awake()
        {
            App.Instance.SetGameManager(this);
        }


        public void Initialize()
        {
            PreloadManagers();
        }

        public void Tick()
        {
            foreach (AModuleManager moduleManager in _activeModules.Values)
            {
                IUpdatable updatable = moduleManager as IUpdatable;
                if (updatable != null)
                {
                    updatable.Tick();
                }
            }
        }

        public void AddModuleManager(AModuleManager moduleManager)
        {
            if (_activeModules.ContainsKey(moduleManager.GetType()))
            {
                Debug.LogError($"Someone was trying to add duplicate of {moduleManager.GetType().Name}. \nPlease check what went wrong.");
                return;
            }

            moduleManager.Initialize(this);
            _activeModules[moduleManager.GetType()] = moduleManager;
        }

        public void RemoveModule(AModuleManager moduleManager)
        {
            Type mmType = moduleManager.GetType();

            if(!_activeModules.ContainsKey(mmType))
            {
                Debug.LogError($"You are trying to remove {mmType}, but it doesnt exist!");
                return;
            }

            moduleManager.UnInitialize(this);
            _activeModules.Remove(mmType);
        }

        public T GetModule<T>() where T : AModuleManager
        {
            Type mmType = typeof(T);
            if (!_activeModules.ContainsKey(mmType))
            {
                //ToDo: if time allows change that into exception
                Debug.LogError($"You are trying to get {mmType}, but it is not active. Please check preload queue on game manager or scene module manager init queue");
                return null;
            }

            return (T)_activeModules[mmType];
        }

        private void PreloadManagers()
        {
            foreach (AModuleManager manager in _preloadModule)
            {
                AddModuleManager(manager);
            }
        }
    }
}
