using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultMagic : MonoBehaviour
{
    [SerializeField] protected string magicType;
    [SerializeField] protected string magicName;
    [SerializeField] protected float magicDamage;
    [SerializeField] protected float magicRange;
    [SerializeField] protected float magicDuration;
    [SerializeField] protected float magicCost;

    public string MagicType => magicType;
    // public string MagicType { get { return magicType; } }
    public string MagicName => magicName;
    public float MagicDamage => magicDamage;
    public float MagicRange => magicRange;
    public float MagicDuration => magicDuration;
    public float MagicCost => magicCost;

    public virtual void ShowMagicSpecs()
    {
        Debug.Log("Type: " + magicType + " Name: " + magicName + " Damege: " + magicDamage + " Range: " + magicRange + " Duration: " + magicDuration + " Cost: " + magicCost);
    }

    public virtual void UseMagic(PlayerStatus playerStatus)
    {

    }
}