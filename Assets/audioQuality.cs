using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioQuality : MonoBehaviour
{
    private AudioSource audioS;
    private AudioDistortionFilter audioDistortionFilter;

    [Range(0.0f, 1.0f)]
    public float audioDistortion;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioDistortionFilter = GetComponent<AudioDistortionFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        audioDistortionFilter.distortionLevel = audioDistortion;
    }
}
