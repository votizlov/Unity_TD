using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<DamagableObject>()!=null)
            other.gameObject.GetComponent<DamagableObject>().ReduceHealth(damage);
            
        Destroy(gameObject);
    }
}
