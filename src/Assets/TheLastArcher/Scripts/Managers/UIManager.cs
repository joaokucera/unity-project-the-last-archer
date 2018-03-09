using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UISettingsPopup _settingsPopup;
    [SerializeField]
    private UIPausedPopup _pausedPopup;
    [SerializeField]
    private UIDefeatedPopup _defeatedPopup;
    [SerializeField]
    private UILevelClearedPopup _levelClearedPopup;

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
        _settingsPopup.Init();
        _pausedPopup.Init();
        _defeatedPopup.Init();
        _levelClearedPopup.Init();
    }
}