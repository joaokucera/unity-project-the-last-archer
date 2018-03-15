using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIGameStatus _gameStatus;
    [SerializeField]
    private UIGameCommands _gameCommands;
    [SerializeField]
    private UISettingsPopup _settingsPopup;
    [SerializeField]
    private UIPausedPopup _pausedPopup;
    [SerializeField]
    private UIDefeatedPopup _defeatedPopup;
    [SerializeField]
    private UILevelClearedPopup _levelClearedPopup;

    public UIGameStatus GameStatus {
        get {
            return _gameStatus;
        }
    }

    public UIGameCommands GameCommands {
        get {
            return _gameCommands;
        }
    }

    public UISettingsPopup SettingsPopup {
        get {
            return _settingsPopup;
        }
    }

    public UIPausedPopup PausePopup {
        get {
            return _pausedPopup;
        }
    }

    public UIDefeatedPopup DefeatPopup {
        get {
            return _defeatedPopup;
        }
    }

    public UILevelClearedPopup LevelClearedPopup {
        get {
            return _levelClearedPopup;
        }
    }

    private void Start()
    {
        _gameStatus.Init();
        _gameStatus.UpdateHearts();

        _gameCommands.Init();
        _settingsPopup.Init();
        _pausedPopup.Init();
        _defeatedPopup.Init();
        _levelClearedPopup.Init();
    }
}