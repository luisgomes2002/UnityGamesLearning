using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSlime : Enemies
{
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyDie();
        EnemyMovement();
    }

    //Slime Movement
    protected override void EnemyMovement()
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