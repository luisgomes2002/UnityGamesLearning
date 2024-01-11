using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    public float enemyHp;
    public float enemyMana;
    public float enemySpeed;
    public float enemyDamegeAd;
    public float enemyDamegeAp;

    public Enemies(float enemyHp, float enemyMana, float enemySpeed, float enemyDamegeAd, float enemyDamegeAp)
    {
        this.enemyHp = enemyHp;
        this.enemyMana = enemyMana;
        this.enemySpeed = enemySpeed;
        this.enemyDamegeAd = enemyDamegeAd;
        this.enemyDamegeAp = enemyDamegeAp;
    }
}
