using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseMagic : MonoBehaviour
{
    PlayerStatus playerStatus;
    [SerializeField] public float healAmountPerSecond = 3.2f;
    [SerializeField] ParticleSystem healingCircle = null;
    bool isHealing = false;
    float timer = 0f;
    readonly float duration = 4f;
    //mana necessaria para usar a magia

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        UseMagic();
    }

    void UseMagic()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isHealing && playerStatus.playerMana >= 5.7f)
        {
            Debug.Log("Magia de cura começou.");
            isHealing = true;
            playerStatus.playerMana -= 5.7f;
            healingCircle.Play();

        }

        if (isHealing)
        {
            timer += Time.deltaTime;
            playerStatus.playerCurrentHealth += healAmountPerSecond * Time.deltaTime;
            Debug.Log("Cura: " + playerStatus.playerCurrentHealth.ToString("F2"));

            if (playerStatus.playerCurrentHealth > playerStatus.playerMaxHealth)
            {
                playerStatus.playerCurrentHealth = playerStatus.playerMaxHealth;
            }

            if (timer >= duration)
            {
                isHealing = false;
                timer = 0f;
                healingCircle.Stop();
                Debug.Log("Magia de cura terminou.");
            }
        }


    }
}
