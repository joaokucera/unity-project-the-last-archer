using UnityEngine;
using UnityEngine.UI;

public delegate void UpgradeSelected(UpgradeItemType type);

public class UpgradeItemDisplay : MonoBehaviour
{
    private UpgradeItem _item;

    [SerializeField]
    private Text _text;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Button _button;

    public void Setup(UpgradeItem item, UpgradeSelected onUpgradeSelected)
    {
        _item = item;

        _text.text = _item.Name;
        _image.sprite = _item.Icon;

        _button.onClick.AddListener(() => onUpgradeSelected(_item.Type));
    }
}