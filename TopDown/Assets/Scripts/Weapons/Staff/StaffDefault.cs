using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class StaffDefault : MonoBehaviour
{
    public GameObject spellSlot;
    public float staffDamage;
    protected Rigidbody2D staffRb;

    public void StaffAttack()
    {
        Instantiate(spellSlot, staffRb.position, Quaternion.identity);
    }


}
