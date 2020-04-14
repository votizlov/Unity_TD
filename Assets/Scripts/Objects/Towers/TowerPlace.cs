using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public UIController ui;
    private bool _isMenuOpened = false;

    private void OnMouseDown()
    {
        if (!_isMenuOpened)
        {
            ui.OpenTowerPlaceMenu();
        }
    }
}