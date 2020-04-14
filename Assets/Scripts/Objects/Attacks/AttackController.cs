using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController
{
    private GameObject target;
    private AttackingObject attackingObject;

    public void AttackTarget(AttackingObject attackingObject, GameObject target)
    {
        this.target = target;
        this.attackingObject = attackingObject;
        switch (attackingObject.type)
        {
            case AttackType.RangeBulletAttack:
                RangeBulletAttack();
                break;
            case AttackType.MeleeAttack:
                MeleeAttack();
                break;
        }
    }

    private void RangeBulletAttack()
    {
        var position = attackingObject.transform.position;
        GameObject bullet =
            (GameObject) GameObject.Instantiate(attackingObject.projectilePrefab, position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity =
            Vector3.Normalize(target.transform.position - position) * attackingObject.speed;
        bullet.GetComponent<Bullet>().damage = attackingObject.damage;
    }

    private void MeleeAttack()
    {
        target.GetComponent<DamagableObject>().ReduceHealth(attackingObject.damage);
    }
}

public enum AttackType
{
    RangeBulletAttack,
    MeleeAttack
}