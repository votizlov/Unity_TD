using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    public float health;

    public void ReduceHealth(float damage)
    {
        health -= damage;
        if(health<=0)
            Destroy(gameObject);
    }
}
