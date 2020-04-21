using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Wave", order = 2)]
public class Wave : ScriptableObject
{
    public List<GameObject> enemies;
    public Transform spawnPoint;
    public float Delay;
}

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

    public void OnValidate()
    {
        foreach (var spawnElement in Waves)
        {
            if (spawnElement.enemies != null)
            {
                // spawnElement.UnitName = spawnElement.SpawnedPrefab.name;
            }
        }
    }
}