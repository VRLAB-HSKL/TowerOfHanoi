using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CustomMenu : MonoBehaviour
{
   
    [MenuItem("Crossplaform/Settings")] //creates a new menu tab
    static void Settings()
    {

    }

    [MenuItem("Crossplaform/Devices/PC-Standalone[x64]")] //Adds to the project window's create menu
    static void TargetPCStandaloneX64()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
        //Open the Scene in the Editor (do not enter Play Mode)
        EditorSceneManager.OpenScene("Assets/Scenes/ToH-PCStandalone.unity");
        
    }
    
    [MenuItem("Crossplaform/Devices/HTC-VivePro")] 
    static void TargetHTCVivePro()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64);
        EditorSceneManager.OpenScene("Assets/Scenes/ToH-VivePro.unity");
    }

    [MenuItem("Crossplaform/Devices/HTC-Vive-Focus")] 
    static void TargetHTCViveFocusPlus()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        EditorSceneManager.OpenScene("Assets/Scenes/ToH-ViveFocus.unity");
    }
    [MenuItem("Crossplaform/Devices/Cardboard")] 
    static void TargetCardboard()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);
        EditorSceneManager.OpenScene("Assets/Scenes/ToH-Cardboard.unity");
    }
}
