using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlayer : MonoBehaviour
{
    public Transform resetPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("waiting begon");
        collision.transform.position = resetPosition.position;
      //  Time.timeScale = 0f;
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);

        print("waited");
    }
}
