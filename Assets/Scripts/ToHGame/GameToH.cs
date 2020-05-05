using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class contains the objects to be initialized, which are required by Tower of Hanoi.
/// It also manages and configures the number of playable discs as well as checking player moves based on the given rule.
/// </summary>
public class GameToH : MonoBehaviour
{

    #region Variables

    // contains calculated discs positions (Pole A)
    public Vector3[] poleApositions;

    // contains calculated discs positions (Pole B)
    public Vector3[] poleBpositions;
    
    // contains calculated discs positions (Pole C)
    public Vector3[] poleCpositions;
    
    // contains the prefab of three discs
    public GameObject Discs_3;
    
    // contains the prefab of five discs
    public GameObject Discs_5;
    
    // contains the prefab of seven discs
    public GameObject Discs_7;
    
    // contains the pole a gameobject
    public GameObject Pole_A;
    
    // contains the pole b gameobject
    public GameObject Pole_B;
    
    // contains the pole c gameobject
    public GameObject Pole_C;

    // number of currently playable discs 
    public int maxDiscStackSize;


    #endregion

    #region Unity-Standard-Methods

   
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
       
    }

    /// <summary>
    /// Setup the initial game state. The game starts in the initial state of -1 (all objects disabled).
    /// </summary>
    private void Awake()
    {
        ChangingGameState(-1);
    }

    
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }

    #endregion

    #region ChangeGameState-Methods

    /// <summary>
    /// The game starts in the initial state of -1 (all objects disabled). With the controller input you can choose from 3.5 and 7 discs
    /// </summary>
    /// <param name="DiscState"> switching game state from controller input.</param>
    public void ChangingGameState(int DiscState)
    {
        if(DiscState == -1 )
        {
            Discs_5.SetActive(false);
            Discs_3.SetActive(false);
            Discs_7.SetActive(false);
            Pole_A.SetActive(false);
            Pole_B.SetActive(false);
            Pole_C.SetActive(false);
        }
        else
        {
            StartCoroutine(disablePoles());
            SwitchGameState(DiscState);
        }
    }


    /// <summary>
    /// starts the desired game based on the passed variable
    /// </summary>
    /// <param name="DiscState"> starting value from controller input </param>
    private void SwitchGameState(int DiscState)
    {
        switch (DiscState)
        {
            case 0: StartCoroutine(startGameWithDiscOfThree()); break;
            case 1: StartCoroutine(startGameWithDiscOfFive()); break;
            case 2: StartCoroutine(startGameWithDiscOfSeven()); break;
            default: break;
        }
    }
    #endregion

    #region Coroutines

    /// <summary>
    /// disable the poles
    /// </summary>
    /// <returns> no wait actually needed => null </returns>
    IEnumerator disablePoles()
    {
        Destroy(Pole_A.GetComponent<ColliderPoleA>());
        Destroy(Pole_B.GetComponent<ColliderPoleB>());
        Destroy(Pole_C.GetComponent<ColliderPoleC>());
        Pole_A.SetActive(false);
        Pole_B.SetActive(false);
        Pole_C.SetActive(false);
        yield return null;
    }

    /// <summary>
    /// enables the poles
    /// </summary>
    /// <returns> no wait actually needed => null </returns>
    IEnumerator enablePoles()
    {
        Pole_A.AddComponent<ColliderPoleA>();
        Pole_B.AddComponent<ColliderPoleB>();
        Pole_C.AddComponent<ColliderPoleC>();
        Pole_A.SetActive(true);
        Pole_B.SetActive(true);
        Pole_C.SetActive(true);
        yield return null;
    }

    /// <summary>
    /// Inits the game with three discs
    /// </summary>
    /// <returns> Waits until the end of the frame after Unity has rendererd every Camera and GUI
    /// ,just before displaying the frame on screen. </returns>
    IEnumerator startGameWithDiscOfThree()
    {
        Discs_5.SetActive(false);
        Discs_7.SetActive(false); 
        Discs_3.SetActive(true); 
        StartCoroutine(fillDisc3Positions());
        StartCoroutine(enablePoles());
        maxDiscStackSize = 3;
        yield return new WaitForEndOfFrame();
    }

    /// <summary>
    /// Inits the game with five discs
    /// </summary>
    /// <returns> Waits until the end of the frame after Unity has rendererd every Camera and GUI
    /// ,just before displaying the frame on screen. </returns>
    IEnumerator startGameWithDiscOfFive()
    {
        Discs_3.SetActive(false);
        Discs_7.SetActive(false);
        Discs_5.SetActive(true);
        StartCoroutine(fillDisc5Positions());
        StartCoroutine(enablePoles());
        maxDiscStackSize = 5;
        yield return new WaitForEndOfFrame();
    }

    /// <summary>
    /// Inits the Game with seven discs
    /// </summary>
    /// <returns> Waits until the end of the frame after Unity has rendererd every Camera and GUI
    /// ,just before displaying the frame on screen. </returns>
    IEnumerator startGameWithDiscOfSeven()
    {
        Discs_3.SetActive(false);
        Discs_5.SetActive(false);
        Discs_7.SetActive(true);
        StartCoroutine(fillDisc7Positions());
        StartCoroutine(enablePoles());
        maxDiscStackSize = 7;
        yield return new WaitForEndOfFrame();
    }

    /// <summary>
    /// Calculates the starting positions of the discs at pole A and calculates the other positions at pole B and pole C.
    /// </summary>
    /// <returns> Suspends the coroutine execution for the given amount of seconds using scaled time. </returns>
    IEnumerator fillDisc3Positions()
    {
        poleApositions = new Vector3[3];
        poleBpositions = new Vector3[3];
        poleCpositions = new Vector3[3];
        Vector3 scale_x = new Vector3(0.6f, 0, 0);

        Vector3 fillVec = GameObject.Find("Disc1").transform.position; 
        poleApositions[0] = fillVec;
        Vector3 fillVec1 = GameObject.Find("Disc2").transform.position;
        poleApositions[1] = fillVec1;
        Vector3 fillVec2 = GameObject.Find("Disc3").transform.position;
        poleApositions[2] = fillVec2;

        poleBpositions[0] = (fillVec + scale_x);
        poleBpositions[1] = (fillVec1 + scale_x);
        poleBpositions[2] = (fillVec2 + scale_x);

        poleCpositions[0] = (fillVec + 2 * scale_x);
        poleCpositions[1] = (fillVec1 + 2 * scale_x);
        poleCpositions[2] = (fillVec2 + 2 * scale_x);
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[0], "Disc1");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[1], "Disc2");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[2], "Disc3");
        
        yield return new WaitForSeconds(.1f);
    }

    /// <summary>
    /// Calculates the starting positions of the discs at pole A and calculates the other positions at pole B and pole C.
    /// </summary>
    /// <returns> Suspends the coroutine execution for the given amount of seconds using scaled time. </returns>
    IEnumerator fillDisc5Positions()
    {
        poleApositions = new Vector3[5];
        poleBpositions = new Vector3[5];
        poleCpositions = new Vector3[5];
        Vector3 scale_x = new Vector3(0.6f, 0, 0);

        Vector3 fillVec = GameObject.Find("Disc1").transform.position;
        poleApositions[0] = fillVec;
        Vector3 fillVec1 = GameObject.Find("Disc2").transform.position;
        poleApositions[1] = fillVec1;
        Vector3 fillVec2 = GameObject.Find("Disc3").transform.position;
        poleApositions[2] = fillVec2;
        Vector3 fillVec3 = GameObject.Find("Disc4").transform.position;
        poleApositions[3] = fillVec3;
        Vector3 fillVec4 = GameObject.Find("Disc5").transform.position;
        poleApositions[4] = fillVec4;
        

        poleBpositions[0] = (fillVec + scale_x);
        poleBpositions[1] = (fillVec1 + scale_x);
        poleBpositions[2] = (fillVec2 + scale_x);
        poleBpositions[3] = (fillVec3 + scale_x);
        poleBpositions[4] = (fillVec4 + scale_x);

        poleCpositions[0] = (fillVec + 2 * scale_x);
        poleCpositions[1] = (fillVec1 + 2 * scale_x);
        poleCpositions[2] = (fillVec2 + 2 * scale_x);
        poleCpositions[3] = (fillVec3 + 2 * scale_x);
        poleCpositions[4] = (fillVec4 + 2 * scale_x);
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[0], "Disc1");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[1], "Disc2");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[2], "Disc3");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[3], "Disc4");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[4], "Disc5");
        
        yield return new WaitForSeconds(.1f); 
    }

    /// <summary>
    /// Calculates the starting positions of the discs at pole A and calculates the other positions at pole B and pole C.
    /// </summary>
    /// <returns> Suspends the coroutine execution for the given amount of seconds using scaled time. </returns>
    IEnumerator fillDisc7Positions()
    {
        poleApositions = new Vector3[7];
        poleBpositions = new Vector3[7];
        poleCpositions = new Vector3[7];
        Vector3 scale_x = new Vector3(0.6f, 0, 0);

        Vector3 fillVec = GameObject.Find("Disc1").transform.position;
        poleApositions[0] = fillVec;
        Vector3 fillVec1 = GameObject.Find("Disc2").transform.position;
        poleApositions[1] = fillVec1;
        Vector3 fillVec2 = GameObject.Find("Disc3").transform.position;
        poleApositions[2] = fillVec2;
        Vector3 fillVec3 = GameObject.Find("Disc4").transform.position;
        poleApositions[3] = fillVec3;
        Vector3 fillVec4 = GameObject.Find("Disc5").transform.position;
        poleApositions[4] = fillVec4;
        Vector3 fillVec5 = GameObject.Find("Disc6").transform.position;
        poleApositions[5] = fillVec5;
        Vector3 fillVec6 = GameObject.Find("Disc7").transform.position;
        poleApositions[6] = fillVec6;


        poleBpositions[0] = (fillVec + scale_x);
        poleBpositions[1] = (fillVec1 + scale_x);
        poleBpositions[2] = (fillVec2 + scale_x);
        poleBpositions[3] = (fillVec3 + scale_x);
        poleBpositions[4] = (fillVec4 + scale_x);
        poleBpositions[5] = (fillVec5 + scale_x);
        poleBpositions[6] = (fillVec6 + scale_x);


        poleCpositions[0] = (fillVec + 2 * scale_x);
        poleCpositions[1] = (fillVec1 + 2 * scale_x);
        poleCpositions[2] = (fillVec2 + 2 * scale_x);
        poleCpositions[3] = (fillVec3 + 2 * scale_x);
        poleCpositions[4] = (fillVec4 + 2 * scale_x);
        poleCpositions[5] = (fillVec5 + 2 * scale_x);
        poleCpositions[6] = (fillVec6 + 2 * scale_x);

        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[0], "Disc1");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[1], "Disc2");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[2], "Disc3");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[3], "Disc4");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[4], "Disc5");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[5], "Disc6");
        GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(poleApositions[6], "Disc7");
        yield return new WaitForSeconds(.1f);
    }

    #endregion

    #region Getter / Setter Disc-Positions
    /// <summary>
    /// get specific positions as vector3 from Pole-A array.
    /// </summary>
    /// <param name="i"> number to access array</param>
    /// <returns> position as vector3 </returns>
    public Vector3 GetPoleAposition(int i)
    {
        return poleApositions[i];
    }

    /// <summary>
    /// get specific positions as vector3 from Pole-B array.
    /// </summary>
    /// <param name="i"> number to access array </param>
    /// <returns> position as vector3 </returns>
    public Vector3 GetPoleBposition(int i)
    {
        return poleBpositions[i];
    }

    /// <summary>
    /// get specific positions as vector3 from Pole-C array.
    /// </summary>
    /// <param name="i"> number to access array </param>
    /// <returns> position as vector3 </returns>
    public Vector3 GetPoleCposition(int i)
    {
        return poleCpositions[i];
    }

    /// <summary>
    /// number of currently playable discs
    /// example: 3 Discs => return 3, 5 Discs => return 5, etc.
    /// </summary>
    /// <returns> number of currently playable discs </returns>
    public int GetMaxStackSizeForPoleC()
    {
        return maxDiscStackSize;
    }

    /// <summary>
    /// This method checks whether a moving disc at pole a / -b / -c can be placed there
    /// or whether it violates the rule that no larger disc can be placed on a smaller one.
    /// This is done by checking the object scales.
    /// </summary>
    /// <param name="gameobjects"> contains the game objects of the pole to be checked </param>
    /// <returns> returns true or false based on the rules </returns>
    public bool CheckDiscPositions(List<GameObject> gameobjects)
    {
        if (!gameobjects.Any()) return true;

        if (gameobjects.Count == 1)
        {
            return true;
        }
        else
        {
            GameObject[] array = gameobjects.ToArray();
            for (int i = 0; i < array.Length-1; i++)
            {
                if(array[i].gameObject.transform.localScale.x < array[i+1].gameObject.transform.localScale.x)
                {
                    Debug.Log("Scale.x[1]: " + array[i].gameObject.transform.localScale.x + " ; Scale.x[2]:" + array[i + 1].gameObject.transform.localScale.x);
                    return false;
                }
            }

            return true;
        }       
    }
    #endregion

}