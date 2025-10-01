using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject portal;
Artemis-WalkingAnim
    private GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");

    private GameManager gm;

    public string currentRoom;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
main
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
Artemis-WalkingAnim
            player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
            gm.Teleport(new Vector2(portal.transform.position.x, portal.transform.position.y),
                currentRoom, portal.GetComponent<TeleportAddOn>().currentRoom);
main
        }
    }
}
