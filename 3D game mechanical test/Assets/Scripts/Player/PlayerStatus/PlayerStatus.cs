using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamageAble
{

    public float playerMaxHealth = 100f;
    public float playerCurrentHealth = 50f;
    public float playerMana = 30f;
    public float playerSpeed = 5f;
    public float playerJumpHeight = 3f;
    public float playerStrength = 10f;
    public float playerAbilityPower = 10f;
    private bool playerIsAlive = true;
    Animator animator;
    int isAliveAnimator;
    public float health { get => playerCurrentHealth; set => playerCurrentHealth = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
        isAliveAnimator = Animator.StringToHash("isAlive");
    }

    void Update()
    {
        Death(playerCurrentHealth);
    }

    public void GetDamage(float damage)
    {
        playerCurrentHealth -= damage;
        Debug.Log("Player Current Health " + playerCurrentHealth);
    }

    private void Death(float health)
    {
        if (health <= 0)
        {
            playerIsAlive = false;
            animator.SetBool(isAliveAnimator, playerIsAlive);
        }
    }
}
