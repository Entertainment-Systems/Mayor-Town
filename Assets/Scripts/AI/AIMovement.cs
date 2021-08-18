using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [Header ("States")]
    public aiStates currentState;
    public enum aiStates { patrolling, chasing };
    public bool alwaysChase;
    public bool neverChase;

    [Header("NavMesh")]
    public NavMeshAgent agent;
    public float distanceFromTarget;

    [Header("Patrolling")]
    public GameObject[] points;
    public int nextPoint;
    public GameObject destination;
    public bool changeable = true;
    public int routeChangeBuffer;

    [Header("Chaser")]
    public bool seesPlayer;


    [Header("Scanner")]
    public int playerItemsFound;
    public int searchThreshold = 5;
    public int chaseThreshhold = 10;
    public bool lookForPlayer = false;
    Ray playerFinder;
    RaycastHit playerFound;
    private AudioDistortionFilter audioDistortionFilter;

    // Start is called before the first frame update
    void Start()
    {
        audioDistortionFilter = GetComponent<AudioDistortionFilter>();
        agent = GetComponent<NavMeshAgent>();
        currentState = aiStates.patrolling;
        transform.position = points[0].transform.position;
        nextPoint = 1;
        destination = points[nextPoint];
    }

    // Update is called once per frame
    void Update()
    {
        playerItemsFound = PlayerPrefs.GetInt("collected");
        
        if (playerItemsFound >= searchThreshold) { lookForPlayer = true; }
        if (playerItemsFound >= chaseThreshhold) { alwaysChase = true; lookForPlayer = false; }

        if (lookForPlayer) { scanForPlayer(); }

        determineState();

        distanceFromTarget = Vector3.Distance(destination.transform.position, transform.position);
        switch (currentState)
        {
            case aiStates.patrolling:
                destination = points[nextPoint];
                if (distanceFromTarget > 2) { break; }
                else { 
                    if (changeable == true) {
                        StartCoroutine(patrolBuffer(routeChangeBuffer));
                        if (nextPoint == points.Length - 1)
                        {
                            nextPoint = 0;
                        }
                        else { nextPoint++; } 
                    } 
                }
                break;

            case aiStates.chasing:
                destination = GameObject.Find("Player");
                break;
        }
        agent.SetDestination(destination.transform.position);

        audioDistortionFilter.distortionLevel = playerItemsFound/16f;
    }

    void scanForPlayer()
    {
        playerFinder = new Ray(transform.position, agent.velocity);
        Debug.DrawRay(transform.position, agent.velocity, Color.white, 10f);
        /*playerFound = new RaycastHit();
        Physics.Raycast(transform.position, agent.velocity, out playerFound);*/

        seesPlayer = Physics.Raycast(transform.position, agent.velocity, out playerFound, 10f);

        //if (playerFound.collider.gameObject.tag == "Player")
        /*if (Physics.Raycast(transform.position, agent.velocity, out playerFound, 10f) && neverChase == false)
        {
            currentState = aiStates.chasing;
        }*/
    }

    void determineState()
    {
        if(alwaysChase) { currentState = aiStates.chasing; }
        else if(neverChase) { currentState = aiStates.patrolling; }
        else if(seesPlayer) { currentState = aiStates.chasing; }
        else { currentState = aiStates.patrolling; }
    }

    IEnumerator patrolBuffer(int buffer)
    {
        changeable = false;
        yield return new WaitForSecondsRealtime(buffer);
        changeable = true;
    }
}

