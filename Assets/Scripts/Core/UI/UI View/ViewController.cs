namespace HoodedCrow.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class ViewController: MonoBehaviour, IViewController<AView>
    {
        public AView CurrentView => _currentView.GetValue();
        private Value<AView> _currentView;

        private Dictionary<Type, AView> _viewsCollection = new Dictionary<Type, AView>();
        private Dictionary<Type, AView> _additiveViewsCollection = new Dictionary<Type, AView>();

        public void ShowView<TView>(bool additive)
        {
            Type viewType = typeof(TView);
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
            //ToDo: Send message about view being disabled
            _currentView.UpdateValue(null);
        }

        public void HideView<TView>()
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

            //ToDo: Send message about all additive views being disabled
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
            //ToDo: Send Message about additive view
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
                //ToDo: Send message about current view change
            }

            HandleCurrentViewChange(view);
        }

        private void HandleCurrentViewChange(AView view)
        {
            AView previousView = CurrentView;
            previousView.Hide();
            _currentView.SetValue(null);
            //ToDo: Send message about view being hidden

            view.Show();
            _currentView.UpdateValue(view);
        }

        private void HideAdditiveView(Type viewType)
        {
            AView view = _additiveViewsCollection[viewType];
            view.Hide();
            _additiveViewsCollection.Remove(viewType);
            //ToDo: Send message about additive view being disabled
        }
    }
}
