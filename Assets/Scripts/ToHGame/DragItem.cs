using System.Collections;
using UnityEngine;

/// <summary>
/// This class has the task of following an object at the current mouse position.
/// In this specific case, this class is used to make it possible to drag and drop the Tower of Hanoi discs.
/// </summary>
public class DragItem : MonoBehaviour
{
    //actually not needed
    private bool isOver;
    
    // needed to stop following the actual mouse position
    private bool up;

    //start position of the GameObject - acutally not needed
    private Vector3 startPosition;
    
    // The GameObject to Drag
    private GameObject item;

    /// <summary>
    /// init the GameObject to Drag
    /// </summary>
    void Awake()
    {
        item = this.gameObject;
        //startPosition = item.transform.position;
    }

    /// <summary>
    /// Not needed now
    /// </summary>
    void OnMouseEnter()
    {
        isOver = true;
    }

    /// <summary>
    /// Not needed now
    /// </summary>
    void OnMouseExit()
    {
        isOver = false;
    }

    /// <summary>
    /// Drag the choosen Gameobject to the actual mouse position
    /// </summary>
    /// <returns> Wait for end of Frame </returns>
    IEnumerator OnMouseDown()
    {
        Debug.Log("This keyword: " + this.gameObject.name);
        up = false;
        while (up == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 pos = ray.origin + (ray.direction * 1f/**4.7f*/);
            item.transform.position = pos;
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Gameobject stoped following the actual mouse position
    /// </summary>
    void OnMouseUp()
    {
        up = true;
        // Vector3 pos = new Vector3(item.transform.position.x, 1.5f, item.transform.position.z);
        //item.transform.position = pos;
    }

    /// <summary>
    /// Not implemented Now
    /// </summary>
    public void Reset()
    {
        //item.transform.position = startPosition;
    }

    /// <summary>
    /// Shows Message on GUI
    /// </summary>
    void OnGUI()
    {
        if (isOver)
        {
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200, 20), "Left Click and drag to move");
        }
    }
}
