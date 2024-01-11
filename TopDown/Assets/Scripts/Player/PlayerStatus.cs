using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float playerHp = 20;
    [SerializeField] float playerMana = 20;
    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] public float playerClimbSpeed = 2f;
    public CapsuleCollider2D playerCaps;
    public Rigidbody2D playerRb;
    bool isAlive = true;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCaps = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Die();
    }

    void Die()
    {
        if (playerHp <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
        }
    }
}
