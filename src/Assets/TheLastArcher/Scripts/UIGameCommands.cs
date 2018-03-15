using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIGameCommands : IInit
{
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private Button _settingsButton;
    [SerializeField]
    private Button _shootCommand;
    [SerializeField]
    private GameCommandButton _walkCommand;

    public event CommandEvent OnPauseClick = delegate { };
    public event CommandEvent OnSettingsClick = delegate { };
    public event CommandEvent OnShootClick = delegate { };
    public event CommandEvent OnWalkClick = delegate { };
    public event CommandEvent OnWalkRelease = delegate { };

    public void Init()
    {
        _pauseButton.onClick.AddListener(() => OnPauseClick());
        _settingsButton.onClick.AddListener(() => OnSettingsClick());
        _shootCommand.onClick.AddListener(() => OnShootClick());

        _walkCommand.OnDownEvent += OnWalkClick;
        _walkCommand.OnUpEvent += OnWalkRelease;
    }
}