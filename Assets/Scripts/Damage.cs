using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damageCount;

    public void OnCollisionEnter(Collision collision)
    {
        PlayerManager.SetDamage(_damageCount);
    }
}
