namespace HoodedCrow.Core.UI.Messages
{
    public struct CurrentViewSetMessageContent: IMessageContent
    {
        public AView View;

        public CurrentViewSetMessageContent(AView view)
        {
            View = view;
        }
    }
}
