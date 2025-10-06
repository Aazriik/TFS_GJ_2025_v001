using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables //
    public GameObject player;

    public GameObject cerbPlushie;

    public GameObject physicsTable;

    public Player playerScript;

    public Camera activeCamera;

    public List<Camera> cameras;

    public string currentRoom;

    public int notesCollected;

    public GameObject[] noteCategories;

    public bool realGameStart;

    public GameObject pomBowl;

    public bool canCollectPomBowl;

    // Called on game start //
    private void Start()
    {
        #region Assigning Game Objects
        player = GameObject.Find("Player");

        playerScript = GameObject.Find("Player").GetComponent<Player>();

        cerbPlushie = GameObject.Find("CerbPlushie");

        physicsTable = GameObject.Find("PhysicsTable");
        #endregion

        #region Other Start Stuff
        DisableCerbPlushie();

        activeCamera = cameras[0];

        currentRoom = "Bedroom";

        notesCollected = 0;

        player.GetComponent<Player>().enabled = false;

        ActivateNotes("Cute");

        realGameStart = false;
        #endregion
    }

    private void Update()
    {
        if(canCollectPomBowl)
        {
            ActivateNotes("PomBowl");
        }
    }

    // Teleports player to (targetPos) based on (toRoom) //
    public void Teleport(Vector2 targetPos, string previousRoom, string toRoom)
    {
        player.transform.position = targetPos;

        if (toRoom == "Hallway")
        {
            SwitchCamera(activeCamera, cameras[1]);

            currentRoom = "Hallway";
        }

        else if (toRoom == "Bedroom")
        {
            SwitchCamera(activeCamera, cameras[0]);

            currentRoom = "Bedroom";
        }

        else if (toRoom == "Livingroom")
        {
            SwitchCamera(activeCamera, cameras[2]);

            currentRoom = "Livingroom";
        }

        else if (toRoom == "Kitchen")
        {
            SwitchCamera(activeCamera, cameras[3]);

            currentRoom = "Kitchen";
        }

        else if (toRoom == "Bathroom")
        {
            SwitchCamera(activeCamera, cameras[4]);

            currentRoom = "Bathroom";
        }
    }

    // Switches the active camera from (from) to (to) //
    public void SwitchCamera(Camera from, Camera to)
    {
        from.gameObject.SetActive(false);

        to.gameObject.SetActive(true);

        activeCamera = to;
    }

    // Activate the group of notes (Category) //
    public void ActivateNotes(string category)
    {
        if (category == "Cute")
        {
            // Activates all the "cute" note //
            noteCategories[0].SetActive(true);
        }

        else if(category == "Creepy")
        {
            // Deactivates the cute notes and activates the creepy notes //
            noteCategories[0].SetActive(false);

            noteCategories[1].SetActive(true);
        }

        else if(category == "Final")
        {
            noteCategories[0].SetActive(false);

            // Deactivates the creepy notes and activates the final notes //
            noteCategories[1].SetActive(false);

            noteCategories[2].SetActive(true);
        }

        else if(category == "PomBowl")
        {
            noteCategories[0].SetActive(false);
            noteCategories[1].SetActive(false);

            // Deactivates the final notes and activates the pom bowl note //
            noteCategories[2].SetActive(false);
            noteCategories[3].SetActive(true);
        }

        else if(category == "DoorToHell")
        {
            noteCategories[0].SetActive(false);
            noteCategories[1].SetActive(false);
            noteCategories[2].SetActive(false);

            // Deactivates the pom bowl note and activates the doortohell note //
            noteCategories[3].SetActive(false);
            noteCategories[4].SetActive(true);

            // Allowing the table to be moved with physics //
            physicsTable.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    // Call this to enable the cerb plushie gameobject //
    public void EnableCerbPlushie()
    {
        cerbPlushie.SetActive(true);
    }

    // Call this to disable the cerb plushie gameobject //
    public void DisableCerbPlushie()
    {
        cerbPlushie.SetActive(false);
    }
}
