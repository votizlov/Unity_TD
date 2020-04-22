using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Damagable"))
            other.gameObject.GetComponent<DamagableObject>().ReduceHealth(damage);
            
        GetComponent<PoolObject>().ReturnToPool ();
    }
}
