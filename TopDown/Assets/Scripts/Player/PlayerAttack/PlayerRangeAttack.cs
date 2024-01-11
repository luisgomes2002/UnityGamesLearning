using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRangeAttack : MonoBehaviour
{
    [SerializeField] GameObject spell;
    [SerializeField] Transform hand;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(spell, hand.position, transform.rotation);
        }
    }

    // void RangeAttack(InputValue value)
    // {
    //     Debug.Log("Fire");
    //     Instantiate(blueNormalSpell.spellGameObject, hand.position, transform.rotation);
    // }
}
