using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIDefeatedPopup : UIPopup
{
    [SerializeField]
    private Button _playAgainButton;
    [SerializeField]
    private Button _mapButton;
    [SerializeField]
    private Button _mainMenuButton;

    public override void Init()
    {
        _playAgainButton.onClick.AddListener(Close);
        _mapButton.onClick.AddListener(LoadMapScene);
        _mainMenuButton.onClick.AddListener(LoadMenuScene);
    }
}