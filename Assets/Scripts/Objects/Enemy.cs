using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : PathfindingObject
{
    public int bounty;
    // Start is called before the first frame update
    void Start()
    {
        gameProxy.enemies.Add(gameObject);
    }

    private void OnDestroy()
    {
        gameProxy.AddScore(bounty);
        gameProxy.enemies.Remove(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = aggroRange;
        GameObject closestObject = null;
        foreach (var guard in gameProxy.guards)
        {
            if (minDistance < 0 || Vector3.Distance(guard.transform.position, transform.position) <= minDistance)
            {
                minDistance = Vector3.Distance(guard.transform.position, transform.position);
                closestObject = guard;
            }
        }

        if (minDistance < aggroRange)
        {
            target = closestObject.transform;
            attack.AttackTarget(closestObject);
        }
        else
        {
            target = gameProxy.baze.transform;
        }
        SetDestination(target);
    }
}
