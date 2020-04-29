using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : MonoBehaviour
{
    private int changeState;
    // Start is called before the first frame update
    void Start()
    {
        changeState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            if (changeState == 3) changeState = 0;
            GameObject.Find("ToH").GetComponent<GameToH>().ChangingGameState(changeState);
            changeState++;
        }
    }
}
