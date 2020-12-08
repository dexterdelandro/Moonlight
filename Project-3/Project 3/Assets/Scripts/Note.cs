using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{

    public List<Image> listOfNotes;

    private static Canvas canvas;

    private bool isDisplayed = false;
    private int currentNote;
    public bool[] noteFound;

    // Start is called before the first frame update
    void Start()
    {
        currentNote = 0;
        listOfNotes = new List<Image>();
        canvas = GameObject.Find("NoteCanvas").GetComponent<Canvas>();
        noteFound = new bool[5];
        for(int c = 0; c < 5; c++)
        {
            listOfNotes.Add(canvas.transform.GetChild(c).GetComponent<Image>());
            noteFound[c] = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (listOfNotes.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                isDisplayed = !isDisplayed;
                canvas.enabled = !canvas.enabled;
            }

            if (isDisplayed)
            {
                listOfNotes[currentNote].enabled = true;
                listOfNotes[currentNote].transform.parent.position = Vector3.zero;
                listOfNotes[currentNote].transform.localScale = new Vector3(5, 7, 5);

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    listOfNotes[currentNote].enabled = false;
                    currentNote--;
                    if (currentNote < 0)
                    {
                        currentNote = listOfNotes.Count - 1;
                    }
                    while (noteFound[currentNote] == false)
                    {
                        currentNote--;
                        if (currentNote < 0)
                        {
                            currentNote = listOfNotes.Count - 1;
                        }
                    }

                    listOfNotes[currentNote].enabled = true;
                    listOfNotes[currentNote].transform.parent.position = Vector3.zero;
                    listOfNotes[currentNote].transform.localScale = new Vector3(5, 7, 5);
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    listOfNotes[currentNote].enabled = false;

                    currentNote++;
                    if (currentNote > listOfNotes.Count - 1)
                    {
                        currentNote = 0;
                    }
                    while (noteFound[currentNote] == false)
                    {
                        currentNote++;
                        if (currentNote > listOfNotes.Count - 1)
                        {
                            currentNote = 0;
                        }
                    }

                    listOfNotes[currentNote].enabled = true;
                    listOfNotes[currentNote].transform.parent.position = Vector3.zero;
                    listOfNotes[currentNote].transform.localScale = new Vector3(5, 7, 5);
                }
            }
            else if (!isDisplayed)
            {
                canvas.enabled = false;
                listOfNotes[currentNote].enabled = false;
            }
        }
        else 
        {

        }

    }
}
