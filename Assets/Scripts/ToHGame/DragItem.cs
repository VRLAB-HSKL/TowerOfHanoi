﻿using System.Collections;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    private bool isOver;
    private bool up;
    private Vector3 startPosition;
    private GameObject item;

    void Awake()
    {
        item = this.gameObject;
        //startPosition = item.transform.position;
    }

    void OnMouseEnter()
    {
        isOver = true;
    }

    void OnMouseExit()
    {
        isOver = false;
    }

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

    void OnMouseUp()
    {
        up = true;
        // Vector3 pos = new Vector3(item.transform.position.x, 1.5f, item.transform.position.z);
        //item.transform.position = pos;
    }

    public void Reset()
    {
        //item.transform.position = startPosition;
    }

    void OnGUI()
    {
        if (isOver)
        {
            GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200, 20), "Left Click and drag to move");
        }
    }
}
