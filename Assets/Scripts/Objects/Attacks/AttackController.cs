using System.Collections;
using System.Collections.Generic;
using Core.Pooling;
using Objects.Projectiles;
using UnityEngine;

namespace Objects.Attacks
{
    public class AttackController
    {
        //todo add anims
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
                case AttackType.SuicideAttack:
                    SuicideAttack();
                    break;
                default:
                    Debug.Log("Unknown Attack");
                    break;
            }
        }

        private void SuicideAttack()
        {
            target.GetComponent<DamagableObject>().ReduceHealth(attackingObject.damage);
            GameObject.Destroy(target.gameObject);
        }

        private void RangeBulletAttack()
        {
            var position = attackingObject.transform.position;
            GameObject bullet = PoolManager.GetObject(attackingObject.projectilePrefab.name, position, Quaternion.identity);
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
        MeleeAttack,
        SuicideAttack
    }
}