using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private AudioManager _audioManager;

    private void Start()
    {
        _uiManager.SettingsPopup.OnVolumeChangedEvent += _audioManager.OnVolumeChanged;
        _uiManager.SettingsPopup.OnFXChangedEvent += _audioManager.OnFXChanged;
    }
}