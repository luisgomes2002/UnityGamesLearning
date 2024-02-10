using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseAttack : MonoBehaviour
{
    private Animator animator;
    int meleeAttackOneHandedAnimation;

    void Start()
    {
        animator = GetComponent<Animator>();

        meleeAttackOneHandedAnimation = Animator.StringToHash("MeleeAttack_OneHanded");
    }

    void Update()
    {
        MeleeAttackOneHanded();
    }

    void MeleeAttackOneHanded()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play(meleeAttackOneHandedAnimation);

        }
    }



}
