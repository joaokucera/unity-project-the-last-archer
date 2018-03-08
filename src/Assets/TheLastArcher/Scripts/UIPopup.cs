using UnityEngine;

public abstract class UIPopup : IInit
{
    [SerializeField]
    private GameObject _popupObject;

    public abstract void Init();

    protected void Show()
    {
        _popupObject.gameObject.SetActive(true);
    }

    protected void Hide()
    {
        _popupObject.gameObject.SetActive(false);
    }
}