using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] points;

    void Awake()
    {
        //gameObject.transform.position = points[Random.Range(0, points.Length - 1)].transform.position;       
        transform.position = new Vector3(points[6].transform.position.x, points[6].transform.position.y, points[6].transform.position.z);

    }

    private void Update()
    {


    }

}
