using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        public GameProxy gameProxy;

        private void Awake()
        {
            gameProxy.attackController = new AttackController();
        }
    }
}
