using UnityEngine;

/// <summary>
/// This class contains the input control of the Windows standalone version
/// </summary>
public class KeyBoardController : MonoBehaviour
{
    // used to switch the game state between 3,5 and 7 discs
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
