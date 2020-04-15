using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        public GameProxy gameProxy;
        public UIController ui;

        private void Awake()
        {
            gameProxy.attackController = new AttackController();
            gameProxy.UI = ui;
        }
    }
}
