namespace HoodedCrow.Core
{
    using System;

    public interface IViewController<TView> where TView: AView
    {
        public TView CurrentView { get; }

        public void ShowView(Type viewType, bool additive);
        public void ShowView<TView>(bool additive);


        public void HideCurrentView();
        public void HideView(Type viewType);
        public void HideView<TView>();

        public void HideAllAdditiveViews();
    }
}
