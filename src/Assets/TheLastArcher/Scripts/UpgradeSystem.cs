using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    private UIUpgradesPopup _upgradesPopup;

    private void Start()
    {
        _upgradesPopup.Init();
        _upgradesPopup.CreateUpgradeItems(UpgradeSelected);
    }

    private void UpgradeSelected(UpgradeItemType type)
    {
        Debug.LogWarning("ADD Upgrade selection callback HERE! >>> " + type);
    }
}