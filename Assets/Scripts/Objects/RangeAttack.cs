using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Attack
{
    public GameObject bulletObject;

    public override void AttackTarget(GameObject target)
    {
        if (isReloading) return;
        var position = transform.position;
        GameObject bullet = GameObject.Instantiate(bulletObject, position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - position)*speed;
        StartCoroutine(Reloading());
    }
}