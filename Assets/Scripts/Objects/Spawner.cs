using System.Collections;
using Configs;
using Core;
using Core.Pooling;
using UnityEngine;

namespace Objects
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnerConfig _spawnerConfig;
        [SerializeField] private GameProxy gameProxy;

        private Coroutine _spawnRoutine;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            var pos = transform.position;
            Gizmos.DrawLine(pos, pos + Vector3.up * 5);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pos, pos + Vector3.left * 5);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pos, pos + Vector3.forward * 5);
            //Gizmos.DrawCube(transform.position, transform.localScale);
        }

        private int counter;
        private int waveCounter;
        private bool isWavesLeft = true;

        private void OnEnable()
        {
            _spawnRoutine = StartCoroutine(SpawnRoutine);
        }

        private void OnDisable()
        {
            if (_spawnRoutine != null)
                StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }

        private IEnumerator SpawnRoutine
        {
            get
            {
                counter = _spawnerConfig.Waves.Count;
                while (isWavesLeft)
                {

                    if (counter-->0)
                    {
                        var element = _spawnerConfig.GetElement(waveCounter++);
                        yield return new WaitForSeconds(element.Delay);
                        foreach (var enemy in element.enemies)
                        {
                            PoolManager.GetObject(enemy.name, element.spawnPoint.position, Quaternion.identity);
                        }
                    }
                    else
                    {
                        isWavesLeft = false;
                    }
                }

                gameProxy.isLastWave = true;
            }
        }
    }
}