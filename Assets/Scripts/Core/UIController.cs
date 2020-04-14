
using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameProxy gameProxy;
    
    public TMP_Text pointsText;

    public GameObject towerPlaceMenu;
    
    // Start is called before the first frame update
    private void Awake()
    {
        gameProxy.AddScoreEvent += UpdateScoreText;
    }

    private void OnDisable()
    {
        gameProxy.AddScoreEvent -= UpdateScoreText;
    }

    private void UpdateScoreText(int i)
    {
        pointsText.text = i.ToString();
    }

    public void OpenTowerPlaceMenu()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //pz.z = 0;
        var go = Instantiate<GameObject>(towerPlaceMenu, pz, Quaternion.identity);
        go.transform.parent = gameObject.transform;
    }
}
