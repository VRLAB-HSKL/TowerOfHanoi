﻿using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ColliderPoleB : MonoBehaviour
{
    Renderer rend;
    public List<GameObject> discPositions;
    private int count;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        count = 0;
        discPositions = new List<GameObject>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.gameObject.name.ToString());
        rend.material.color = Color.green;
        if (other.gameObject.tag == "Disc")
        {
            discPositions.Add(other.gameObject);
            Destroy(other.gameObject.GetComponent<BasicGrabbable>());
            other.gameObject.transform.position = GetDiscPositions();
            other.gameObject.AddComponent<BasicGrabbable>();
            count++;
            StartCoroutine(CheckGameState(other));
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        rend.material.color = Color.white;
        if (other.gameObject.tag == "Disc")
        {
            GameObject.Find("ToH").GetComponent<GameToH>().setOldDiscPosition(other.gameObject.transform.position);
            count--;
            discPositions.Remove(other.gameObject);
        }
            
    }

    IEnumerator CheckGameState(Collider other)
    {
        bool gameFlag = GameObject.Find("ToH").GetComponent<GameToH>().checkDiscPositions(discPositions);
        Debug.Log("GameFlag: " + gameFlag);
        if (!gameFlag)
        {
            other.gameObject.transform.position = GameObject.Find("ToH").GetComponent<GameToH>().getOldDiscPosition();
        }
        yield return new WaitForSeconds(.1f);
    }

    private Vector3 GetDiscPositions()
    {
        Vector3 newCoords = new Vector3(0,0,0);
        switch (count)
        {
            case 0: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(0); break;
            case 1: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(1); break;
            case 2: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(2); break;
            case 3: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(3); break;
            case 4: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(4); break;
            case 5: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(5); break;
            case 6: newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(6); break;
        }

        return newCoords;
    }
}
