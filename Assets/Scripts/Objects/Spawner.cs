using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Wave[] waves;

    public float waveInterval;

    public GameProxy gameProxy;

    private int currentWave = 0;
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        while (currentWave < waves.Length)
        {
            
            yield return new WaitForSeconds(waveInterval);
        }
        gameProxy.OnWawesCleared();
    }
}
