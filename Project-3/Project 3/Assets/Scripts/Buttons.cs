using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("House");
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
        SceneManager.LoadScene("Menu Scene");
    }

    public void ResumeButton()
    {
        Pause.HitPause();
    }
}
