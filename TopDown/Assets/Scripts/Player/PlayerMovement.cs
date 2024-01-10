using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float climbSpeed = 2f;

    Rigidbody2D playerRb;
    Vector2 moveInput;
    CapsuleCollider2D playerCaps;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCaps = GetComponent<CapsuleCollider2D>();
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
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, moveInput.y * playerSpeed);
        playerRb.velocity = playerVelocity;
    }
    void ClimbLadder()
    {
        if (!playerCaps.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            return;
        }
        Vector2 climbVelocity = new Vector2(playerRb.velocity.x, Mathf.Abs(transform.position.y * climbSpeed));
        playerRb.velocity = climbVelocity;
    }
}
