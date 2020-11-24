using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDisappearance : MonoBehaviour
{
    public float maxTime = 5f;
    private float timer;
    public bool moves = false;
    private bool movingLeft;
    void Start()
    {
        timer = 0f;
        movingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moves)
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (movingLeft)
            {
                transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
                if(transform.position.x < -2f)
                {
                    movingLeft = false;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
                if (transform.position.x > 2f)
                {
                    movingLeft = true;
                }
            }
        }
    }
}
