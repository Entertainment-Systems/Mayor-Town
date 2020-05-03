using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMovemen2 : MonoBehaviour
{
    // Start is called before the first frame update
     float scrollSpeed = 0.1f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));
        
    }
}
