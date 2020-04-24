using HTC.UnityPlugin.Vive;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class SwitchGameState : MonoBehaviour
{

    #region Variables

    //
    public GameObject Discs_3;
    
    //
    public GameObject Discs_5;
    
    //
    public GameObject Discs_7;

    //
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
    /// 
    /// </summary>
    private void Awake()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, ChangeGameState);
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDestroy()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, ChangeGameState);
    }

    #endregion

    #region Change Game State via VIVE Controller

    /// <summary>
    /// 
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