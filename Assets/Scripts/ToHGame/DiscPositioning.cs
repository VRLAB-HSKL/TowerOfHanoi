using UnityEngine;


/// <summary>
/// Capture all disc positions
/// </summary>
public class DiscPositioning : MonoBehaviour
{
    // contains all initial disc positions and the positions each disc after moving arround
    public Vector3[] discPositions; 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    /// <summary>
    /// init the array with max playable discs.
    /// </summary>
    private void Awake()
    {
        discPositions = new Vector3[7];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Contains all initial positions at pole a and all positions when the discs are moved.
    /// </summary>
    /// <param name="_discPosition"> position of disc as vector3 </param>
    /// <param name="name"> name of the disc which position has changed </param>
    public void setDiscPostions(Vector3 _discPosition, string name)
    {
        switch(name)
        {
            case "Disc1": discPositions[0] = _discPosition; break;
            case "Disc2": discPositions[1] = _discPosition; break;
            case "Disc3": discPositions[2] = _discPosition; break;
            case "Disc4": discPositions[3] = _discPosition; break;
            case "Disc5": discPositions[4] = _discPosition; break;
            case "Disc6": discPositions[5] = _discPosition; break;
            case "Disc7": discPositions[6] = _discPosition; break;

        }
    }

    /// <summary>
    /// this Method returns the old or current position of the disc based on the given name
    /// </summary>
    /// <param name="name"> disc name </param>
    /// <returns> old / current position of the disc based on the given name </returns>
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

        return discPositions[count];
    }
}
