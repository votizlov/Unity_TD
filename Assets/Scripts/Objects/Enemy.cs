using UnityEngine;

namespace Objects
{
    public class Enemy : PathfindingObject
    {
        public int bounty;

        private bool isInCombat = false;

        // Start is called before the first frame update
        void Start()
        {
            gameProxy.enemies.Add(gameObject);
        }

        private void OnDestroy()
        {
            gameProxy.AddScore(bounty);
            gameProxy.enemies.Remove(gameObject);
            if (gameProxy.enemies.Count == 0 && gameProxy.isLastWave)
                gameProxy.OnWawesCleared();
        }

        // Update is called once per frame
        void Update()
        {
            float minDistance = aggroRange;
            GameObject closestObject = null;
            foreach (var guard in gameProxy.guards)
            {
                if (Vector3.Distance(guard.transform.position, transform.position) <= minDistance)
                {
                    minDistance = Vector3.Distance(guard.transform.position, transform.position);
                    closestObject = guard;
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
                target = gameProxy.baze.transform;
                attackingObject.AttackTarget(gameProxy.baze);
            }

            SetDestination(target);
        }
    }
}