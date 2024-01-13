using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellsDefault : MonoBehaviour
{
    public float spellDamage;
    public float spellValue;
    public float spellRange;
    public string spellType;
    public string spellName;
    public float spellManaRequired;
    public float spellSpeed;
    public float spellCastingTime;
    protected Rigidbody2D spellRb;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemies>().TakeDamage(spellDamage);
        }
        Destroy(gameObject);
    }
}