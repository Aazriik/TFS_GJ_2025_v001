using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject portal;

    public bool doorOpenSound;

    private GameObject player;

    private GameManager gm;

    public string currentRoom;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerDet")
        {
            if (doorOpenSound == true)
            {
                audioManager.PlaySFX(audioManager.doorOpenSFX);
            }

            player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
            gm.Teleport(new Vector2(portal.transform.position.x, portal.transform.position.y),
                currentRoom, portal.GetComponent<TeleportAddOn>().currentRoom);
        }
    }
}
