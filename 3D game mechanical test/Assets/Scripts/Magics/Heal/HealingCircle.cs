using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : DefaultMagic
{
    public float healAmountPerSecond;

    void Start()
    {
        ShowMagicSpecs();
    }

    public override void UseMagic(PlayerStatus playerStatus)
    {
        playerStatus.playerCurrentHealth += healAmountPerSecond * Time.deltaTime;

        if (playerStatus.playerCurrentHealth > playerStatus.playerMaxHealth) playerStatus.playerCurrentHealth = playerStatus.playerMaxHealth;
    }
}
