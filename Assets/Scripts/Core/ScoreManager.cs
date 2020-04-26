using System;
using UnityEngine;

namespace Core
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private GameProxy gp;

        private int scores;

        private void Awake()
        {
            gp.AddScoreEvent += AddScore;
        }

        private void OnDisable()
        {
            gp.AddScoreEvent += AddScore;
        }

        private void AddScore(int value)
        {
            scores += value;

            if (scores > PlayerPrefs.GetInt("Highscore"))
            {
                PlayerPrefs.SetInt("Highscore", scores);
                PlayerPrefs.Save();
            }
        }
    }
}
