using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksTower : MonoBehaviour
{
    public GameObject guardsAnchorPoint;
    public GameObject guardPrefab;
    public GameProxy gameProxy;
    public UIController ui;
    public int maxGuards;

    public float trainingRate;
    private int currentGuards = 0;
    public Transform guardsGroupingPoint;

    private void Start()
    {
        ui = gameProxy.UI;
        ui.OpenAnchorPlaceMenu(this);
        GameObject anchor = Instantiate(guardsAnchorPoint, transform.position, Quaternion.identity);
        anchor.GetComponent<GuardsAnchorController>().parentTower = this;
    }

    private void OnMouseDown()
    {
        ui.OpenAnchorPlaceMenu(this);
    }

    public void OnAnchorPointSet(Transform pos)
    {
        guardsGroupingPoint = pos;
        StartCoroutine(spawnGuard());
    }

    private IEnumerator spawnGuard()
    {
        while (currentGuards < maxGuards)
        {
            currentGuards++;
           GameObject guard = Instantiate(guardPrefab, guardsGroupingPoint.position, Quaternion.identity);
           guard.GetComponent<Guard>().tower = this;
           yield return new WaitForSeconds(trainingRate);
        }
    }

    public void onGuardKilled()
    {
        currentGuards--;
        StartCoroutine(spawnGuard());
    }
}
