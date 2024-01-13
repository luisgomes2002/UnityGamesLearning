using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{
    [SerializeField] GameObject inHand;
    [SerializeField] Transform handPosition;

    void Start()
    {

    }

    void Update()
    {
        AimAndShoot();
    }

    void AimAndShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(inHand, handPosition.position, Quaternion.identity);
        }

    }
}
