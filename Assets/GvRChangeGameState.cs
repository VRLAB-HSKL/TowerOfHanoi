using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GvRChangeGameState : MonoBehaviour
{
    public int changeState;

    private void Awake()
    {
        changeState = 0;
    }
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void ChangeGameState()
    {
        GetComponent<Renderer>().material.color = Color.black;
        if (changeState == 3) changeState = 0;
        GameObject.Find("ToH").GetComponent<GameToH>().ChangingGameState(changeState);
        changeState++;
    }
}
