using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameProxy gameProxy;

    // Start is called before the first frame update
    void Start()
    {
        gameProxy.baze = gameObject;
    }

    private void OnDestroy()
    {
        gameProxy.EndGame();
    }
}
