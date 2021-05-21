namespace HoodedCrow.UI
{
    using HoodedCrow.Core;
    using HoodedCrow.Core.UI;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UI;

    public class DefaultMainMenuView: AView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;

        [Space, SerializeField] private AssetReference _gameScene;

        [Header("Messages - Send")]
        [SerializeField] private LoadSceneMessage _loadSceneMessage;

        public override void Initialize(IViewController<AView> viewController)
        {
            base.Initialize(viewController);

            _playButton.onClick.AddListener(OnPlayButton);
            _settingsButton.onClick.AddListener(OnSettingsButton);
            _quitButton.onClick.AddListener(OnQuitButton);
        }

        protected override void OnShowView()
        {
        }

        protected override void OnHideView()
        {
        }

        private void OnPlayButton()
        {
            _loadSceneMessage.Send(new LoadSceneMessageContent(_gameScene));
        }

        private void OnSettingsButton()
        {
            //ToDo: Show Settings View
//            _viewController.ShowView();
        }

        private void OnQuitButton()
        {
            App.Quit();
        }
    }
}
