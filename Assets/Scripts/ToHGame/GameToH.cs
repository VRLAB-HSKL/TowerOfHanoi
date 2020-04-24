using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameToH : MonoBehaviour
{
  
    #region Variables

    //
    public Vector3[] poleApositions;
    
    //
    public Vector3[] poleBpositions;
    
    //
    public Vector3[] poleCpositions;
    
    //
    public GameObject Discs_3;
    
    //
    public GameObject Discs_5;
    
    //
    public GameObject Discs_7;
    
    //
    public GameObject Pole_A;
    
    //
    public GameObject Pole_B;
    
    //
    public GameObject Pole_C;

    //
    private Vector3 oldPosition;


    #endregion

    #region Unity-Standard-Methods

    // Start is called before the first frame update
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        oldPosition = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        ChangingGameState(-1);
    }

    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        
    }

    #endregion

    #region ChangeGameState-Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="DiscState"></param>
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
    /// 
    /// </summary>
    /// <param name="DiscState"></param>
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
    /// 
    /// </summary>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator startGameWithDiscOfThree()
    {
        Discs_5.SetActive(false);
        Discs_7.SetActive(false); 
        Discs_3.SetActive(true); 
        StartCoroutine(fillDisc3Positions());
        StartCoroutine(enablePoles());
        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator startGameWithDiscOfFive()
    {
        Discs_3.SetActive(false);
        Discs_7.SetActive(false);
        Discs_5.SetActive(true);
        StartCoroutine(fillDisc5Positions());
        StartCoroutine(enablePoles());
        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IEnumerator startGameWithDiscOfSeven()
    {
        Discs_3.SetActive(false);
        Discs_5.SetActive(false);
        Discs_7.SetActive(true);
        StartCoroutine(fillDisc7Positions());
        StartCoroutine(enablePoles());
        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
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
        yield return new WaitForSeconds(2f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
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
        yield return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
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
        yield return null;
    }

    #endregion

    #region Getter / Setter Disc-Positions
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public Vector3 GetPoleAposition(int i)
    {
        Debug.Log(i);
        return poleApositions[i];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public Vector3 GetPoleBposition(int i)
    {
        return poleBpositions[i];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public Vector3 GetPoleCposition(int i)
    {
        return poleCpositions[i];
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_oldPosition"></param>
    public void SetOldDiscPosition(Vector3 _oldPosition)
    {
        oldPosition = _oldPosition;
        Debug.Log("GameToH-oldPosition: " + oldPosition.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Vector3 GetOldDiscPosition()
    {
        return oldPosition;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameobjects"></param>
    /// <returns></returns>
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