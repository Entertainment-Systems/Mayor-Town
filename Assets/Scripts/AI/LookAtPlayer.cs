using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public bool creeper = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (creeper)
        {
            Vector3 toPlayer = (this.transform.position - player.transform.position).normalized;
            if (Vector3.Angle(toPlayer, player.transform.forward) > 90)
            {
                transform.LookAt(player.transform);
            }
        }
        else
        {
            transform.LookAt(player.transform);
        }
    }
}