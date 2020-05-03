using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    void Start()
    {
        print(GameManager.gameManager.getPlayerPos());
        print(GameManager.gameManager.getPlayerRot());

        player.transform.position = GameManager.gameManager.getPlayerPos();
        player.transform.rotation = GameManager.gameManager.getPlayerRot();
    }

}
