using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float rotationSpeed = 10f;
    CharacterController controller;
    PlayerStatus playerStatus;
    Animator animator;
    Vector3 velocity;

    //Animator Parameter
    int moveXParameter;
    int moveZParameter;
    int jumpParameter;
    int fallParameter;

    //Animator Boll
    bool isJumping = false;
    bool isFalling = false;
    bool isGrounded = false;
    bool isMoving = false;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
        playerStatus = GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
        moveXParameter = Animator.StringToHash("MoveX");
        moveZParameter = Animator.StringToHash("MoveZ");
        jumpParameter = Animator.StringToHash("isJumping");
        fallParameter = Animator.StringToHash("isFalling");
    }

    void Update()
    {
        OnCollision();
        OnMove();
        OnJump();
        OnFall();
    }

    void OnCollision()
    {
        if (controller.collisionFlags == CollisionFlags.Below)
        {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
        }
        else
        {
            animator.SetBool("isGrounded", isGrounded);
        }
    }

    void OnMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX != 0 || inputY != 0)
        {
            isMoving = true;
            animator.SetBool("isMoving", isMoving);
            Vector3 move = transform.right * inputX + transform.forward * inputY;

            controller.Move(move * playerStatus.playerSpeed * Time.deltaTime);

            animator.SetFloat(moveXParameter, inputX);
            animator.SetFloat(moveZParameter, inputY);

            //Camera
            Vector3 lookDirection = mainCamera.transform.forward;
            lookDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {

            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }
    }

    void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            isGrounded = false;
            velocity.y = Mathf.Sqrt(playerStatus.playerJumpHeight * -3f * Physics.gravity.y);
            animator.SetBool(jumpParameter, isJumping);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void OnFall()
    {
        if (velocity.y < -0.1f)
        {
            isJumping = false;
            isFalling = true;
            animator.SetBool(jumpParameter, isJumping);
            animator.SetBool(fallParameter, isFalling);
        }

        if (isGrounded)
        {
            isFalling = false;
            isGrounded = true;
            animator.SetBool(fallParameter, isFalling);
        }
    }
}