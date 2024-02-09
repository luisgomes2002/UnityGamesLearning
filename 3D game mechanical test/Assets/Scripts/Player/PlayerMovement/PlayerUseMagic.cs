using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseMagic : MonoBehaviour
{
    PlayerStatus playerStatus;
    [SerializeField] Transform magicSpawnPoint;
    [SerializeField] ParticleSystem magicParticleSystem;
    [SerializeField] GameObject magicSlot1;
    DefaultMagic magic;
    bool isCasting = false;
    float timer = 0f;

    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
        magic = magicSlot1.GetComponent<DefaultMagic>();
        magicParticleSystem = magicSlot1.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isCasting && playerStatus.playerMana >= magic.MagicCost)
        {
            Debug.Log("Magia de cura começou.");

            isCasting = true;
            playerStatus.playerMana -= magic.MagicCost;
            magicParticleSystem.Play();
            Instantiate(magicParticleSystem, magicSpawnPoint.position, Quaternion.identity);
        }

        if (isCasting)
        {
            timer += Time.deltaTime;
            magic.UseMagic(playerStatus);

            if (timer >= magic.MagicDuration)
            {
                isCasting = false;
                timer = 0f;
                magicParticleSystem.Stop();
                Debug.Log("Magia de cura terminou.");
            }
        }
    }
}
