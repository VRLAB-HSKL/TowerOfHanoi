using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToH : MonoBehaviour
{
    private Vector3 roomScaleVector;
    public Vector3[] poleApositions;
    public Vector3[] poleBpositions;
    public Vector3[] poleCpositions;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        roomScaleVector = new Vector3(10f, 0, 10f);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getPoleAposition(int i)
    {
        return poleApositions[i];
    }

    public Vector3 getPoleBposition(int i)
    {
        return poleBpositions[i];
    }

    public Vector3 getPoleCposition(int i)
    {
        return poleCpositions[i];
    }

    public void getSpecificPoleBPositions()
    {
        Debug.Log("Counter" + count);
        count++;
        /**
        Debug.Log("Counter: " + count);
        Vector3 newCoords;
        if (other.gameObject.name == "Disc3" || other.gameObject.name == "Disc2" || other.gameObject.name == "Disc1")
        {
            switch (count)
            {
                case 0:
                    newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(0);
                    newCoords.x = newCoords.x + 10f;
                    newCoords.z = newCoords.z + 10f;
                    other.gameObject.transform.position = newCoords;
                    Debug.Log(newCoords);
                    break;
                case 1:
                    newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(1);
                    newCoords.x = newCoords.x + 10f;
                    newCoords.z = newCoords.z + 10f;
                    other.gameObject.transform.position = newCoords;
                    break;
                case 2:
                    newCoords = GameObject.Find("ToH").GetComponent<GameToH>().getPoleBposition(2);
                    newCoords.x = newCoords.x + 10f;
                    newCoords.z = newCoords.z + 10f;
                    other.gameObject.transform.position = newCoords;
                    break;
            }
            count++;
        }
    **/
    }
}
