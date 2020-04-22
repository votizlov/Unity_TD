using System.Collections;
using Configs;
using Core;
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
            Gizmos.DrawLine(transform.position, transform.position + Vector3.up * 5);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.left * 5);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * 5);
            //Gizmos.DrawCube(transform.position, transform.localScale);
        }

        private int _counter = 0;
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
                while (isWavesLeft)
                {
                    var element = _spawnerConfig.GetElement(_counter++);

                    if (element != null)
                    {
                        yield return new WaitForSeconds(element.Delay);
                        foreach (var enemy in element.enemies)
                        {
                            Instantiate(enemy, element.spawnPoint.position, transform.rotation);
                        }
                    }
                    else
                    {
                        isWavesLeft = false;
                    }
                }

                gameProxy.OnWawesCleared();
            }
        }
    }
}