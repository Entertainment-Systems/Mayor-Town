using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndQuitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(quit());
    }

    IEnumerator quit()
    {
        yield return new WaitForSecondsRealtime(42);
        Application.Quit(0);
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
