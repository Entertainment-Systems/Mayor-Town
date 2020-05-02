using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineAssigner : MonoBehaviour
{
    [SerializeField]
    AudioClip[] voiceLines;
    AudioSource audioSource;

    IEnumerator playVoiceLine()
    {
        audioSource.clip = voiceLines[Random.Range(0, voiceLines.Length - 1)];
        audioSource.Play();
        yield return new WaitForSecondsRealtime(5);
        StartCoroutine(playVoiceLine());
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playVoiceLine());
    }



}
