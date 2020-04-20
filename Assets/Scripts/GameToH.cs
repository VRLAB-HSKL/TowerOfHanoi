using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToH : MonoBehaviour
{
    private Vector3 roomScaleVector;
    public Vector3[] poleApositions;
    public Vector3[] poleBpositions;
    public Vector3[] poleCpositions;

    // Start is called before the first frame update
    void Start()
    {
        roomScaleVector = new Vector3(10f, 0, 10f);
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
}
