namespace HoodedCrow.Core.UI
{
    using System;
    using System.Collections.Generic;
    using HoodedCrow.Core.UI.Messages;
    using HoodedCrow.Core.UI.Messages.Showing_Additive_View;
    using UnityEngine;

    public class ViewController: MonoBehaviour, IViewController<AView>
    {
        public AView CurrentView => _currentView.GetValue();
        private Value<AView> _currentView;

        private Dictionary<Type, AView> _viewsCollection = new Dictionary<Type, AView>();
        private Dictionary<Type, AView> _additiveViewsCollection = new Dictionary<Type, AView>();

        [Header("Messages")]
        [SerializeField] private CurrentViewChangeMessage _currentViewChangeMessage;
        [SerializeField] private ViewHiddenMessage _viewHiddenMessage;

        [SerializeField] private ShowingAdditiveViewMessage _showingAdditiveViewMessage;
        [SerializeField] private AdditiveViewHiddenMessage _additiveViewHiddenMessage;
        [SerializeField] private AdditiveViewsHiddenMessage _additiveViewsHiddenMessage;

        public void ShowView<T>(bool additive) where T: AView
        {
            Type viewType = typeof(T);
            ShowView(viewType, additive);
        }

        public void ShowView(Type viewType, bool additive)
        {
            if (!_viewsCollection.ContainsKey(viewType))
            {
                //ToDo: if time allows change that into exception
                Debug.LogError($"Cannot show view: {viewType.Name} isnot part of the _viewsCollection");
                return;
            }

            GetViewFromCollection(viewType, additive);
        }

        public void HideCurrentView()
        {
            if (CurrentView == null)
            {
                //ToDo: if time allows change this to exception
                Debug.LogError($"Cannot hide current view: CurrentView is null.");
                return;
            }

            CurrentView.Hide();
            _viewHiddenMessage.Send(new ViewHiddenMessageContent(CurrentView));
            _currentView.UpdateValue(null);
        }

        public void HideView<T>() where T : AView
        {
            throw new NotImplementedException();
        }

        public void HideView(Type viewType)
        {
            if (_additiveViewsCollection.ContainsKey(viewType))
            {
                HideAdditiveView(viewType);
                return;
            }

            if (_currentView.GetType() != viewType)
            {
                //ToDo: if time allows change this to exception
                Debug.LogError($"Cannot hide view: {viewType.Name} is not set as current view or active additive view");
                return;
            }

            HideCurrentView();
        }

        public void HideAllAdditiveViews()
        {
            foreach (AView view in _additiveViewsCollection.Values)
            {
                HideAdditiveView(view.GetType());
            }

            _additiveViewsHiddenMessage.Send(new AdditiveViewsHiddenMessageContent());
        }


        //Note: Probably should use interfaces for determining if view is additive.
        private void GetViewFromCollection(Type viewType, bool additive)
        {
            AView view = _viewsCollection[viewType];
            if (additive)
            {
                HandleShowingAdditiveView(view);
                return;
            }

            HandleShowingView(view);
        }

        private void HandleShowingAdditiveView(AView view)
        {
            Type viewType = view.GetType();
            if (!_additiveViewsCollection.ContainsKey(viewType))
            {
                //ToDo: if time allows change this into exception
                Debug.LogError($"Cannot show additive view: {viewType} is already active.");
                return;
            }

            view.Show();
            _additiveViewsCollection[viewType] = view;
            _showingAdditiveViewMessage.Send(new ShowingAdditiveViewMessageContent(view));
        }

        private void HandleShowingView(AView view)
        {
            Type viewType = view.GetType();
            if (view == CurrentView)
            {
                //ToDo: if time allows change this into exception
                Debug.LogError($"Cannot show view: {viewType.Name} is already active.");
                return;
            }

            if (_currentView == null)
            {
                view.Show();
                _currentView.UpdateValue(view);
                _currentViewChangeMessage.Send(new CurrentViewChangeMessageContent(null, CurrentView));
                return;
            }

            HandleCurrentViewChange(view);
        }

        private void HandleCurrentViewChange(AView view)
        {
            AView previousView = CurrentView;
            previousView.Hide();
            _currentView.SetValue(null);
            _viewHiddenMessage.Send(new ViewHiddenMessageContent(previousView));

            view.Show();
            _currentView.UpdateValue(view);
            _currentViewChangeMessage.Send(new CurrentViewChangeMessageContent(previousView, CurrentView));
        }

        private void HideAdditiveView(Type viewType)
        {
            AView view = _additiveViewsCollection[viewType];
            view.Hide();
            _additiveViewsCollection.Remove(viewType);
            _additiveViewHiddenMessage.Send(new AdditiveViewHiddenMessageContent(view));
        }
    }
}
