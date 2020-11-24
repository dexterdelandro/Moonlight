using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCandle : MonoBehaviour
{
    public LayerMask candleMask;
    public float maxDistance = 5.0f;
    public Camera cam;
    public bool holding;
    public bool justDropped;
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        justDropped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.paused)
        {
            if (Input.GetKeyDown(KeyCode.E) && !holding && !justDropped)
            {
                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, candleMask))
                {
                    hit.transform.GetComponent<Candle>().held = true;
                    hit.transform.GetComponent<Candle>().justPickedUp = true;
                    holding = true;
                }
            }
            justDropped = false;
        }
    }
}
