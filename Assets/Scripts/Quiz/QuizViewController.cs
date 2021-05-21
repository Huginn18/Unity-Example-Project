namespace HoodedCrow.Quiz
{
    using HoodedCrow.Core.UI;
    using UnityEngine;

    public class QuizViewController: ViewController
    {
        [Header("Quiz Messages - Listens")]
        [SerializeField] private RequestQuizViewMessage _requestQuizViewMessage;

        protected override void Awake()
        {
            base.Awake();

            _requestQuizViewMessage.AddListener(HandleRequestQuizViewMessage);
        }

        private void HandleRequestQuizViewMessage(RequestQuizViewMessageContent content)
        {
            ShowView(content.ViewType, content.Additive);
        }
    }
}
