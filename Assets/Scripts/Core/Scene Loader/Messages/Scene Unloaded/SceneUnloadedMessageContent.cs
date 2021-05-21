namespace HoodedCrow.Core
{
    using UnityEngine.ResourceManagement.ResourceProviders;

    public struct SceneUnloadedMessageContent: IMessageContent
    {
        public SceneInstance SceneInstance;

        public SceneUnloadedMessageContent(SceneInstance sceneInstance)
        {
            SceneInstance = sceneInstance;
        }
    }
}
