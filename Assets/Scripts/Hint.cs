using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hint : MonoBehaviour
{
    [SerializeField]
    float timer = 5;
    TextMeshProUGUI text;
    [SerializeField]
    bool mayor = false;

    private void Start()
    {
        if (!GameManager.gameManager.teleported) Destroy(gameObject);
        text = GetComponent<TextMeshProUGUI>();
        //check if in mayor realm
        if(mayor)
        {
            if(GameManager.gameManager.hasWon())
            {
                text.color = Color.green;
                text.text = "(I have enough coins)";
            }
            else{
                text.color = Color.red;
                text.text = "(I need more coins)";
            }
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer<1)
        {
            text.alpha = timer;
        }
        if (timer < 0) Destroy(gameObject);
    }
}
