using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioQuality : MonoBehaviour
{
    private AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    //    audioS.audioQuality
    }
}
