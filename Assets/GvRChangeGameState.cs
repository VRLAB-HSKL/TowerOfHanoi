using UnityEngine;

/// <summary>
/// This class contains the input control of the Android Cardboard version
/// </summary>
public class GvRChangeGameState : MonoBehaviour
{
    // This Variable is used to switch between 3, 5 and 7 Discs
    public int changeState;

    /// <summary>
    /// Init with 0 => Initial play with 3 Discs
    /// changeState = 0 => 3 Discs
    /// changeState = 1 => 5 Discs
    /// changeState = 2 => 7 Discs
    /// </summary>
    private void Awake()
    {
        changeState = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    /// <summary>
    /// Switching game mode between 3, 5 and 7 discs
    /// </summary>
    public void ChangeGameState()
    {
        GetComponent<Renderer>().material.color = Color.black;
        if (changeState == 3) changeState = 0;
        GameObject.Find("ToH").GetComponent<GameToH>().ChangingGameState(changeState);
        changeState++;
    }
}
