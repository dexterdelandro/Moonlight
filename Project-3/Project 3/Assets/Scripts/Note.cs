using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{

    public List<Image> listOfNotes;

    private static Canvas canvas;

    private bool isDisplayed = false;
    public int currentNote;
    public bool[] noteFound;
    public bool atLeastOne;

    // Start is called before the first frame update
    void Start()
    {
        atLeastOne = false;
        currentNote = 0;
        listOfNotes = new List<Image>();
        canvas = GameObject.Find("NoteCanvas").GetComponent<Canvas>();
        noteFound = new bool[5];
        for(int c = 0; c < 5; c++)
        {
            listOfNotes.Add(canvas.transform.GetChild(c).GetComponent<Image>());
            noteFound[c] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (atLeastOne)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                Pause.HitPause(true);
                isDisplayed = Pause.paused;
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

    }
}
