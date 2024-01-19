using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float playerJumpForce = 5f;
    [SerializeField] float playerClimbingSpeed = 5f;
    [SerializeField] int playerScore = 0;
    float gravityScaleAtStart;
    Rigidbody2D playerRb;
    Vector2 moveInput;
    Animator playerAnimator;
    CapsuleCollider2D playerCapsuleCollider2D;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = playerRb.gravityScale;
    }

    void Update()
    {
        Run();
        FlipSprite();
        OnClimbing();
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

        bool playerHasSpeedPositive = Mathf.Abs(playerRb.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasSpeedPositive);
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
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

    void OnClimbing()
    {
        if (!playerCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            playerRb.gravityScale = gravityScaleAtStart;
            return;
        }

        Vector2 playerClimbingVelocity = new Vector2(playerRb.velocity.x, moveInput.y * playerClimbingSpeed);
        playerRb.velocity = playerClimbingVelocity;

        bool playerHasSpeedPositive = Mathf.Abs(playerRb.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("isClimbing", playerHasSpeedPositive);

        playerRb.gravityScale = 0f;

    }
}
