namespace HoodedCrow.Core
{
    using UnityEngine.AddressableAssets;

    public struct LoadSceneMessageContent: IMessageContent
    {
        public AssetReference SceneReference;

        public LoadSceneMessageContent(AssetReference sceneReference)
        {
            SceneReference = sceneReference;
        }
    }
}
