using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameProxy", order = 1)]
public class GameProxy : ScriptableObject
{
    public event Action NewGameEvent;
    public event Action EndGameEvent;
    public event Action<int> AddScoreEvent;
    public event Action<float> TimerTickEvent;
    public event Action TimerEndEvent;
    public event Action TimerAddEvent;

    public event Action NewWaveEvent;

    public event Action BaseDestroyedEvent;

    public int Scores { get; private set; }

    public AttackController attackController { get; set; }

    public UIController UI { get; set; }

    //todo public CameraShake CameraShake { get; set; }

    public Timer Timer { get; set; }

    private List<GameObject> _objects = new List<GameObject>();

    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> guards = new List<GameObject>();
    public GameObject baze;

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

    public void ShakeCam()
    {
        //CameraShake.Shake();
    }

    public void NewGame()
    {
        Physics2D.autoSimulation = true;
        Scores = 0;
        NewGameEvent?.Invoke();
    }

    public void EndGame()
    {
        Physics2D.autoSimulation = false;

        EndGameEvent?.Invoke();
    }

    public void OnTimerTick(float f)
    {
        TimerTickEvent?.Invoke(f);
    }

    public void OnTimerEnd()
    {
        TimerEndEvent?.Invoke();
    }
}
