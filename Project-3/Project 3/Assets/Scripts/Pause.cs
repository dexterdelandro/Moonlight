using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool paused;
    private static Canvas canvas;
    private static Canvas noteCanvas;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        canvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        noteCanvas = GameObject.Find("NoteCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HitPause();
        }
    }

    public static void HitPause(bool note = false)
    {
        paused = !paused;
        if (paused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            if (note)
            {
                noteCanvas.enabled = true;
            }
            else
            {
                canvas.enabled = true;
            }
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            canvas.enabled = false;
            noteCanvas.enabled = false;
        }
    }
}
