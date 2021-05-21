namespace HoodedCrow.Core
{
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.SceneManagement;

    public class SceneLoader: MonoBehaviour
    {
        private void Awake()
        {
            //ToDo: List to loadSceneMessage
        }

        private void LoadAdditiveScene(AssetReference sceneReference)
        {
            sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            //ToDo: Add scene loaded message
        }

        private void UnloadScene(AssetReference sceneReference)
        {
            sceneReference.UnLoadScene();
            //ToDo: Add scene unloaded message
        }
    }
}
