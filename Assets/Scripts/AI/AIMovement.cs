using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [Header ("States")]
    public aiStates currentState;
    public enum aiStates { patrolling, chasing };

    [Header("NavMesh")]
    public NavMeshAgent agent;
    public float distanceFromTarget;

    [Header("Patrolling")]
    public GameObject[] patrolPoints;
    public int nextPoint;
    public GameObject destination;
    public bool changeable = true;
    public int routeChangeBuffer;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = aiStates.patrolling;
        transform.position = patrolPoints[0].transform.position;
        nextPoint = 1;
        destination = patrolPoints[nextPoint];
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromTarget = Vector3.Distance(destination.transform.position, transform.position);
        switch (currentState)
        {
            case aiStates.patrolling:
                destination = patrolPoints[nextPoint];
                if (distanceFromTarget > 2) { break; }
                else { 
                    if (changeable == true) {
                        StartCoroutine(patrolBuffer(routeChangeBuffer));
                        if (nextPoint == patrolPoints.Length - 1)
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

    IEnumerator patrolBuffer(int buffer)
    {
        changeable = false;
        yield return new WaitForSecondsRealtime(buffer);
        changeable = true;

    }
}

