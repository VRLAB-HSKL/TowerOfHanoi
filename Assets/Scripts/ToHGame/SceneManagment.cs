using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This class contains the actual scene name
/// </summary>
public class SceneManagment : MonoBehaviour
{

    /// <summary>
    /// Getter to return the actual scene name
    /// </summary>
    /// <returns>using UntinyEngine.SceneManagement to return the actual scene name</returns>
    public string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
