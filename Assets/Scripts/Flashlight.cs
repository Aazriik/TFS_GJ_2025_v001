using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flashlight : MonoBehaviour
{
    public float offTimer = 0.1f;

    float timeBetweenFlicker = 0;

    public Light2D flashlight;

    public float dimAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FlashlightFlicker());
    }

    public IEnumerator FlashlightFlicker()
    {
        yield return new WaitForSeconds(Random.Range(Random.Range(4f, 6f), Random.Range(10f, 14f)));

        flashlight.intensity -= dimAmount;

        yield return new WaitForSeconds(offTimer);

        flashlight.intensity += dimAmount;

        yield return new WaitForSeconds(offTimer);

        flashlight.intensity -= dimAmount;

        yield return new WaitForSeconds(offTimer);

        flashlight.intensity += dimAmount;

        StopCoroutine(FlashlightFlicker());

        StartCoroutine(FlashlightFlicker());
    }
}
