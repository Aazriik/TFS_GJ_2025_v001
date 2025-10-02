using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public Camera activeCamera;

    public List<Camera> cameras;

    public string currentRoom;

    public int notesCollected;

    private void Start()
    {
        player = GameObject.Find("Player");

        activeCamera = cameras[0];

        currentRoom = "Bedroom";

        notesCollected = 0;
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
    }

    public void SwitchCamera(Camera from, Camera to)
    {
        from.gameObject.SetActive(false);

        to.gameObject.SetActive(true);

        activeCamera = to;
    }
}
