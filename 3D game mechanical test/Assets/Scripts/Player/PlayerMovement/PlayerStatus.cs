using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float playerMaxHealth = 100f;
    public float playerCurrentHealth = 50f;
    public float playerMana = 30f;
    public float playerSpeed = 5f;
    public float playerJumpHeight = 3f;
    public float playerStrength = 10f;
    public float playerAbilityPower = 10f;
    public bool playerIsAlive = true;
    Animator animator;
    int isAliveAnimator;

    void Start()
    {
        animator = GetComponent<Animator>();
        isAliveAnimator = Animator.StringToHash("isAlive");
    }

    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            playerIsAlive = false;
            animator.SetBool(isAliveAnimator, playerIsAlive);
        }
    }
}
