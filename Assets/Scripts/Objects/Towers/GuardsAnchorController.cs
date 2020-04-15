using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardsAnchorController : MonoBehaviour
{
    public BarracksTower parentTower;
    public GameProxy gameProxy;

    private bool isFollowingMouse;

    // Start is called before the first frame update
    void Awake()
    {
        isFollowingMouse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowingMouse && !Input.GetMouseButtonDown(0))
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else
        {
            parentTower.onAnchorPointSet();
            gameProxy.UI.onAnchorPlaced();
           gameObject.SetActive(false);
        }
    }
}