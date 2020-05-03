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
        print("current position before edit: " + gameObject.transform.position);
        transform.position = new Vector3(points[6].transform.position.x, points[6].transform.position.y, points[6].transform.position.z);
        print("current position after edit: " + gameObject.transform.position);

    }

    private void Update()
    {
        print("current position each frame: " + gameObject.transform.position);

    }

}
