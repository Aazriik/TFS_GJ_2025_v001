using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public Camera activeCamera;

    public List<Camera> cameras;

    public Vector3 bedroomCamPos;

    public Vector3 hallwayCamPos;

    private void Start()
    {
        player = GameObject.Find("Player");

        activeCamera = cameras[0];
    }

    public void Teleport(Vector2 targetPos, string previousRoom, string toRoom)
    {
        player.transform.position = targetPos;

        if(toRoom == "Hallway")
        {
            SwitchCamera(activeCamera, cameras[1]);
        }

        else if(toRoom == "Bedroom")
        {
            SwitchCamera(activeCamera, cameras[0]);
        }
    }

    public void SwitchCamera(Camera from, Camera to)
    {
        from.gameObject.SetActive(false);

        to.gameObject.SetActive(true);

        activeCamera = to;
    }
}
