using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string objectType;

    public bool collected;

    public Stickynote stickyNote;

    public bool canBePickedUp;

    public UIManager uiManager;

    public GameManager gameManager;

    private void Start()
    {
        canBePickedUp = false;

        stickyNote = GetComponent<Stickynote>();

        uiManager = GameObject.Find("UserInterface").GetComponent<UIManager>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager && gameManager.realGameStart)
        {
            if (collision.tag == "PlayerDet")
            {
                canBePickedUp = true;

                uiManager.pickUpInstructions.GetComponentInChildren<TextMeshProUGUI>().text = GetPickUpInstructions();

                uiManager.TogglePickUpInstructions();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager && gameManager.realGameStart)
        {
            if (collision.tag == "PlayerDet")
            {
                if (canBePickedUp)
                {
                    canBePickedUp = false;

                    uiManager.TogglePickUpInstructions();
                }
            }
        }
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

    private string GetPickUpInstructions()
    {
        return "Press <b>F</b> to pick up " + objectType;
    }
}