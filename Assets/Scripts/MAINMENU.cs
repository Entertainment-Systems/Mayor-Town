using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    // Start is called before the first frame update
    public  void loadscene()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
