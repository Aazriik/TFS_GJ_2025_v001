using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Variables
    public string objectType;

    public bool collected;

    public Stickynote stickyNote;

    public bool canBePickedUp;

    public UIManager uiManager;

    public GameManager gameManager;

    public GameObject player;

    public Player playerScript;

    private void Start()
    {
        player = GameObject.Find("Player");

        playerScript = GameObject.Find("Player").GetComponent<Player>();

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
            uiManager.UpdateNoteSystemUISection(stickyNote,
                stickyNote.parts, stickyNote.expressions,
                stickyNote.noteImage, stickyNote.texts);

            gameManager.notesCollected++;

            // Toggle Pick Up Instructions
            uiManager.TogglePickUpInstructions();
        }

        else if(objectType == "Flashlight")
        {
            uiManager.UpdateNoteSystemUISection(stickyNote,
                stickyNote.parts, stickyNote.expressions,
                stickyNote.noteImage, stickyNote.texts);

            // Toggle Pick Up Instructions
            if (uiManager.pickUpInstructions.activeInHierarchy)
                uiManager.TogglePickUpInstructions();

            player.GetComponent<Player>().hasFlashlight = true;
        }

        else if(objectType == "PomBowl")
        {
            uiManager.UpdateNoteSystemUISection(stickyNote,
                stickyNote.parts, stickyNote.expressions,
                stickyNote.noteImage, stickyNote.texts);

            // Toggle Pick Up Instructions
            if (uiManager.pickUpInstructions.activeInHierarchy)
                uiManager.TogglePickUpInstructions();

            playerScript.hasKey = true;
        }

        else if (objectType == "DoorToHell")
        {
            uiManager.UpdateNoteSystemUISection(stickyNote,
                stickyNote.parts, stickyNote.expressions,
                stickyNote.noteImage, stickyNote.texts);

            // Toggle Pick Up Instructions
            uiManager.TogglePickUpInstructions();
        }
    }

    private string GetPickUpInstructions()
    {
        if(objectType == "Stickynote")
        {
            return "Press <b>F</b> to pick up Stickynote";
        }
        else if(objectType == "Flashlight")
        {
            return "Press <b>F</b> to pick up Flashlight";
        }
        else if(objectType == "PomBowl")
        {
            return "Press <b>F</b> to pick up Key";
        }
        else if(objectType == "DoorToHell")
        {
            return "Press <b>F</b> to use Key";
        }
        else
        {
            return "Press <b>F</b> to pick up " + objectType;
        }
    }
}