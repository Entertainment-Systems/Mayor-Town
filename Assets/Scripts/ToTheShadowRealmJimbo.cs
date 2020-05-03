using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class ToTheShadowRealmJimbo : MonoBehaviour
{

    public GameObject pngPopUp;
    public GameObject cameraAffect;
    private bool assending = false;
    
    private void Update() {
        if(assending == true) {
          
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        pngPopUp.GetComponent<SpriteRenderer>().enabled = false;
        cameraAffect.GetComponent<PostProcessVolume>().enabled = false;
        print("waited");
        SceneManager.LoadScene("MayorTown");
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "enemy") {
            print("waiting begon");
            pngPopUp.GetComponent<SpriteRenderer>().enabled = true;
            cameraAffect.GetComponent<PostProcessVolume>().enabled = true;
            
            PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths")+1);
            StartCoroutine(Reset());
        }
        
    }
}
