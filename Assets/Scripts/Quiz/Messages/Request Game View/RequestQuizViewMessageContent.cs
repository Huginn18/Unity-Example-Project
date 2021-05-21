namespace HoodedCrow.Quiz
{
    using System;
    using HoodedCrow.Core;

    public struct RequestQuizViewMessageContent: IMessageContent
    {
        public Type ViewType;
        public bool Additive;

        public RequestQuizViewMessageContent(Type viewType, bool additive)
        {
            ViewType = viewType;
            Additive = additive;
        }
    }
}
