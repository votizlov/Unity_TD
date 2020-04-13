using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public float range, damage, speed, reload;
    protected bool isReloading = false;

    public IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(reload);
        isReloading = false;
    }

    public abstract void AttackTarget(GameObject target);
}