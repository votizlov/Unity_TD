using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : PathfindingObject
{

    // Start is called before the first frame update
    void Start()
    {
        gameProxy.guards.Add(gameObject);
        target = gameObject.transform;
    }

    private void OnDestroy()
    {
        gameProxy.guards.Remove(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = aggroRange;
        GameObject closestObject = null;
        foreach (var enemy in gameProxy.enemies)
        {
            if (minDistance == -1 || Vector3.Distance(enemy.transform.position, transform.position) <= minDistance)
            {
                minDistance = Vector3.Distance(enemy.transform.position, transform.position);
                closestObject = enemy;
            }
        }

        if (minDistance < aggroRange)
        {
            target = closestObject.transform;
            attack.AttackTarget(closestObject);
        }
        else
        {
            target = gameObject.transform;
        }
        SetDestination(target);
    }
}
