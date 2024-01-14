using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public int playerHp;
    public float playerSpeed;
    public int dashForce;
    public int jumpForce;

    void Start()
    {

    }

    void Update()
    {
        Die();
    }

    void Die()
    {
        if (transform.position.y <= -5f)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
