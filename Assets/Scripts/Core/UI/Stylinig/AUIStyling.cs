namespace HoodedCrow.Core.UI
{
    using UnityEngine;

    public abstract class AUIStyling: MonoBehaviour
    {
        #if UNITY_EDITOR
        private void Reset()
        {
            SetStyling();
        }

        private void OnValidate()
        {
            SetStyling();
        }
        #endif

        protected abstract void SetStyling();
    }
}
