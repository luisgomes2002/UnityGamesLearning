using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int rotateSpeed;

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
