using System;
using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace Configs
{

    [CreateAssetMenu(menuName = "Spawner config")]
    public class SpawnerConfig : ScriptableObject
    {
        public List<Wave> Waves;

        public Wave GetElement(int i)
        {
            if (i < Waves.Count)
            {
                return Waves[i];
            }

            Debug.LogError("i больше SpawnData.Length");
            return null;
        }
    }
}