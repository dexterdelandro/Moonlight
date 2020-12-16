using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpNote : MonoBehaviour
{
    public Camera cam;
    public float maxDistance = 100f;
    public LayerMask noteMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.paused)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, noteMask))
                {
                    hit.transform.GetComponent<NotePickup>().MakeTrue();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
