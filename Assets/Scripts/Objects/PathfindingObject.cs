using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
