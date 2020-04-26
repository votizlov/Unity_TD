using System;
using Objects;
using Objects.Attacks;
using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        public GameProxy gameProxy;
        public UIController ui;
        public Timer timer;

        private void Awake()
        {
            gameProxy.attackController = new AttackController();
            gameProxy.UI = ui;
            gameProxy.Timer = timer;
            gameProxy.BaseDestroyedEvent += Pause;
        }

        private void OnDisable()
        {
            gameProxy.BaseDestroyedEvent -= Pause;
        }

        private void Pause()
        {
            Time.timeScale = 0;
        }
    }
}
