
using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameProxy gameProxy;
    
    public TMP_Text pointsText;
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
}
