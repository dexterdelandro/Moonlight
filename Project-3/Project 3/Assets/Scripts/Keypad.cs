using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public string pass = "10815";
    public string input;
    public string tempInput;
    public bool onTrigger;
    public bool keypadScreen;

    bool mustWait = false;
    public DoorController exitDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator keypadCoolDown() {
        if (mustWait) {
            yield return new WaitForSeconds(10);
            mustWait = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        onTrigger = true;
    }

    void OnTriggerExit(Collider other) {
        onTrigger = false;
        input = "";
        keypadScreen = false;
    }

    void OnGUI() {
        if (onTrigger) {
            if (!mustWait)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open Keypad");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = true;
                    onTrigger = false;
                }
            }
            else {
                GUI.Box(new Rect(0, 0, 250, 25), "You must wait before you try again!");

            }

        }

        if (keypadScreen) {
            GUI.Box(new Rect(0, 0, 320, 400), "");
            GUI.Box(new Rect(5, 5, 310, 25), input);

            if (GUI.Button(new Rect(5, 35, 100, 100), "1")) {
                input += "1";
            }

            if (GUI.Button(new Rect(110, 35, 100, 100), "2"))
            {
                input += "2";
            }

            if (GUI.Button(new Rect(215, 35, 100, 100), "3"))
            {
                input += "3";
            }

            if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
            {
                input += "4";
            }

            if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
            {
                input += "5";
            }

            if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
            {
                input += "6";
            }
            if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
            {
                input += "7";
            }

            if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
            {
                input += "8";
            }

            if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
            {
                input += "9";
            }

            if (GUI.Button(new Rect(5, 350, 100, 100), "DELETE"))
            {
                input = input.Substring(0, input.Length-1);
            }

            if (GUI.Button(new Rect(110, 350, 100, 100), "0"))
            {
                input += "0";
            }

            if (GUI.Button(new Rect(215, 350, 100, 100), "ENTER"))
            {
                if (input == pass)
                {
                    input = "CORRECT!";
                    exitDoor.openExitDoor();
                }
                else {
                    input = "WRONG!";
                    mustWait = true;
                    StartCoroutine(keypadCoolDown());
                }
                
            }

        }
    }
}
