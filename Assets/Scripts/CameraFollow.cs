using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.currentRoom == "Hallway")
        {
            gm.activeCamera.transform.position = new Vector3(gm.activeCamera.transform.position.x,
                gm.player.transform.position.y, -10f);
        }
    }
}
