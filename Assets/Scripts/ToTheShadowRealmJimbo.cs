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
        GameManager.gameManager.setPlayerPos(transform.position);
        GameManager.gameManager.setPlayerRot(transform.rotation);
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
        
        if (other.gameObject.tag == "mayor") {
            if(GameManager.gameManager.hasWon())
            {
                SceneManager.LoadScene("victory");
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("game over screen");
            }
        }

        if (other.gameObject.tag == "outofbounds") {
            print("oops");
            transform.position = new Vector3(162, 10000, 25);
        }
        
    }
}
