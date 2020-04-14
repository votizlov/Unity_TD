using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public float range, damage, speed, reload;
    protected bool isReloading = false;

    protected IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(reload);
        isReloading = false;
    }

    protected bool CheckRange(Transform t)
    {
        return !(Vector3.Distance(t.position, transform.position) <= range) ;
    }

    public abstract void AttackTarget(GameObject target);
}