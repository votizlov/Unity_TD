using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Attack attack;

    public GameProxy gameProxy;

    private GameObject _target = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = -1;
        GameObject closestObject = null;
        foreach (var enemy in gameProxy.enemies)
        {
            if (minDistance == -1 || Vector3.Distance(enemy.transform.position, transform.position) < minDistance)
            {
                minDistance = Vector3.Distance(enemy.transform.position, transform.position);
                closestObject = enemy;
            }
        }
        if(minDistance < attack.range)
            attack.AttackTarget(closestObject);
    }
}
