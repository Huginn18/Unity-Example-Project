namespace HoodedCrow.Core.UI
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Image))]
    public class UIImageStyling: AUIStyling
    {
        [SerializeField] private SOImageStyling _imageStyling;
        [SerializeField] private SOColorValue _colorStyling;

        protected override void SetStyling()
        {
            Image image = GetComponent<Image>();

            image.sprite = _imageStyling == null ? null : _imageStyling.Value;
            image.color = _colorStyling == null ? Color.magenta : _colorStyling.Value;
        }
    }
}
