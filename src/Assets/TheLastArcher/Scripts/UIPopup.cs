using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class UIPopup : IInit
{
    [SerializeField]
    private GameObject _popupObject;

    public abstract void Init();

    public virtual void Open()
    {
        _popupObject.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        _popupObject.gameObject.SetActive(false);
    }

    protected void LoadCurrentScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        LoadScene(sceneName);
    }

    protected void LoadMapScene()
    {
        LoadScene("Map");
    }

    protected void LoadMenuScene()
    {
        LoadScene("Menu");
    }

    protected void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}