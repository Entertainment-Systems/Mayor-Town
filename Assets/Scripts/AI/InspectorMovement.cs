using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorMovement : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;


    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }
}
