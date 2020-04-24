using HTC.UnityPlugin.Vive;
using UnityEngine;

public class SwitchGameState : MonoBehaviour
{
    public GameObject Discs_3;
    public GameObject Discs_5;
    public GameObject Discs_7;

    private int changeState;
    
    

    // Start is called before the first frame update
    void Start()
    {
        changeState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, ChangeGameState);
    }

    private void OnDestroy()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, ChangeGameState);
    }

    void ChangeGameState()
    {
        Debug.Log("GameState: " + changeState);
        if (changeState == 3) changeState = 0;
        GameObject.Find("ToH").GetComponent<GameToH>().ChangingGameState(changeState);
        changeState++;
    }
}
