using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private AudioManager _audioManager;

    private void Start()
    {
        _uiManager.SettingsPopup.OnVolumeChangedEvent += _audioManager.VolumeChanged;
        _uiManager.SettingsPopup.OnFXChangedEvent += _audioManager.FXChanged;

        _uiManager.LevelClearedPopup.OnLevelCleared += LevelCleared;
    }

    private string LevelCleared()
    {
        Debug.LogWarning("ADD next scene name HERE!");
        return null;
    }
}