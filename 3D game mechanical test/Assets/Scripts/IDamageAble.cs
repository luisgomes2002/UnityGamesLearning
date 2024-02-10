using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageAble
{
    public float health { get; set; }
    public void GetDamage(float damage);
}
