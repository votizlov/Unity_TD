using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public abstract class PathfindingObject : MonoBehaviour
{
    public Attack attack = null;
    public GameProxy gameProxy;
    public AIDestinationSetter destinationSetter;
    public float aggroRange;

    protected Transform target;

    protected void SetDestination(Transform transform)
    {
        destinationSetter.target = transform;
    }
}
