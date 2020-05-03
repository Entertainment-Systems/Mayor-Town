using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineAssigner : MonoBehaviour
{
    [SerializeField]
    AudioClip[] voiceLines;
    AudioSource audioSource;
    int number;
    IEnumerator playVoiceLine()
    {
        number = newVoiceLine(number);
        audioSource.clip = voiceLines[number];
        audioSource.Play();
        yield return new WaitForSecondsRealtime(6);
        StartCoroutine(playVoiceLine());
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(playVoiceLine());
    }

    int newVoiceLine(int num)
    {
        int newnum = num;
        
        while(newnum == num) newnum = Random.Range(0, voiceLines.Length - 1);

        return newnum;
    }


}
