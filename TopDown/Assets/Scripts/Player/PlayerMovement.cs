using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerStatus playerStatus;
    Vector2 moveInput;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
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
        Vector2 playerVelocity = new Vector2(moveInput.x * playerStatus.playerSpeed, moveInput.y * playerStatus.playerSpeed);
        playerStatus.playerRb.velocity = playerVelocity;
    }
    void ClimbLadder()
    {
        if (!playerStatus.playerCaps.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            return;
        }
        Vector2 climbVelocity = new Vector2(playerStatus.playerRb.velocity.x, Mathf.Abs(transform.position.y * playerStatus.playerClimbSpeed));
        playerStatus.playerRb.velocity = climbVelocity;
    }
}
