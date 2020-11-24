using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool paused;
    private static Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        canvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HitPause();
        }
    }

    public static void HitPause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            canvas.enabled = false;
        }
    }
}
