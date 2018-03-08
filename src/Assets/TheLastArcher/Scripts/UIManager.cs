using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UISettingsPopup _settingsPopup;
    [SerializeField]
    private UIPausePopup _pausePopup;

    public UISettingsPopup SettingsPopup {
        get {
            return _settingsPopup;
        }
    }

    public UIPausePopup PausePopup {
        get {
            return _pausePopup;
        }
    }

    private void Start()
    {
        _settingsPopup.Init();
        _pausePopup.Init();
    }
}