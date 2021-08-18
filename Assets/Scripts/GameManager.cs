using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private Vector3 playerPos = new Vector3(162,33,25);
    private Quaternion playerRot;
    bool collectedAll = false;
    internal bool teleported = false;

    private void Awake()
    {
        if(gameManager == null)
        {
            PlayerPrefs.SetInt("deaths", 0);
            gameManager = this;
        }
        else if(this != gameManager)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    public Vector3 getPlayerPos()
    {
        return playerPos;
    }

    public void setPlayerPos(Vector3 pos)
    {
        playerPos = pos;
    }

    public Quaternion getPlayerRot()
    {
        return playerRot;
    }

    public void setPlayerRot(Quaternion rot)
    {
        playerRot = rot;
    }

    public void win()
    {
        collectedAll = true;
    }

    public void lose()
    {
        collectedAll = false;
    }

    public bool hasWon()
    {
        return collectedAll;
    }

}
