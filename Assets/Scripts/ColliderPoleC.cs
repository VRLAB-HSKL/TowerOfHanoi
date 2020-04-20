using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPoleC : MonoBehaviour
{
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.gameObject.name.ToString());
        rend.material.color = Color.green;

    }

    private void OnTriggerStay(Collider other)
    {
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
    }

    private void OnTriggerExit(Collider other)
    {
        rend.material.color = Color.white;
    }
}
