using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectType;

    public bool collected;

    public Stickynote stickyNote;

    private void Start()
    {
        stickyNote = GetComponent<Stickynote>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (objectType == "Stickynote")
            {
                Debug.Log("Press F to pick up <b>Sticky Note</b> " + GetComponent<Stickynote>().noteNumber);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // Trigger item pick up availability code //
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("<b>Sticky Note</b> picked up!");

                if(!collected)
                {
                    PickUp();

                    collected = true;
                }
            }
        }
    }

    public void PickUp()
    {
        if (objectType == "Stickynote")
        {
            GameObject.Find("UserInterface").GetComponent<UIManager>().UpdateNoteSystemUISection(stickyNote,
                stickyNote.parts, stickyNote.expressions,
                stickyNote.noteImage, stickyNote.texts);
        }

        GameObject.Find("GameManager").GetComponent<GameManager>().notesCollected++;
    }
}