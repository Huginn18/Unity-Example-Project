namespace HoodedCrow.Core
{
    using System;
    using UnityEngine;

    public abstract class AMessage<TContent>: ScriptableObject where TContent : IMessageContent
    {
        private Action<TContent> OnMessageDispatched;

        public void AddListener(Action<TContent> onMessageDispatched)
        {
            OnMessageDispatched += onMessageDispatched;
        }

        public void RemoveListener(Action<TContent> onMessageDispatched)
        {
            OnMessageDispatched -= onMessageDispatched;
        }

        public void Clear()
        {
            OnMessageDispatched = null;
        }

        public void Send(TContent content)
        {
            if (OnMessageDispatched == null)
            {
                Debug.LogWarning($"{GetType().Name} was sent but no one is listening to it.");
                return;
            }
            OnMessageDispatched.Invoke(content);
        }
    }
}
