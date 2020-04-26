using System;
using System.Collections.Generic;
using Objects;
using Objects.Attacks;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameProxy", order = 1)]
    public class GameProxy : ScriptableObject
    {
        public event Action<int> AddScoreEvent;

        public event Action BaseDestroyedEvent;

        public event Action WavesClearedEvent;

        public AttackController attackController { get; set; }

        public UIController UI { get; set; }
        public Timer Timer { get; set; }

        public List<GameObject> enemies = new List<GameObject>();
        public List<GameObject> guards = new List<GameObject>();
        public GameObject baze;
        public bool isLastWave = false;

        public void AddScore(int value)
        {
            AddScoreEvent?.Invoke(value);
        }

        public void OnWawesCleared()
        {
            WavesClearedEvent?.Invoke();
        }

        public void EndGame()
        {
            BaseDestroyedEvent?.Invoke();
        }
    }
}