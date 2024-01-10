using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpSpeed = 8.3f;
    [SerializeField] float climbSpeed = 5f;

    Rigidbody2D playerRb;
    Vector2 moveInput;
    CapsuleCollider2D playerCaps;
    float gravityScaleAtStart;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCaps = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = playerRb.gravityScale;
    }

    void Update()
    {
        Run();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, playerRb.velocity.y);
        playerRb.velocity = playerVelocity;
    }
    void OnJump(InputValue value)
    {
        if (!playerCaps.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            playerRb.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    void ClimbLadder()
    {
        if (!playerCaps.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            playerRb.gravityScale = gravityScaleAtStart;
            return;
        }
        Vector2 climbVelocity = new Vector2(playerRb.velocity.x, moveInput.y * climbSpeed);
        playerRb.velocity = climbVelocity;
        playerRb.gravityScale = 0;
    }
}
