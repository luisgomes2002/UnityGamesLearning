using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    float xInput;
    float yInput;
    PlayerStatus playerStatus;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        Impulse();
        Jump();
    }

    void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        playerRb.AddForce(xInput * playerStatus.playerSpeed, 0, yInput * playerStatus.playerSpeed);
    }

    void Impulse()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerRb.AddForce(xInput * playerStatus.dashForce, 0, yInput * playerStatus.dashForce);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            playerRb.AddForce(0, playerStatus.jumpForce, 0);
        }

    }
}
