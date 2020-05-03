using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseScreen;
    public GameObject gameOverlay;
    public GameObject scoreCounter;
    public characterController cc;
    public camMouseLook cml;

    void Start()
    {
        cc = GameObject.Find("Player").GetComponent<characterController>();
        cml = cc.gameObject.transform.GetChild(0).GetComponent<camMouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.GetComponent<TextMeshProUGUI>().text = "(Score: " + PlayerPrefs.GetInt("collected") + ")";

        if (Input.GetKeyDown(KeyCode.Escape)) { paused = !paused; }

        pauseToggle();
    }

    void pauseToggle()
    {
        if (paused)
        {
            Cursor.visible = true;
            gameOverlay.SetActive(false);
            cc.lockCursor = false;
            //cc.enabled = false;
            cml.enabled = false;
            pauseScreen.SetActive(true);
            //Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            gameOverlay.SetActive(true);
            //cc.enabled = true;
            cc.lockCursor = true;
            cml.enabled = true;
            pauseScreen.SetActive(false);
        }
    }

    public void resume() { paused = false; }
}
