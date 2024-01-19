using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] int winScore;
    int playerScore = 0;

    void Awake()
    {
        winScore = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            col.gameObject.SetActive(false);
            playerScore++;

            if (playerScore >= winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}
