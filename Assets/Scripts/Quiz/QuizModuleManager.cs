namespace HoodedCrow.Quiz
{
    using System;
    using System.Collections.Generic;
    using HoodedCrow.Core;
    using HoodedCrow.UI;
    using UnityEngine;

    public class QuizModuleManager: AModuleManager
    {
        [SerializeField] private SOQuizSet _quizSet;

        [Header("Messages - Listens")]
        [SerializeField] private StartQuizRoundMessage _startQuizRoundMessage;
        [SerializeField] private QuestionRequestMessage _questionRequestMessage;
        [SerializeField] private PlayerAnsweredMessage _playerAnsweredMessage;

        [Header("Messages - Sends")]
        [SerializeField] private AddModuleMessage _addModuleMessage;
        [SerializeField] private RemoveModuleMessage _removeModuleMessage;
        [SerializeField] private NewQuestionMessage _newQuestionMessage;
        [SerializeField] private RequestQuizViewMessage _requestQuizViewMessage;

        private Queue<SOQuestion> _currentSet;

        private void Awake()
        {
            _addModuleMessage.Send(new AddModuleMessageContent(this));
        }

        private void OnDestroy()
        {
            _removeModuleMessage.Send(new RemoveModuleMessageContent(this));
            _requestQuizViewMessage.Clear();
            _newQuestionMessage.Clear();
        }

        public override void Initialize(GameManager gameManager)
        {
            _startQuizRoundMessage.AddListener(HandleStartQuizRoundMessage);
            _questionRequestMessage.AddListener(HandleQuestionRequestMessage);
            _playerAnsweredMessage.AddListener(HandlePlayerAnsweredMessage);
        }

        public override void UnInitialize(GameManager gameManager)
        {
        }

        private void HandleStartQuizRoundMessage(StartQuizMessageContent content)
        {
            if(_currentSet == null)
            {
                PrepareNewQuizSet();
            }
        }

        private void HandleQuestionRequestMessage(QuestionRequestMessageContent content)
        {
            if (_currentSet?.Count == 0)
            {
                _requestQuizViewMessage.Send(new RequestQuizViewMessageContent(typeof(QuizVictoryView), false));
                return;
            }

            SOQuestion question = _currentSet.Dequeue();
            _newQuestionMessage.Send(new NewQuestionMessageContent(question));
            Debug.Log($"Questions left: {_currentSet.Count}");
        }

        private void HandlePlayerAnsweredMessage(PlayerAnsweredMessageContent content)
        {
            if (content.AnswerCorrect)
            {
                HandleCorrectAnswer();
                return;
            }

            HandleWrongAnswer();
        }

        private void PrepareNewQuizSet()
        {
            List<SOQuestion> questionsList = _quizSet.GetRandomSet();
            _currentSet = new Queue<SOQuestion>();

            foreach (SOQuestion question in questionsList)
            {
                _currentSet.Enqueue(question);
            }
        }

        private void HandleCorrectAnswer()
        {
            _requestQuizViewMessage.Send(new RequestQuizViewMessageContent(typeof(CorrectAnswerView), false));
        }

        private void HandleWrongAnswer()
        {
            _currentSet = null;
            _requestQuizViewMessage.Send(new RequestQuizViewMessageContent(typeof(WrongAnswerView), false));
        }
    }
}
