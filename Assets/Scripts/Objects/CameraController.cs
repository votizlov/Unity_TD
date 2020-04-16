﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 1;
    private Vector3 dragOrigin;
    public UIController uiController;
 
 
    void Update()
    {
        if (uiController.isMenuOpened) return;
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }
 
        if (!Input.GetMouseButton(0)) return;
 
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);
 
        transform.Translate(move, Space.World);  
    }
 
 
}
