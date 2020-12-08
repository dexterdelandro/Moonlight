using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Julien's Sceme House");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        if (Pause.paused)
        {
            Pause.HitPause();
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu Scene");
    }

    public void ResumeButton()
    {
        Pause.HitPause();
    }
}
