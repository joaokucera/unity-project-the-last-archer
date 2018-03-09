using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemDisplay : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Button _button;

    public delegate void UpgradeSelected();

    public void Setup(UpgradeItem item, UpgradeSelected onUpgradeSelected)
    {
        _text.text = item.Name;
        _image.sprite = item.Icon;
        _button.onClick.AddListener(() => onUpgradeSelected());
    }
}