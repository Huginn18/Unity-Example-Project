namespace HoodedCrow.Core
{
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.ResourceManagement.AsyncOperations;
    using UnityEngine.ResourceManagement.ResourceProviders;
    using UnityEngine.SceneManagement;

    public class SceneLoader: MonoBehaviour
    {
        [SerializeField] private LoadSceneMessage _loadSceneMessage;
        [SerializeField] private SceneLoadedMessage _sceneLoadedMessage;
        [SerializeField] private UnloadSceneMessage _unloadSceneMessage;
        [SerializeField] private SceneUnloadedMessage _sceneUnloadedMessage;


        private void Awake()
        {
            _loadSceneMessage.AddListener(HandleLoadSceneMessage);
            _unloadSceneMessage.AddListener(HandleUnloadSceneMessage);
        }

        private void HandleLoadSceneMessage(LoadSceneMessageContent content)
        {
            LoadAdditiveScene(content.SceneReference);
        }
        private void HandleUnloadSceneMessage(UnloadSceneMessageContent content)
        {
            UnloadScene(content.SceneReference);
        }

        private void LoadAdditiveScene(AssetReference sceneReference)
        {
            AsyncOperationHandle<SceneInstance> asyncOperationHandle = sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            asyncOperationHandle.Completed += handle => _sceneLoadedMessage.Send(new SceneLoadedMessageContent(handle.Result));
        }

        private void UnloadScene(AssetReference sceneReference)
        {
            var asyncOperationHandle = sceneReference.UnLoadScene();
            asyncOperationHandle.Completed += handle => _sceneUnloadedMessage.Send(new SceneUnloadedMessageContent(handle.Result));
        }
    }
}
