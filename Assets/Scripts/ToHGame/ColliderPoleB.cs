using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ColliderPoleB : MonoBehaviour
{

    #region Variables

    //
    Renderer rend;
    
    //
    public List<GameObject> discPositions;
    
    //
    private int count;

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
        if (other.gameObject.tag == "Disc")
        {
            discPositions.Add(other.gameObject);
            other.gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            StartCoroutine(DeleteDragItemSkript(other));
            Destroy(other.gameObject.GetComponent<BasicGrabbable>());
            other.gameObject.transform.position = GetDiscPositions();
            other.gameObject.AddComponent<BasicGrabbable>();
            StartCoroutine(AddDragItemSkript(other));
            count++;
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
            //GameObject.Find("ToH").GetComponent<GameToH>().SetOldDiscPosition(other.gameObject.transform.position);
            //GameObject.Find("ToH").GetComponent<GameToH>().SetOldDiscPosition(other.transform.localPosition);
            count--;
            discPositions.Remove(other.gameObject);
        }
            
    }

    #endregion

    #region Coroutine


    IEnumerator DeleteDragItemSkript(Collider other)
    {
        Destroy(other.gameObject.GetComponent<DragItem>());
        /**
        switch(other.gameObject.name) 
        {
            case "Disc1": Destroy(other.gameObject.GetComponent <DragItemDiscOne>()); break;
            case "Disc2": Destroy(other.gameObject.GetComponent<DragItemDiscTwo>()); break;
            case "Disc3": Destroy(other.gameObject.GetComponent<DragItemDiscThree>()); break;
        }
    */
        yield return null;
    }

    IEnumerator AddDragItemSkript(Collider other)
    {
        other.gameObject.AddComponent<DragItem>();
        /**
        switch (other.gameObject.name)
        {
            case "Disc1": other.gameObject.AddComponent<DragItemDiscOne>(); break;
            case "Disc2": other.gameObject.AddComponent<DragItemDiscTwo>(); break;
            case "Disc3": other.gameObject.AddComponent<DragItemDiscThree>(); break;
        }
        */
        yield return null;
    }

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
            //other.gameObject.transform.position = GameObject.Find("ToH").GetComponent<GameToH>().GetOldDiscPosition();
            other.gameObject.transform.position = GameObject.Find("ToH").GetComponent<DiscPositioning>().getPositions(other.gameObject.name);
        } else
        {
            GameObject.Find("ToH").GetComponent<DiscPositioning>().setDiscPostions(other.transform.position, other.name);
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
        Vector3 newCoords = new Vector3(0,0,0);
        switch (count)
        {
            case 0: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleBposition(0); break;
            case 1: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleBposition(1); break;
            case 2: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleBposition(2); break;
            case 3: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleBposition(3); break;
            case 4: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleBposition(4); break;
            case 5: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleBposition(5); break;
            case 6: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().GetPoleBposition(6); break;
        }

        return newCoords;
    }

    #endregion

}
