namespace HoodedCrow.Core
{
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class StartUpModuleManager: AModuleManager
    {
        [SerializeField] private AssetReference _initialSceneReference;

        [Header("Messages")]
        [SerializeField] private LoadSceneMessage _loadSceneMessage;

        public override void Initialize(GameManager gameManager)
        {
            _loadSceneMessage.Send(new LoadSceneMessageContent(_initialSceneReference));
        }

        public override void UnInitialize(GameManager gameManager)
        {
        }
    }
}
