using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Wave", order = 2)]
    public class Wave : ScriptableObject
    {
        public List<GameObject> enemies;
        public Transform spawnPoint;
        public float Delay;
    }
}
