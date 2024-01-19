using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float playerJumpForce = 5f;
    [SerializeField] int playerScore = 0;
    Rigidbody2D playerRb;
    Vector2 moveInput;
    Animator playerAnimator;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        // Debug.Log(playerMove);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, playerRb.velocity.y);
        playerRb.velocity = playerVelocity;

        bool playerHasSpeedPositive = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasSpeedPositive);
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            playerRb.velocity += new Vector2(0f, playerJumpForce);
        }
    }

    void FlipSprite()
    {
        bool playerHasSpeedPositive = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;

        if (playerHasSpeedPositive)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRb.velocity.x), 1f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            playerScore++;
            Destroy(col.gameObject);
        }
    }
}
