using System.Collections;
using Core;
using UnityEngine;

namespace Objects.Attacks
{
    public class AttackingObject : MonoBehaviour
    {
        public float range, damage, speed, reload;
        private AttackController attackController;
        public GameProxy gameProxy;
        public AttackType type;
        public GameObject projectilePrefab;
        private bool isReloading = false;

        private void Start()
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
}
