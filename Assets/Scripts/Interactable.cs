using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectType;

    public bool collected;

    public Stickynote stickyNote;

    public bool canBePickedUp;

    private void Start()
    {
        canBePickedUp = false;

        stickyNote = GetComponent<Stickynote>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Show UI pick up instructions //

            if (objectType == "Stickynote")
            {
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canBePickedUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canBePickedUp = false;
    }

    private void Update()
    {
        if(canBePickedUp)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!collected)
                {
                    PickUp();

                    collected = true;

                    canBePickedUp = false;
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

            GameObject.Find("GameManager").GetComponent<GameManager>().notesCollected++;
        }

        else if(objectType == "Flashlight")
        {
            GameObject.Find("UserInterface").GetComponent<UIManager>().UpdateNoteSystemUISection(stickyNote,
                stickyNote.parts, stickyNote.expressions,
                stickyNote.noteImage, stickyNote.texts);
        }
    }
}