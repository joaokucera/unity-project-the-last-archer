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
    public VolumeChanged OnVolumeChangedEvent = delegate { };

    public delegate void FXChanged(bool enable);
    public FXChanged OnFXChangedEvent = delegate { };

    public override void Init()
    {
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        _fxToggle.onValueChanged.AddListener(OnFXChanged);
        _closeButton.onClick.AddListener(OnCloseClick);
    }

    public void Open()
    {
        Show();
    }

    private void OnVolumeChanged(float value)
    {
        OnVolumeChangedEvent(value);
    }

    private void OnFXChanged(bool enable)
    {
        OnFXChangedEvent(enable);
    }

    private void OnCloseClick()
    {
        Hide();
    }
}