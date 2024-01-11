using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2f;
    Rigidbody2D enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        OnMove();
    }

    void OnMove()
    {
        enemyRb.velocity = new Vector2(enemySpeed, 0f);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            enemySpeed = -enemySpeed;
            FlipEnemyFacing();
        }
    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(0.5f), 0.5f);
    }
}
