using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UISettingsPopup : UIPopup
{
    [SerializeField]
    private Slider _volumeSlider;
    [SerializeField]
    private Toggle _fxToggle;
    [SerializeField]
    private Button _closeButton;

    public delegate void VolumeChanged(float value);
    public event VolumeChanged OnVolumeChangedEvent = delegate { };

    public delegate void FXChanged(bool enable);
    public event FXChanged OnFXChangedEvent = delegate { };

    public override void Init()
    {
        _volumeSlider.onValueChanged.AddListener((float value) => OnVolumeChangedEvent(value));
        _fxToggle.onValueChanged.AddListener((bool enable) => OnFXChangedEvent(enable));

        _closeButton.onClick.AddListener(Close);
    }
}