using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    public string enemyName;
    public string enemyType;
    public float enemyHp;
    public float enemyMana;
    public float enemySpeed;
    public float enemyDamageAd;
    public float enemyDamageAp;
    protected Rigidbody2D enemyRb;
    protected abstract void EnemyMovement();

    public virtual void BasicAttack()
    {
        Debug.Log("Basic attack");
    }

    public virtual void SpecialAttack()
    {
        Debug.Log("Special Attack");
    }

    public virtual void TakeDamage(float damage)
    {
        enemyHp -= damage;
        Debug.Log($"Name: {enemyName}, HP: {enemyHp}");
    }

    public virtual void EnemyDie()
    {
        if (enemyHp <= 0)
        {
            Debug.Log($"Enemy: {enemyName} eliminated!");
            Destroy(gameObject);
        }
    }

}
