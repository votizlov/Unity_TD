
using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameProxy gameProxy;
    
    public TMP_Text pointsText;

    public GameObject towerPlaceMenu;

    public bool isMenuOpened = false;

    public GameObject[] availableTowers;

    private TowerPlace selectedPlace = null;
    
    // Start is called before the first frame update
    private void Awake()
    {
        gameProxy.AddScoreEvent += UpdateScoreText;
        towerPlaceMenu.SetActive(false);
    }

    private void OnDisable()
    {
        gameProxy.AddScoreEvent -= UpdateScoreText;
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

    public void PlaceTower(int i)
    {
        isMenuOpened = false;
        towerPlaceMenu.SetActive(false);
        selectedPlace.PlaceTower(availableTowers[i]);
    }
}
