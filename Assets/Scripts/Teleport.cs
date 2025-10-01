using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject portal;

    private GameObject player;

    private GameManager gm;

    public string currentRoom;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.transform.parent.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
            gm.Teleport(new Vector2(portal.transform.position.x, portal.transform.position.y),
                currentRoom, portal.GetComponent<TeleportAddOn>().currentRoom);
        }
    }
}
