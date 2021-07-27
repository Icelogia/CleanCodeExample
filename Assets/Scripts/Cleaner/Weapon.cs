using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _dmg = 0.0f;

    public float DealDmg()
    {
        return _dmg;
    }
}
