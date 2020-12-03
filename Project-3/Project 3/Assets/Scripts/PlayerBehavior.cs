using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private GameObject monster;
    public float runAlertDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        monster = GameObject.Find("Monster");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.paused && Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Vector3.Distance(monster.transform.position, transform.position) < runAlertDistance)
        {
            monster.GetComponent<ArriveAtPoint>().NewPosition(transform.position);
        }
    }

    public void Die()
    {

    }
}
