namespace HoodedCrow.Quiz
{
    using HoodedCrow.Core;

    public class NewQuestionMessageContent: IMessageContent
    {
        public SOQuestion QuestionData;

        public NewQuestionMessageContent(SOQuestion questionData)
        {
            QuestionData = questionData;
        }
    }
}
