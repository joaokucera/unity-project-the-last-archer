using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIPausedPopup : UIPopup
{
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _mapButton;
    [SerializeField]
    private Button _mainMenuButton;

    public override void Init()
    {
        _resumeButton.onClick.AddListener(Close);
        _restartButton.onClick.AddListener(LoadCurrentScene);
        _mapButton.onClick.AddListener(LoadMapScene);
        _mainMenuButton.onClick.AddListener(LoadMenuScene);
    }

    public override void Open()
    {
        base.Open();

        Time.timeScale = 0;
    }

    public override void Close()
    {
        base.Close();

        Time.timeScale = 1;
    }
}