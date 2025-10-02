using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("General - Audio Clips")]
    public AudioClip doorOpenSFX;
    public AudioClip doorSlamSFX;
    public AudioClip keyPickupSFX;
    public AudioClip flashlightSFX;

    [Header("Cute Notes - Audio Clips")]
    public AudioClip cuteMusic;
    public AudioClip cuteAmbientMusic;

    [Header("Creepy Notes - Audio Clips")]
    public AudioClip creepyMusic;
    public AudioClip creepyAmbientMusic;
    public AudioClip windSFX;
    public AudioClip monsterSFX;

    [Header("Final Notes - Audio Clips")]
    public AudioClip finalMusic;
    public AudioClip finalAmbientMusic;
    public AudioClip heartbeatSFX;
    public AudioClip horrorWindsSFX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = finalMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
