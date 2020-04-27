using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscPositioning : MonoBehaviour
{

    public Vector3[] disc3positions; 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        disc3positions = new Vector3[7];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDiscPostions(Vector3 _discPosition, string name)
    {
        switch(name)
        {
            case "Disc1": disc3positions[0] = _discPosition; break;
            case "Disc2": disc3positions[1] = _discPosition; break;
            case "Disc3": disc3positions[2] = _discPosition; break;
            case "Disc4": disc3positions[3] = _discPosition; break;
            case "Disc5": disc3positions[4] = _discPosition; break;
            case "Disc6": disc3positions[5] = _discPosition; break;
            case "Disc7": disc3positions[6] = _discPosition; break;

        }
    }

    public Vector3 getPositions(string name)
    {
        int count = 0; 
        switch (name)
        {
            case "Disc1": count = 0; break;
            case "Disc2": count = 1; break;
            case "Disc3": count = 2; break;
            case "Disc4": count = 3; break;
            case "Disc5": count = 4; break;
            case "Disc6": count = 5; break;
            case "Disc7": count = 6; break;

        }

        return disc3positions[count];
    }
}
