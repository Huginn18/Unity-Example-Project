namespace HoodedCrow.Core
{
    using UnityEngine.AddressableAssets;

    public struct UnloadSceneMessageContent: IMessageContent
    {
        public AssetReference SceneReference;

        public UnloadSceneMessageContent(AssetReference sceneReference)
        {
            SceneReference = sceneReference;
        }
    }
}
