using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPoleC : MonoBehaviour
{
    Renderer rend;
    private int count;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        count = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.gameObject.name.ToString());
        rend.material.color = Color.green;
        if (other.gameObject.name == "Disc3" || other.gameObject.name == "Disc2" || other.gameObject.name == "Disc1")
        {
            Destroy(other.gameObject.GetComponent<BasicGrabbable>());
            other.gameObject.transform.position = discState(other.gameObject.name);
            other.gameObject.AddComponent<BasicGrabbable>();
            count++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /**
        if (other.gameObject.name == "Disc3")
        {
            Vector3 newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleCposition(2);
            newCoords.x = newCoords.x + 10f;
            newCoords.z = newCoords.z + 10f;
            other.gameObject.transform.position = newCoords;
        }
        if (other.gameObject.name == "Disc2")
        {
            Vector3 newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleCposition(1);
            newCoords.x = newCoords.x + 10f;
            newCoords.z = newCoords.z + 10f;
            other.gameObject.transform.position = newCoords;
        }
        if (other.gameObject.name == "Disc1")
        {
            Vector3 newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleCposition(0);
            newCoords.x = newCoords.x + 10f;
            newCoords.z = newCoords.z + 10f;
            other.gameObject.transform.position = newCoords;
        }
        //other.gameObject.transform.position = new Vector3(10f, 1.0348f, 10.5f);
    **/
    }

    private void OnTriggerExit(Collider other)
    {
        rend.material.color = Color.white;
        if (other.gameObject.name == "Disc3" || other.gameObject.name == "Disc2" || other.gameObject.name == "Disc1")
        {
            count--;
        }
    }

    private Vector3 discState(string name)
    {
        Vector3 newCoords = new Vector3(0, 0, 0);
        switch (count)
        {
            case 0:
                newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleCposition(0);
                newCoords.x = newCoords.x + 10f;
                newCoords.z = newCoords.z + 10f;
                //other.gameObject.transform.position = newCoords;
                Debug.Log(newCoords);
                break;
            case 1:
                newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleCposition(1);
                newCoords.x = newCoords.x + 10f;
                newCoords.z = newCoords.z + 10f;
                //other.gameObject.transform.position = newCoords;
                break;
            case 2:
                newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleCposition(2);
                newCoords.x = newCoords.x + 10f;
                newCoords.z = newCoords.z + 10f;
                //other.gameObject.transform.position = newCoords;
                break;
        }

        return newCoords;
    }
}
