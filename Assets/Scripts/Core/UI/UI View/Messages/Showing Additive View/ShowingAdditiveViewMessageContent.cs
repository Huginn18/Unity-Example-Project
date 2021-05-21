namespace HoodedCrow.Core.UI.Messages.Showing_Additive_View
{
    public struct ShowingAdditiveViewMessageContent: IMessageContent
    {
        public AView View;

        public ShowingAdditiveViewMessageContent(AView view)
        {
            View = view;
        }
    }
}
