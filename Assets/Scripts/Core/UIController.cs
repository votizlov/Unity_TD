using Objects.Towers;
using TMPro;
using UnityEngine;

namespace Core
{
    public class UIController : MonoBehaviour
    {
        public GameProxy gameProxy;
    
        public TMP_Text pointsText;

        public GameObject towerPlaceMenu;

        public GameObject anchorPlaceMenu;
        public GameObject winMenu;
        public GameObject loseMenu;

        public bool isMenuOpened = false;

        public GameObject[] availableTowers;

        private TowerPlace selectedPlace = null;
    
        // Start is called before the first frame update
        private void Awake()
        {
            gameProxy.AddScoreEvent += UpdateScoreText;
            gameProxy.BaseDestroyedEvent += OnLose;
            gameProxy.WavesClearedEvent += OnWin;
            towerPlaceMenu.SetActive(false);
            anchorPlaceMenu.SetActive(false);
            loseMenu.SetActive(false);
            winMenu.SetActive(false);
        }

        private void OnDisable()
        {
            gameProxy.AddScoreEvent -= UpdateScoreText;
            gameProxy.BaseDestroyedEvent -= OnLose;
            gameProxy.WavesClearedEvent -= OnWin;
        }

        private void OnLose()
        {
            loseMenu.SetActive(true);
        }
    
        private void OnWin()
        {
            winMenu.SetActive(true);
        }

        private void UpdateScoreText(int i)
        {
            pointsText.text = i.ToString();
        }

        public void OpenTowerPlaceMenu(TowerPlace place)
        {
            if (isMenuOpened) return;
            isMenuOpened = true;
            towerPlaceMenu.SetActive(true);
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //pz.z = 0;
            towerPlaceMenu.transform.parent = gameObject.transform;
            selectedPlace = place;
        }

        public void OpenAnchorPlaceMenu(BarracksTower barracksTower)
        {
            if(isMenuOpened) return;
            isMenuOpened = true;
            anchorPlaceMenu.SetActive(true);
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //pz.z = 0;
            anchorPlaceMenu.transform.parent = gameObject.transform;
        }

        public void PlaceTower(int i)
        {
            isMenuOpened = false;
            towerPlaceMenu.SetActive(false);
            selectedPlace.PlaceTower(availableTowers[i]);
        }

        public void onAnchorPlaced()
        {
            isMenuOpened = false;
            anchorPlaceMenu.SetActive(false);
        }
    }
}
