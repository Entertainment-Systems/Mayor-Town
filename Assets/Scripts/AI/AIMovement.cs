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
    

    [Header("Scanner")]
    Ray playerFinder;
    RaycastHit playerFound;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = aiStates.patrolling;
        transform.position = points[0].transform.position;
        nextPoint = 1;
        destination = points[nextPoint];
    }

    // Update is called once per frame
    void Update()
    {
        toggleStateBools();
        scanForPlayer();

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
    }

    void scanForPlayer()
    {
        playerFinder = new Ray(transform.position, agent.velocity);
        Debug.DrawRay(transform.position, agent.velocity, Color.white, 10f);
        /*playerFound = new RaycastHit();
        Physics.Raycast(transform.position, agent.velocity, out playerFound);*/

        
        //if (playerFound.collider.gameObject.tag == "Player")
        if (Physics.Raycast(transform.position, agent.velocity, out playerFound, 10f) && neverChase == false)
        {
            currentState = aiStates.chasing;
        }
    }

    void toggleStateBools()
    {
        if (alwaysChase) { neverChase = false; }
        if (neverChase) { alwaysChase = false; }
    }

    IEnumerator patrolBuffer(int buffer)
    {
        changeable = false;
        yield return new WaitForSecondsRealtime(buffer);
        changeable = true;
    }
}

