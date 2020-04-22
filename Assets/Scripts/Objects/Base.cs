using Core;
using UnityEngine;

namespace Objects
{
    public class Base : MonoBehaviour
    {
        public GameProxy gameProxy;

        // Start is called before the first frame update
        void Start()
        {
            gameProxy.baze = gameObject;
        }

        private void OnDestroy()
        {
            gameProxy.EndGame();
        }
    }
}
