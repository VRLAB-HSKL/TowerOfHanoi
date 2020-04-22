#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class SettingsCrossPlatform 
{
    const string menuTitel = "TowerOfHanoi-Settings";

    [MenuItem(menuTitel + "/" + "Target PC Standalone")]
    private static void SwitchToPCStandalone()
    {

    }

    [MenuItem(menuTitel + "/" + "Target Vive")]
    private static void SwitchToVive()
    {

    }

    [MenuItem(menuTitel + "/" + "Target ViveFocus (Android)")]
    private static void SwitchtoViveFocus()
    {

    }
}
#endif