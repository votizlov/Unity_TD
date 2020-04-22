using Core;
using Objects.Attacks;
using UnityEngine;
using UnityEngine.AI;

namespace Objects
{
    public class PathfindingObject : MonoBehaviour
    {
        public AttackingObject attackingObject = null;
        public GameProxy gameProxy;
        public float aggroRange;
        public NavMeshAgent agent;

        protected Transform target;

        protected void SetDestination(Transform transform)
        {
            agent.destination = transform.position;
        }
    }
}
