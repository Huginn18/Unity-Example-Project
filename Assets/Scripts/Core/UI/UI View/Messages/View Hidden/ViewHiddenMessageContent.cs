namespace HoodedCrow.Core.UI.Messages
{
    public struct ViewHiddenMessageContent: IMessageContent
    {
        public AView View;

        public ViewHiddenMessageContent(AView view)
        {
            View = view;
        }
    }
}
