using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public Camera activeCamera;

    public List<Camera> cameras;

    public string currentRoom;

    public int notesCollected;

    public GameObject[] noteCategories;



    private void Start()
    {
        player = GameObject.Find("Player");

        activeCamera = cameras[0];

        currentRoom = "Bedroom";

        notesCollected = 0;

        ActivateNotes("Cute");
    }

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

        else if(toRoom == "Livingroom")
        {
            SwitchCamera(activeCamera, cameras[2]);

            currentRoom = "Livingroom";
        }

        else if(toRoom == "Kitchen")
        {
            SwitchCamera(activeCamera, cameras[3]);

            currentRoom = "Kitchen";
        }

        else if (toRoom == "Bathroom")
        {
            SwitchCamera(activeCamera, cameras[4]);

            currentRoom = "Bathroom";
        }

        Debug.Log("Inside " + currentRoom);
    }

    public void SwitchCamera(Camera from, Camera to)
    {
        from.gameObject.SetActive(false);

        to.gameObject.SetActive(true);

        activeCamera = to;
    }

    public void ActivateNotes(string category)
    {
        if (category == "Cute")
        {
            noteCategories[0].SetActive(true);
        }

        else if(category == "Creepy")
        {
            noteCategories[0].SetActive(false);

            noteCategories[1].SetActive(true);
        }

        else if(category == "Final")
        {
            noteCategories[1].SetActive(false);

            noteCategories[2].SetActive(true);
        }
    }
}
