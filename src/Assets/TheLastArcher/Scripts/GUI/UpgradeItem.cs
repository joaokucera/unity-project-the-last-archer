using UnityEngine;

public class UpgradeItem : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name {
        get {
            return _name;
        }
    }

    private Sprite _icon;
    public Sprite Icon {
        get {
            return _icon;
        }
    }
}
