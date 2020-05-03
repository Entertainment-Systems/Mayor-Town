using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTheShadowRealmJimbo : MonoBehaviour
{

    public GameObject spawn;
    private bool assending = false;
    
    private void Update() {
        if(assending == true) {
          
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);

        print("waited");
        SceneManager.LoadScene("MayorTown");
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "enemy") {
            print("waiting begon");
            spawn.GetComponent<SpriteRenderer>().enabled = true;
            
            PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths")+1);
            StartCoroutine(Reset());
        }
        
    }
}
