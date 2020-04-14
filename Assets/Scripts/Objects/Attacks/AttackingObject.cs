using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingObject : MonoBehaviour
{
    public float range, damage, speed, reload;
    private AttackController attackController;
    public GameProxy gameProxy;
    public AttackType type;
    public GameObject projectilePrefab;
    protected bool isReloading = false;

    private void Awake()
    {
        attackController = gameProxy.attackController;
    }

    private IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(reload);
        isReloading = false;
    }

    protected bool CheckRange(Transform t)
    {
        return !(Vector3.Distance(t.position, transform.position) <= range) ;
    }

    public void AttackTarget(GameObject target)
    {
        if (isReloading||CheckRange(target.transform)) return;
        attackController.AttackTarget(this,target);
        StartCoroutine(Reloading());
    }
}
