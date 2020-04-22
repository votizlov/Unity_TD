using Core;
using UnityEngine;

namespace Objects.Towers
{
    public class TowerPlace : MonoBehaviour
    {
        public UIController ui;
        public float towerOffsetY;
        private bool isOccupied = false;

        private void OnMouseDown()
        {
            if (isOccupied) return;
            ui.OpenTowerPlaceMenu(this);
        }

        public void PlaceTower(GameObject tower)
        {
            Vector3 t = transform.position;
            t.y += towerOffsetY;
            GameObject.Instantiate(tower, t, Quaternion.identity);
            isOccupied = true;
        }
    }
}