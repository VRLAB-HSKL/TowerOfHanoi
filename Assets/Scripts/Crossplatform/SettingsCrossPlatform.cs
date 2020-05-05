#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

[InitializeOnLoad]
public class SettingsCrossPlatform 
{
    const string menuTitel = "TowerOfHanoi-Settings";

    public static List<GameObject> allGameObjects;
    public static GameObject FPSController;
    public static GameObject VROrigins;
    public static GameObject GvrEditorEmulator;
    public static GameObject GvrCameraRig;
    public static GameObject GvrEventSystem;

    
    static SettingsCrossPlatform()
    {
        FindAllGameObjects();
        InitGameObjects();
    }

    private static void InitGameObjects()
    {
        FPSController = FindGameObjectByName("FPSController");
        VROrigins = FindGameObjectByName("VROrigins");
        GvrEditorEmulator = FindGameObjectByName("GvrEditorEmulator");
        GvrCameraRig = FindGameObjectByName("GvrCameraRig");
        GvrEventSystem = FindGameObjectByName("GvrEventSystem");
    }

    [MenuItem(menuTitel + "/" + "Target PC Standalone")]
    private static void SwitchToPCStandalone()
    {
        FPSController.SetActive(true);
        VROrigins.SetActive(false);
        GvrEditorEmulator.SetActive(false);
        GvrCameraRig.SetActive(false);
        GvrEventSystem.SetActive(false);

    }

    [MenuItem(menuTitel + "/" + "Target PC-Vive")]
    private static void SwitchToPCVive()
    {
        FPSController.SetActive(false);
        VROrigins.SetActive(true);
        GvrEditorEmulator.SetActive(false);
        GvrCameraRig.SetActive(false);
        GvrEventSystem.SetActive(false);
    }

    [MenuItem(menuTitel + "/" + "Target ViveFocus (Android)")]
    private static void SwitchtoViveFocus()
    {
        FPSController.SetActive(false);
        VROrigins.SetActive(true);
        GvrEditorEmulator.SetActive(false);
        GvrCameraRig.SetActive(false);
        GvrEventSystem.SetActive(false);
    }

    [MenuItem(menuTitel + "/" + "Target Cardboard (Android)")]
    private static void SwitchtoCardboard()
    {
        FPSController.SetActive(false);
        VROrigins.SetActive(false);
        GvrEditorEmulator.SetActive(true);
        GvrCameraRig.SetActive(true);
        GvrEventSystem.SetActive(true);
    }

    public static GameObject FindGameObjectByName(string name)
    {
        
        foreach(GameObject go in allGameObjects)
        {
            if(go.name == name)
            {
                return go;
            }
        }

        return null;
    }

    public static void FindAllGameObjects()
    {
        allGameObjects = new List<GameObject>();

        if (!allGameObjects.Any())
        {
            foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
            {
                if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                    allGameObjects.Add(go);
            }
        }

    }
} 
#endif