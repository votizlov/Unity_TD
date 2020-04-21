using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootClosestTower : MonoBehaviour
{
    public AttackingObject attackingObject;

    public GameProxy gameProxy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = attackingObject.range;
        GameObject closestObject = null;
        foreach (var enemy in gameProxy.enemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) <= minDistance)
            {
                minDistance = Vector3.Distance(enemy.transform.position, transform.position);
                closestObject = enemy;
            }
        }

        if (minDistance < attackingObject.range)
        {
            transform.LookAt(closestObject.transform);
            attackingObject.AttackTarget(closestObject);
        }
    }
}