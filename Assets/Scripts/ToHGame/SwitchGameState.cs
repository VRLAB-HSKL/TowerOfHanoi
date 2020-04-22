using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, changeGameState);
    }

    private void OnDestroy()
    {
        ViveInput.AddListenerEx(HandRole.RightHand, ControllerButton.Grip, ButtonEventType.Down, changeGameState);
    }

    void changeGameState()
    {
        Debug.Log("GameState: " + changeState);
        if (changeState == 3) changeState = 0;
        switch(changeState)
        {
            case 0: Discs_5.SetActive(false); Discs_7.SetActive(false); Discs_3.SetActive(true); break;
            case 1: Discs_3.SetActive(false); Discs_7.SetActive(false); Discs_5.SetActive(true); break;
            case 2: Discs_3.SetActive(false); Discs_5.SetActive(false); Discs_7.SetActive(true); break;
            default: break;
        }
        changeState++;
    }
}
