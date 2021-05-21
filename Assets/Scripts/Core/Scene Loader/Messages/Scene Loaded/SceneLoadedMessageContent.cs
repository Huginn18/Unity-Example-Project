namespace HoodedCrow.Core
{
    using UnityEngine.ResourceManagement.ResourceProviders;

    public struct SceneLoadedMessageContent: IMessageContent
    {
        public SceneInstance SceneInstance;

        public SceneLoadedMessageContent(SceneInstance sceneInstance)
        {
            SceneInstance = sceneInstance;
        }
    }
}
