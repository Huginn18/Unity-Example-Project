namespace HoodedCrow.UI
{
    using HoodedCrow.Core;
    using HoodedCrow.Core.UI;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UI;

    public class QuizVictoryView: AView
    {
        [SerializeField] private Button _exitButton;

        [Space, SerializeField] private AssetReference _mainMenuScene;

        [Header("Messages - Sends")]
        [SerializeField] private LoadSceneMessage _loadSceneMessage;

        public override void Initialize(IViewController<AView> viewController)
        {
            base.Initialize(viewController);
            _exitButton.onClick.AddListener(OnExitButton);
        }

        protected override void OnShowView()
        {
        }

        protected override void OnHideView()
        {
        }

        private void OnExitButton()
        {
            _loadSceneMessage.Send(new LoadSceneMessageContent(_mainMenuScene));
        }
    }
}
