namespace HoodedCrow.Core
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Example/Core/Application Settings")]
    public class ApplicationSettings: ScriptableObject
    {
        [SerializeField] private int _targetFrameRate = 60;
        [SerializeField] private bool _runInBackground = false;

        private void OnValidate()
        {
            UpdateApplicationSettings();
        }

        private void Reset()
        {
            UpdateApplicationSettings();
        }

        private void UpdateApplicationSettings()
        {
            Application.targetFrameRate = _targetFrameRate;
            Application.runInBackground = _runInBackground;
        }
    }
}
