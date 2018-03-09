using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField]
    private UIUpgradesPopup _upgradesPopup;

    private void Start()
    {
        _upgradesPopup.Init();
    }
}