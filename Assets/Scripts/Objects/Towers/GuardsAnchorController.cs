using Core;
using UnityEngine;

namespace Objects.Towers
{
    public class GuardsAnchorController : MonoBehaviour
    {
        public BarracksTower parentTower;
        public GameProxy gameProxy;

        private Ray r;
        private RaycastHit hit;
        private Vector3 v;

        // Update is called once per frame
        void Update()
        {
            if (!Input.GetMouseButtonUp(0))
            {
                r = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(r, out hit, 100f))
                {
                    v = hit.point;
                    v.y = 1;
                    gameObject.transform.position = v;
                }
            }
            else
            {
                parentTower.OnAnchorPointSet(gameObject.transform);
                gameProxy.UI.onAnchorPlaced();
                gameObject.SetActive(false);
            }
        }
    }
}