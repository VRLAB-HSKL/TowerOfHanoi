using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the discs and pole control
/// </summary>
public class ColliderPoleB : MonoBehaviour
{

    #region Variables

    //Renderer for coloring the poles
    Renderer rend;

    //contains all disc objects that are currently on this pole
    public List<GameObject> discPositions;

    //count entered and leaving discs at pole b
    private int count;

    #endregion

    #region Unity standard Methods

    /// <summary>
    ///  init the starting attributes
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
    /// This method manages, checks and positions the incoming discs
    /// </summary>
    /// <param name="other"> collider pole b </param>
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
    /// This method manages the outgoing discs
    /// </summary>
    /// <param name="other"> collider pole b </param>
    private void OnTriggerExit(Collider other)
    {
        rend.material.color = Color.white;
        if (other.gameObject.tag == "Disc")
        {
            count--;
            discPositions.Remove(other.gameObject);
        }
            
    }

    #endregion

    #region Coroutine

    /// <summary>
    /// This coroutine delete the DragItem script from object if a disc entered the collider.
    /// </summary>
    /// <param name="other"> collider pole b </param>
    /// <returns>No wait actually needed => null </returns>
    IEnumerator DeleteDragItemSkript(Collider other)
    {
        Destroy(other.gameObject.GetComponent<DragItem>());
        
        yield return null;
    }

    /// <summary>
    /// After reposition the disc the DragItem script added again to the collider entered disc and
    /// allows the disc to drag again.
    /// </summary>
    /// <param name="other"> collider pole b</param>
    /// <returns> No wait actually needed => null </returns>
    IEnumerator AddDragItemSkript(Collider other)
    {
        other.gameObject.AddComponent<DragItem>();
        
        yield return null;
    }

    /// <summary>
    /// This coroutine checks if a disc that complies with the Tower of Hanoi rules and can be put on the stack.
    /// If so, the necessary disc position is used. If the disc cannot be placed in its current position or on top of a disc,
    /// it will be returned to its origin place.
    /// </summary>
    /// <param name="other"> collider pole b </param>
    /// <returns> Suspends the coroutine execution for the given amount of seconds using scaled time.</returns>
    IEnumerator CheckGameState(Collider other)
    {
        bool gameFlag = GameObject.Find("ToH").GetComponent<GameToH>().CheckDiscPositions(discPositions);
       
        if (!gameFlag)
        {
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
    /// This method represents the initially calculated positions of the discs
    /// </summary>
    /// <returns> the initial disc positions of a disc </returns>
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
