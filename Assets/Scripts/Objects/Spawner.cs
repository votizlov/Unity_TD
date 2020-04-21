using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            var element = _spawnerConfig.GetElement(_counter);
            yield return new WaitForSeconds(element.Delay);
            while (element != null)
            {
                Instantiate(element.enemies[_counter], element.spawnPoint.position, transform.rotation);
                element = _spawnerConfig.GetElement(++_counter);
                yield return new WaitForSeconds(element.Delay);
            }
            gameProxy.OnWawesCleared();
        }
    }
}