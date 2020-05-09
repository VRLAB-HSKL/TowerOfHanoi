using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
