using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    public override void AttackTarget(GameObject target)
    {
        if(isReloading||CheckRange(target.transform)||target.gameObject.GetComponent<DamagableObject>()==null) return;
        target.GetComponent<DamagableObject>().ReduceHealth(damage);
    }
}
