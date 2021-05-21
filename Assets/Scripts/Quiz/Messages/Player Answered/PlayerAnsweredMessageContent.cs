namespace HoodedCrow.Quiz
{
    using HoodedCrow.Core;

    public struct PlayerAnsweredMessageContent: IMessageContent
    {
        public bool AnswerCorrect;

        public PlayerAnsweredMessageContent(bool answerCorrect)
        {
            AnswerCorrect = answerCorrect;
        }
    }
}
