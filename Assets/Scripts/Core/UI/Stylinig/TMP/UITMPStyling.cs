namespace HoodedCrow.Core.UI
{
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TMP_Text))]
    public class UITMPStyling: AUIStyling
    {
        [SerializeField] private SOColorValue _colorStyling;
        [SerializeField] private SOTMPStyling _tmpStyling;

        protected override void SetStyling()
        {
            TMP_Text tmp = GetComponent<TMP_Text>();
            tmp.font = _tmpStyling == null ? null : _tmpStyling.Value;
            tmp.color = _colorStyling == null ? Color.magenta : _colorStyling.Value;
        }
    }
}
