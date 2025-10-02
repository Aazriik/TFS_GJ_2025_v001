using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip ambientMusic;
    public AudioClip doorOpenSFX;
    public AudioClip doorCloseSFX;
    public AudioClip keyPickupSFX;
    public AudioClip buttonPressSFX;
    public AudioClip doorSlamSFX;
    public AudioClip windSFX;
    public AudioClip monsterSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
