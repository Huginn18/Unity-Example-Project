namespace HoodedCrow.Core.UI
{
    using System;

    public interface IViewController<TView> where TView: AView
    {
        public TView CurrentView { get; }

        public void ShowView(Type viewType, bool additive);
        public void ShowView<T>(bool additive) where T: TView;


        public void HideCurrentView();
        public void HideView(Type viewType);
        public void HideView<T>() where T : TView;

        public void HideAllAdditiveViews();
    }
}
