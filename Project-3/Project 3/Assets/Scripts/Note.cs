using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;

    public List<GameObject> listOfNotes = new List<GameObject>();

    private static Canvas canvas;

    private bool isDisplayed = false;
    private int currentNote = 0;

    // Start is called before the first frame update
    void Start()
    {
        g1 = Instantiate(g1);
        g2 = Instantiate(g2);

        canvas = GameObject.Find("NoteCanvas").GetComponent<Canvas>();

        g1.transform.parent = GameObject.Find("NoteCanvas").transform;
        g2.transform.parent = GameObject.Find("NoteCanvas").transform;

        listOfNotes.Add(g1);
        listOfNotes.Add(g2);

        foreach (GameObject g in listOfNotes)
        {
            g.SetActive(false);
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
                listOfNotes[currentNote].SetActive(true);
                listOfNotes[currentNote].transform.parent.position = Vector3.zero;
                listOfNotes[currentNote].transform.localScale = new Vector3(50, 50, 50);

                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    listOfNotes[currentNote].SetActive(false);
                    currentNote--;

                    if (currentNote < 0)
                    {
                        currentNote = listOfNotes.Count - 1;
                    }

                    listOfNotes[currentNote].SetActive(true);
                    listOfNotes[currentNote].transform.parent.position = Vector3.zero;
                    listOfNotes[currentNote].transform.localScale = new Vector3(50, 50, 50);
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    listOfNotes[currentNote].SetActive(false);
                    currentNote++;

                    if (currentNote > listOfNotes.Count - 1)
                    {
                        currentNote = 0;
                    }

                    listOfNotes[currentNote].SetActive(true);
                    listOfNotes[currentNote].transform.parent.position = Vector3.zero;
                    listOfNotes[currentNote].transform.localScale = new Vector3(30, 30, 30);
                }
            }
            else if (!isDisplayed)
            {
                canvas.enabled = false;
                listOfNotes[currentNote].SetActive(false);
            }
        }
        else 
        {

        }

    }
}
