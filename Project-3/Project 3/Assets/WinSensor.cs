using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinSensor : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
	}
}
