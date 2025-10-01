using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public Camera activeCamera;

    public List<Camera> cameras;

    public Vector3 bedroomCamPos;

    public Vector3 hallwayCamPos;

    public Vector3 libraryCam;

    public string currentRoom;

    private void Start()
    {
        player = GameObject.Find("Player");

        activeCamera = cameras[0];

        currentRoom = "Bedroom";
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

        else if(toRoom == "Library")
        {
            SwitchCamera(activeCamera, cameras[2]);

            currentRoom = "Library";
        }
    }

    public void SwitchCamera(Camera from, Camera to)
    {
        from.gameObject.SetActive(false);

        to.gameObject.SetActive(true);

        activeCamera = to;
    }
}
