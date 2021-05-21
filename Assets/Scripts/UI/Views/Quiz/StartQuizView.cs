namespace HoodedCrow.UI
{
    using System;
    using HoodedCrow.Core;
    using HoodedCrow.Core.UI;
    using HoodedCrow.Quiz;
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
        [SerializeField] private StartQuizRoundMessage _startQuizRoundMessage;

        public override void Initialize(IViewController<AView> viewController)
        {
            base.Initialize(viewController);

            _yesButton.onClick.AddListener(OnYesButton);
            _noButton.onClick.AddListener(OnNoButton);
        }

        protected override void OnShowView()
        {
            _startQuizRoundMessage.Send(new StartQuizMessageContent());
        }

        protected override void OnHideView()
        {
        }

        private void OnYesButton()
        {
            _viewController.ShowView<QuizQuestionView>(false);
        }

        private void OnNoButton()
        {
            _loadSceneMessage.Send(new LoadSceneMessageContent(_mainMenuScene));
        }
    }
}
