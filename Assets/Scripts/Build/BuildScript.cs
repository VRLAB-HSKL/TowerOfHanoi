using UnityEditor;

/// <summary>
/// Crossplatform Buildscript
/// </summary>
public class BuildScript
{
    /// <summary>
    /// Build KeyBoard / Mouse WindowsX64
    /// </summary>
    static void PerformBuildWindowsStandaloneX64()
    {
        string[] defaultScene = { "Assets/Scenes/ToH-PCStandalone.unity" };
        BuildPipeline.BuildPlayer(defaultScene, "./builds/WinX64",
            BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    /// <summary>
    /// Build VivePro WindowsX64
    /// </summary>
    static void PerformBuildWindowsVivePro()
    {
        string[] defaultScene = { "Assets/Scenes/ToH-VivePro.unity" };
        BuildPipeline.BuildPlayer(defaultScene, "./builds/WinX64",
            BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    /// <summary>
    /// Build ViveFocus Android
    /// </summary>
    static void PerformBuildAndroidViveFocus()
    {
        string[] defaultScene = { "Assets/Scenes/ToH-ViveFocus.unity" };
        BuildPipeline.BuildPlayer(defaultScene, "./builds/Android",
            BuildTarget.Android, BuildOptions.None);
    }

    /// <summary>
    /// Build Cardboard Android
    /// </summary>
    static void PerformBuildAndroidCardboard()
    {
        string[] defaultScene = { "Assets/Scenes/ToH-Cardboard.unity" };
        BuildPipeline.BuildPlayer(defaultScene, "./builds/Android",
            BuildTarget.Android, BuildOptions.None);
    }
}
