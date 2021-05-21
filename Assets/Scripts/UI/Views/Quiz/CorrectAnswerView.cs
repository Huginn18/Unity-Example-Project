namespace HoodedCrow.UI
{
    using HoodedCrow.Core;
    using HoodedCrow.Core.UI;
    using HoodedCrow.Quiz;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.UI;

    public class CorrectAnswerView: AView
    {
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _exitButton;

        [Space, SerializeField] private AssetReference _mainMenuScene;

        [Header("Messages - Sends")]
        [SerializeField] private StartQuizRoundMessage _startQuizRoundMessage;
        [SerializeField] private LoadSceneMessage _loadSceneMessage;

        public override void Initialize(IViewController<AView> viewController)
        {
            base.Initialize(viewController);
            _nextButton.onClick.AddListener(OnNextButton);
            _exitButton.onClick.AddListener(OnExitButton);
        }

        protected override void OnShowView()
        {

        }

        protected override void OnHideView()
        {
        }

        private void OnNextButton()
        {
            _viewController.ShowView<QuizQuestionView>(false);
        }

        private void OnExitButton()
        {
            _loadSceneMessage.Send(new LoadSceneMessageContent(_mainMenuScene));
        }
    }
}
