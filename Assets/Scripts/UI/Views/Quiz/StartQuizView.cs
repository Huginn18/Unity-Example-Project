namespace HoodedCrow.UI
{
    using HoodedCrow.Core;
    using HoodedCrow.Core.UI;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UI;

    public class StartQuizView: AView
    {

        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;

        [Space, SerializeField] private AssetReference _mainMenuScene;

        [Header("Messages - Sends")]
        [SerializeField] private LoadSceneMessage _loadSceneMessage;

        public override void Initialize(IViewController<AView> viewController)
        {
            base.Initialize(viewController);

            _yesButton.onClick.AddListener(OnYesButton);
            _noButton.onClick.AddListener(OnNoButton);
        }

        protected override void OnShowView()
        {
        }

        protected override void OnHideView()
        {
        }

        private void OnYesButton()
        {
            Debug.Log("Yes");
            _viewController.ShowView<QuizQuestionView>(false);
        }

        private void OnNoButton()
        {
            _loadSceneMessage.Send(new LoadSceneMessageContent(_mainMenuScene));
        }
    }
}
