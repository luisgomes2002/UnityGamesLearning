using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueNormalSpell : SpellsDefault
{
    public Rigidbody2D blueSpellRb;

    public BlueNormalSpell(float damage, float value, float range, string type, string spellsName, float manaRequired)
        : base(damage, value, range, type, spellsName, manaRequired)
    {

    }

    void Start()
    {
        blueSpellRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        blueSpellRb.velocity = new Vector2(1f, 0f);
    }
}
