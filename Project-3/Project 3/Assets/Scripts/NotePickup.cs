using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePickup : MonoBehaviour
{
    public int noteId;
    public Note notes;
    void Start()
    {
        notes = GameObject.Find("NoteCanvas").GetComponent<Note>();
    }

    public void MakeTrue()
    {
        notes.noteFound[noteId] = true;
        notes.currentNote = noteId;
        notes.atLeastOne = true;
    }
}
