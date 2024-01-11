using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellsDefault : MonoBehaviour
{
    public float damage;
    public float value;
    public float range;
    public string type;
    public string spellsName;
    public float manaRequired;

    public SpellsDefault(float damage, float value, float range, string type, string spellsName, float manaRequired)
    {
        this.damage = damage;
        this.value = value;
        this.range = range;
        this.type = type;
        this.spellsName = spellsName;
        this.manaRequired = manaRequired;
    }
}
