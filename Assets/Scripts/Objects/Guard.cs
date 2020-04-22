using Objects.Towers;
using UnityEngine;

namespace Objects
{
    public class Guard : PathfindingObject
    {
        public BarracksTower tower;
        private bool isInCombat = false;

        // Start is called before the first frame update
        void Start()
        {
            gameProxy.guards.Add(gameObject);
            target = gameObject.transform;
        }

        private void OnDestroy()
        {
            gameProxy.guards.Remove(gameObject);
            tower.onGuardKilled();
        }

        // Update is called once per frame
        void Update()
        {
            float minDistance = aggroRange;
            GameObject closestObject = null;
            foreach (var enemy in gameProxy.enemies)
            {
                if (minDistance == -1 || Vector3.Distance(enemy.transform.position, transform.position) <= minDistance)
                {
                    minDistance = Vector3.Distance(enemy.transform.position, transform.position);
                    closestObject = enemy;
                }
            }

            if (minDistance < aggroRange)
            {
                isInCombat = true;
                target = closestObject.transform;
                attackingObject.AttackTarget(closestObject);
            }
            else
            {
                isInCombat = false;
                target = tower.guardsGroupingPoint;
            }
            SetDestination(target);
        }
    }
}
