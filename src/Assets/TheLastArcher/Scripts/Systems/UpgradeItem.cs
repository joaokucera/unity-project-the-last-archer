using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Item", menuName = "Upgrade Item")]
public class UpgradeItem : ScriptableObject
{
    [SerializeField]
    private UpgradeItemType _type;
    public UpgradeItemType Type {
        get {
            return _type;
        }
    }

    [SerializeField]
    private string _name;
    public string Name {
        get {
            return _name;
        }
    }

    [SerializeField]
    private Sprite _icon;
    public Sprite Icon {
        get {
            return _icon;
        }
    }
}