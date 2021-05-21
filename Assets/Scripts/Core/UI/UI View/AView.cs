namespace HoodedCrow.Core
{
    using UnityEngine;

    public abstract class AView: MonoBehaviour
    {
        [SerializeField] protected GameObject _contentContainer;
        protected IViewController<AView> _viewController;

        public void Initialize(IViewController<AView> viewController)
        {
            _viewController = viewController;
            _contentContainer.SetActive(false);
        }

        public void Show()
        {
            OnShowView();
            _contentContainer.SetActive(true);
        }

        public void Hide()
        {
            OnHideView();
            _contentContainer.SetActive(false);
        }

        protected abstract void OnShowView();
        protected abstract void OnHideView();
    }
}
