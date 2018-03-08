using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class UIPausePopup : UIPopup
{
    [SerializeField]
    private Button _continueButton;
    [SerializeField]
    private Button _mapButton;
    [SerializeField]
    private Button _exitButton;

    public override void Init()
    {
        _continueButton.onClick.AddListener(OnContinueClick);
        _mapButton.onClick.AddListener(OnMapClick);
        _exitButton.onClick.AddListener(OnExitClick);
    }

    public void Open()
    {
        Time.timeScale = 0;

        Show();
    }

    private void OnContinueClick()
    {
        Hide();

        Time.timeScale = 1;
    }

    private void OnMapClick()
    {
        SceneManager.LoadScene("Map");
    }

    private void OnExitClick()
    {
        SceneManager.LoadScene("Menu");
    }
}