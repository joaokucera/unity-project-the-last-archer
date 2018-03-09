using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIUpgradesPopup : UIPopup
{
    private readonly string _tag = "Upgrade";

    [SerializeField]
    private Transform _upgradesParent;
    [SerializeField]
    private Button _closeButton;
    [SerializeField]
    private PoolingSystem _poolingSystem;

    public override void Init()
    {
        _closeButton.onClick.AddListener(Close);

        CreateUpgradeItems();
    }

    private void CreateUpgradeItems()
    {
        UpgradeItem[] upgradeItems = ResourcesService.GetUpgradeItems();

        for (int i = 0; i < upgradeItems.Length; i++) {
            GameObject obj = _poolingSystem.Dequeue(_tag, _upgradesParent);

            var display = obj.GetComponent<UpgradeItemDisplay>();
            if (display) {
                display.Setup(upgradeItems[i], UpgradeSelected);
            }
        }
    }

    private void UpgradeSelected()
    {
        Debug.LogWarning("ADD Upgrade selection callback HERE!");
    }
}