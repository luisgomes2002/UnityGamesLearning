using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueNormalSpell : SpellsDefault
{

    void Start()
    {
        spellRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        spellRb.velocity = new Vector2(spellSpeed, 0f);
    }
}
