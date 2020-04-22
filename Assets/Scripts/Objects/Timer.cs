using System.Collections;
using TMPro;
using UnityEngine;

namespace Objects
{
    public class Timer : MonoBehaviour
    {
        public TMP_Text text;
        public float timeOfTick = 1f;
        private float currentTime = 0f;

        private void Start()
        {
            StartCoroutine(Counter());
        }

        private IEnumerator Counter()
        {
            while (true)
            {
                currentTime += timeOfTick;
                text.text = currentTime.ToString();
                yield return new WaitForSeconds(timeOfTick);
            }
        }
    }
}
