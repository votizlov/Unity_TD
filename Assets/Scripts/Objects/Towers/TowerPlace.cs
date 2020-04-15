using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public UIController ui;
    public float towerOffsetY;

    private void OnMouseDown()
    {
        ui.OpenTowerPlaceMenu(this);
    }

    public void PlaceTower(GameObject tower)
    {
        Vector3 t = transform.position;
        t.y += towerOffsetY;
        GameObject.Instantiate(tower, t, Quaternion.identity);
    }
}