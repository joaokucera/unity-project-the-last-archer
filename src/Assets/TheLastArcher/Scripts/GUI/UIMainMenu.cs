using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour 
{
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Button _facebookButton;
    [SerializeField]
    private Button _twitterButton;

    private void Start()
    {
        _playButton.onClick.AddListener(() => SceneManager.LoadScene("Map"));
        _exitButton.onClick.AddListener(() => Application.Quit());
        _facebookButton.onClick.AddListener(FacebookClick);
        _twitterButton.onClick.AddListener(TwitterClick);
    }

    private void FacebookClick()
    {
        Debug.LogWarning("ADD Facebook connection HERE!");
    }

    private void TwitterClick()
    {
        Debug.LogWarning("ADD Twitter connection HERE!");
    }
}