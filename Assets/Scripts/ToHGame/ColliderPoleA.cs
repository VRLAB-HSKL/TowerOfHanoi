using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ColliderPoleA : MonoBehaviour
{

    #region Variables

    //
    Renderer rend;
    
    //
    public int count;
    
    //
    public List<GameObject> discPositions;
    #endregion

    #region Unity standard Methods

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        rend = GetComponent<Renderer>();
        count = 0;
        discPositions = new List<GameObject>();
    }

    #endregion

    #region Collider-Event Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
       Debug.Log("Hit: " + other.gameObject.name.ToString());
       rend.material.color = Color.green;
       if(other.gameObject.tag == "Disc")
        {
            discPositions.Add(other.gameObject);
            Destroy(other.gameObject.GetComponent<BasicGrabbable>());
            other.gameObject.transform.position = GetDiscPositions();
            other.gameObject.AddComponent<BasicGrabbable>();
            count++;
            Debug.Log(count);
            StartCoroutine(CheckGameState(other));
        }
      
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        rend.material.color = Color.white;
        if (other.gameObject.tag == "Disc")
        {
            GameObject.Find("ToH").GetComponent<GameToH>().SetOldDiscPosition(other.gameObject.transform.position);
            count--;
            discPositions.Remove(other.gameObject);
           
        }
    }

    #endregion

    #region Coroutine

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    IEnumerator CheckGameState(Collider other)
    {
        bool gameFlag = GameObject.Find("ToH").GetComponent<GameToH>().CheckDiscPositions(discPositions);
        Debug.Log("GameFlag: " + gameFlag);
        if (!gameFlag)
        {
            other.gameObject.transform.position = GameObject.Find("ToH").GetComponent<GameToH>().GetOldDiscPosition();
        }
        yield return new WaitForSeconds(.1f);
    }

    #endregion

    #region Disc positioning

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Vector3 GetDiscPositions()
    {
        Vector3 newCoords = new Vector3(0, 0, 0);
        switch (count)
        {
            case 0: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleAposition(0); break;
            case 1: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleAposition(1); break;
            case 2: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleAposition(2); break;
            case 3: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleAposition(3); break;
            case 4: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleAposition(4); break;
            case 5: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleAposition(5); break;
            case 6: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleAposition(6); break;
            
        }

        return newCoords;
    }

    #endregion

}
