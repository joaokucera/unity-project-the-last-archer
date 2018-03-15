using UnityEngine;

public static class ResourcesService
{
    public static UpgradeItem[] GetUpgradeItems()
    {
        return Resources.LoadAll<UpgradeItem>("UpgradeItems");
    }
}