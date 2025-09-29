using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    public float offTimer = 0.1f;

    float timeBetweenFlicker = 0;

    public Light2D flashlight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeBetweenFlicker = Random.Range(30f, 60f);

        InvokeRepeating("ResetTimeBetweenFlickers", 0f, 5f);

        InvokeRepeating("StartFlicker", timeBetweenFlicker, timeBetweenFlicker);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleFlashlight();
        }
    }

    public void ToggleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
    }

    public void StartFlicker()
    {
        StartCoroutine(FlashlightFlicker());
    }

    public IEnumerator FlashlightFlicker()
    {
        ToggleFlashlight();

        yield return new WaitForSeconds(offTimer);

        ToggleFlashlight();

        Debug.Log("Flashlight Flickered!");

        yield return new WaitForSeconds(offTimer);

        ToggleFlashlight();

        yield return new WaitForSeconds(offTimer);

        ToggleFlashlight();

        Debug.Log("Flashlight Flickered!");
    }

    public void ResetTimeBetweenFlickers()
    {
        timeBetweenFlicker = Random.Range(8f, 14f);
    }
}
