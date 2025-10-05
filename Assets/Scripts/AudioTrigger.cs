using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    // Variables
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerDet")
        {
            audioManager.PlaySFX(audioManager.potShatterSFX);
            gameObject.SetActive(false);
        }
    }
}
