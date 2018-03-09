using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UILevelClearedPopup : UIPopup
{
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _playAgainButton;
    [SerializeField]
    private Button _mapButton;
    [SerializeField]
    private Button _mainMenuButton;

    public delegate string LevelCleared();
    public event LevelCleared OnLevelCleared = delegate { return null; };

    public override void Init()
    {
        _nextButton.onClick.AddListener(LoadNextScene);
        _playAgainButton.onClick.AddListener(Close);
        _mapButton.onClick.AddListener(LoadMapScene);
        _mainMenuButton.onClick.AddListener(LoadMenuScene);
    }

    private void LoadNextScene()
    {
        string sceneName = OnLevelCleared();

        if (string.IsNullOrEmpty(sceneName)) {
            Debug.LogWarning("Next scene name is missing!");
            return;
        }

        LoadScene(sceneName);
    }
}