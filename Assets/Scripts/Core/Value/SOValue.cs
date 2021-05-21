namespace HoodedCrow.Core
{
    using UnityEngine;

    public class SOValue<T>: ScriptableObject
    {
        public T Value => _value;
        [SerializeField] private T _value;
    }
}