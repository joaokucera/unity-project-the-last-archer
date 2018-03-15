using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private AudioManager _audioManager;
    [SerializeField]
    private HeroineController _heroineController;

    private void Start()
    {
        //GAME MANAGER subscriptions.
        _uiManager.LevelClearedPopup.OnLevelCleared += LevelCleared;

        //AUDIO MANAGER subscriptions.
        _uiManager.SettingsPopup.OnVolumeChangedEvent += _audioManager.VolumeChanged;
        _uiManager.SettingsPopup.OnFXChangedEvent += _audioManager.FXChanged;

        //HEROINE CONTROLLER subscriptions.
        _uiManager.GameCommands.OnShootClick += _heroineController.Shoot;
        _uiManager.GameCommands.OnWalkClick += _heroineController.Walk;
        _uiManager.GameCommands.OnWalkRelease += _heroineController.Idle;
    }

    private string LevelCleared()
    {
        Debug.LogWarning("ADD next scene name HERE!");
        return null;
    }
}