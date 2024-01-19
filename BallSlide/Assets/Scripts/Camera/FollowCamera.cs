using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
