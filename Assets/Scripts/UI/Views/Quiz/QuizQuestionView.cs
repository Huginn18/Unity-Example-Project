namespace HoodedCrow.UI
{
    using System;
    using HoodedCrow.Core.UI;
    using HoodedCrow.Quiz;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class QuizQuestionView: AView
    {
        [SerializeField] private TMP_Text _questionLabel;
        [SerializeField] private Image _image;
        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;

        [Header("Messages - Listens")]
        [SerializeField] private NewQuestionMessage _newQuestionMessage;

        [Header("Messages - Sends")]
        [SerializeField] private PlayerAnsweredMessage _playerAnsweredMessage;
        [SerializeField] private QuestionRequestMessage _questionRequestMessage;

        private void OnDestroy()
        {
            _playerAnsweredMessage.Clear();
            _questionRequestMessage.Clear();
        }

        public override void Initialize(IViewController<AView> viewController)
        {
            base.Initialize(viewController);

            _newQuestionMessage.AddListener(HandleNewQuestionMessage);
        }

        protected override void OnShowView()
        {
            _questionRequestMessage.Send(new QuestionRequestMessageContent());
        }

        protected override void OnHideView()
        {
        }

        private void HandleNewQuestionMessage(NewQuestionMessageContent content)
        {
            UpdateVisuals(content.QuestionData.Question, content.QuestionData.Sprite, content.QuestionData.IsCorrect);
        }

        private void UpdateVisuals(string question, Sprite sprite, bool isCorrect)
        {
            _questionLabel.text = question;
            _image.sprite = sprite;

            SetUpButtons(isCorrect);
        }

        private void SetUpButtons(bool isCorrect)
        {
            _yesButton.onClick.RemoveAllListeners();
            _noButton.onClick.RemoveAllListeners();

            if (isCorrect)
            {
                _yesButton.onClick.AddListener(OnCorrectAnswerButton);
                _noButton.onClick.AddListener(OnWrongAnswerButton);
                return;
            }

            _yesButton.onClick.AddListener(OnWrongAnswerButton);
            _noButton.onClick.AddListener(OnCorrectAnswerButton);
        }

        private void OnCorrectAnswerButton()
        {
            _playerAnsweredMessage.Send(new PlayerAnsweredMessageContent(true));
        }

        private void OnWrongAnswerButton()
        {
            _playerAnsweredMessage.Send(new PlayerAnsweredMessageContent(false));
        }
    }
}
