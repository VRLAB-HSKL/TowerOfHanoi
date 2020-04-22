using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGameController : MonoBehaviour
{
    public bool play;
    public bool isPaused;
    public GameObject[] disks;
    Vector3 waypointA;
    Vector3 waypointB;
    Vector3 waypointC;
    ParticleSystem fireWorks;
    public GameObject[] diskSeq;
    public Vector3[] posASeq;
    public Vector3[] posBSeq;
    int i = -1;
    public int n = 6;
    public float speed = 1;
    int state = 0;
    
    // Use this for initialization
    void Start()
    {
        play = false;
        isPaused = false;
        waypointA = GameObject.Find("wayPoint A").transform.position;
        waypointB = GameObject.Find("wayPoint B").transform.position;
        waypointC = GameObject.Find("wayPoint C").transform.position;
        //fireWorks = GameObject.Find("Fireworks").GetComponent<ParticleSystem>();
        diskSeq = new GameObject[150];
        posASeq = new Vector3[150];
        posBSeq = new Vector3[150];
        hanoi(n, waypointA, waypointC, waypointB);
        Debug.Log("IN ARRAYS===>");
        for (int i = 0; i < Mathf.Pow(2, n) - 1; i++)
        {
            Debug.Log("Move disk " + diskSeq[i] + " from " + posASeq[i] + " to " + posBSeq[i]);
        }
        
    }

    // Update is called once per frame

    void Update()
    {
        if (state == 1)
        {
            //fireWorks.Play();
            state++;
        }
    }

    IEnumerator moveAll()
    {
        for (int i = 0; i < Mathf.Pow(2, n) - 1; i++)
        {
            Debug.Log(i);
            while (isPaused)
            {
                yield return new WaitForSeconds(0.2f);
                //yield return StartCoroutine(setPauseEnable());
            }
            yield return StartCoroutine(move(diskSeq[i], posASeq[i], posBSeq[i]));
            if (i == Mathf.Pow(2, n) - 3)
            state++;
        }
    }

    IEnumerator setPauseEnable()
    {
        yield return new WaitWhile(() => isPaused == false);
    }

    public void setPlayStatus()
    {
       if (isPaused == false)
       {
           StartCoroutine(moveAll());
       }
       else
       {
            Debug.Log("before:"+ isPaused);
            isPaused = false;
            Debug.Log("after: " + isPaused);
       }
        
    }

    public void setStopStatus()
    {
        isPaused = true;
    }

    void hanoi(int n, Vector3 from, Vector3 to, Vector3 aux)
    {
        if (n == 1)
        {
            addToSequence(disks[0], from, to);
            return;
        }
        hanoi(n - 1, from, aux, to);
        addToSequence(disks[n - 1], from, to);
        hanoi(n - 1, aux, to, from);
    }

    void addToSequence(GameObject disk, Vector3 from, Vector3 to)
    {
        i++;
        diskSeq[i] = disk;
        posASeq[i].Set(from.x, from.y, from.z);
        posBSeq[i].Set(to.x, to.y, to.z);
    }


    IEnumerator move(GameObject disk, Vector3 posA, Vector3 posB)
    {
        iTween.MoveTo(disk, posA, 2 / speed);
        yield return new WaitForSeconds(2 / speed);
        iTween.MoveTo(disk, posB, 1 / speed);
        yield return new WaitForSeconds(1 / speed);

        RaycastHit hit;
        if (Physics.Raycast(posB + Vector3.down * 2, Vector3.down, out hit, 6))
        {
            iTween.MoveTo(disk, hit.point + Vector3.up * .3f, 2 / speed);
            yield return new WaitForSeconds(2 / speed);
        }
    }

}
