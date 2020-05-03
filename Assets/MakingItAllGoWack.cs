using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MakingItAllGoWack : MonoBehaviour
{
        PostProcessVolume m_Volume;
        LensDistortion lens;
    // Start is called before the first frame update
    void Start()
    {
        lens.enabled.Override(true);
                m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, lens);
    }

    // Update is called once per frame
    void Update()
    {
        lens.intensity.Override(Mathf.Sin(Time.realtimeSinceStartup)); 
    }
}
