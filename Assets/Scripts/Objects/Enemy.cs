using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Attack rangeAttack = null;
    public GameProxy gameProxy;

    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        gameProxy.enemies.Add(gameObject);
    }

    private void OnDestroy()
    {
        gameProxy.enemies.Remove(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
