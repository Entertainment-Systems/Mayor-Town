using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    // Start is called before the first frame update
    public  void loadscene()
    {
        PlayerPrefs.SetInt("deaths", 0);
        if(GameManager.gameManager)GameManager.gameManager.teleported = false;
        SceneManager.LoadScene("MainLevel");
    }
}
