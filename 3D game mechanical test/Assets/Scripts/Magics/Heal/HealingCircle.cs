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
        Debug.Log("Cura: " + playerStatus.playerCurrentHealth.ToString("F2"));

        if (playerStatus.playerCurrentHealth > playerStatus.playerMaxHealth)
        {
            playerStatus.playerCurrentHealth = playerStatus.playerMaxHealth;
        }
    }
}
