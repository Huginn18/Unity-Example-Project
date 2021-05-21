namespace HoodedCrow.Core.UI.Messages
{
    public struct AdditiveViewHiddenMessageContent: IMessageContent
    {
        public AView View;

        public AdditiveViewHiddenMessageContent(AView view)
        {
            View = view;
        }
    }
}
