using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBulletAttack : Attack
{
    public GameObject bulletPrefab;

    public override void AttackTarget(GameObject target)
    {
        if (isReloading||CheckRange(target.transform)) return;
        var position = transform.position;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.transform.position - position)*speed;
        bullet.GetComponent<Bullet>().damage = damage;
        StartCoroutine(Reloading());
    }
}