using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStatus playerStatus;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    Animator animator;
    float gravity = -9.18f;
    Vector3 velocity;
    bool isGrounded;
    int moveXParameter;
    int moveZParameter;
    int jumpAnimation;
    int fallAnimation;
    float animationPlayTransition = 0.15f;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
        moveXParameter = Animator.StringToHash("MoveX");
        moveZParameter = Animator.StringToHash("MoveZ");
        jumpAnimation = Animator.StringToHash("Jump");
        fallAnimation = Animator.StringToHash("Y");

    }

    void Update()
    {
        OnMove();
        OnJump();

        float PlayerYPosition = transform.position.y;
        if (PlayerYPosition > 0.1f)
        {
            animator.SetFloat(fallAnimation, PlayerYPosition);
        }
    }

    void OnMove()
    {
        isGrounded = controller.collisionFlags == CollisionFlags.Below;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            playerStatus.playerSpeed = 200f;
        }
        else
        {
            playerStatus.playerSpeed = 5f;
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputX + transform.forward * inputY;

        controller.Move(move * playerStatus.playerSpeed * Time.deltaTime);

        animator.SetFloat(moveXParameter, inputX);
        animator.SetFloat(moveZParameter, inputY);
    }

    void OnJump()
    {
        isGrounded = controller.collisionFlags == CollisionFlags.Below;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(playerStatus.playerJumpHeight * -3f * gravity);
            animator.CrossFade(jumpAnimation, animationPlayTransition);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}