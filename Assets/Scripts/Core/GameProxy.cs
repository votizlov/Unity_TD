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

        public int Scores { get; private set; }

        public AttackController attackController { get; set; }

        public UIController UI { get; set; }
        public Timer Timer { get; set; }

        private List<GameObject> _objects = new List<GameObject>();

        public List<GameObject> enemies = new List<GameObject>();
        public List<GameObject> guards = new List<GameObject>();
        public GameObject baze;
        public bool isLastWave = false;
        

        public void ClearState()
        {
            Scores = 0;
        }

        public void AddObject(GameObject obj)
        {
            _objects.Add(obj);
        }

        public void RemoveObject(GameObject obj)
        {
            _objects.Remove(obj);
        }

        public void AddScore(int value)
        {
            Scores += value;

            if (Scores > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", Scores);
                PlayerPrefs.Save();
            }

            AddScoreEvent?.Invoke(value);
        }

        public void OnWawesCleared()
        {
            WavesClearedEvent?.Invoke();
        }

        public void EndGame()
        {
            Time.timeScale = 0;
            BaseDestroyedEvent?.Invoke();
        }
    }
}
