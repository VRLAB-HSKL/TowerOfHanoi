using HTC.UnityPlugin.Vive;
using UnityEngine;

/// <summary>
/// This class contains the input control of the PC-Vive and Vive Focus Plus Android version
/// </summary>
public class SwitchGameState : MonoBehaviour
{

    #region Variables

    // int to switch game state between 3, 5 and 7 discs
    private int changeState;

    #endregion

    #region Unity standard Methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        changeState = 0;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    #endregion

    #region Setup & Destroy Listeners

    /// <summary>
    /// Add Listener [Right Hand][Grip-Button] to switch game state between 3, 5 and 7 discs
    /// </summary>
    private void Awake()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, ChangeGameState);
    }

    /// <summary>
    /// Destroy Listener [Right Hand][Grip-Button] to switch game state between 3, 5 and 7 discs
    /// </summary>
    private void OnDestroy()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, ChangeGameState);
    }

    #endregion

    #region Change Game State via VIVE Controller

    /// <summary>
    /// Method to switch game state between 3, 5 and 7 discs
    /// </summary>
    void ChangeGameState()
    {
        Debug.Log("GameState: " + changeState);
        if (changeState == 3) changeState = 0;
        GameObject.Find("ToH").GetComponent<GameToH>().ChangingGameState(changeState);
        changeState++;
    }

    #endregion

}