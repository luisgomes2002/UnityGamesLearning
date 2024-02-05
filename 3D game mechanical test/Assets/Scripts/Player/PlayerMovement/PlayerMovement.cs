using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -9.18f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    private Animator animator;
    Vector3 velocity;
    bool isGrounded;
    int moveXParameter;
    int moveZParameter;
    int jumpAnimation;
    int meleeAttackOneHandedAnimation;
    float animationPlayTransition = 0.15f;

    void Start()
    {
        animator = GetComponent<Animator>();
        moveXParameter = Animator.StringToHash("MoveX");
        moveZParameter = Animator.StringToHash("MoveZ");
        jumpAnimation = Animator.StringToHash("Jump");
        meleeAttackOneHandedAnimation = Animator.StringToHash("MeleeAttack_OneHanded");
    }

    void Update()
    {
        OnMove();
        OnJump();
        MeleeAttackOneHanded();
    }

    void MeleeAttackOneHanded()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.Play(meleeAttackOneHandedAnimation);
        }
    }

    void OnMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputX + transform.forward * inputY;

        controller.Move(move * speed * Time.deltaTime);

        animator.SetFloat(moveXParameter, inputX);
        animator.SetFloat(moveZParameter, inputY);
    }

    void OnJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            animator.CrossFade(jumpAnimation, animationPlayTransition);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}