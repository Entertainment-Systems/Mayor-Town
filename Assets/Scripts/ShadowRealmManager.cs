using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowRealmManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    float timerTillGoBack;

    void Start()
    {
        print(PlayerPrefs.GetInt("deaths"));
        timerTillGoBack = PlayerPrefs.GetInt("deaths");
        player.transform.position = GameManager.gameManager.getPlayerPos();
        player.transform.rotation = GameManager.gameManager.getPlayerRot();
    }

    void Update()
    {
        timerTillGoBack -= Time.deltaTime;
        if (timerTillGoBack < 0)
        {
            GameManager.gameManager.setPlayerPos(player.transform.position);
            GameManager.gameManager.setPlayerRot(player.transform.rotation);
            SceneManager.LoadScene("PostProccessing");
        }
    }
}
