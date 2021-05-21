namespace HoodedCrow.Core
{
    using System;
    using UnityEngine;

    [Serializable]
    public class Value<T>
    {
        public event Action<T> OnValueChange;
        [SerializeField] private T _value;

        public T GetValue()
        {
            return _value;
        }

        /// <summary>
        /// Sets the value without invoking the OnValueChange event
        /// </summary>
        public void SetValue(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Sets the value and invokes OnValueChange event
        /// </summary>
        public void UpdateValue(T value)
        {
            _value = value;
            OnValueChange.Invoke(_value);
        }
    }
}