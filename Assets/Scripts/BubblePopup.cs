using UnityEngine;
using System.Collections;

public class BubblePopup : MonoBehaviour
{
    private GameObject player;
    public GameObject bubble;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerDet")
        {
           StartCoroutine(BubbleToggle());
        }
    }

    public IEnumerator BubbleToggle()
    {
        bubble.SetActive(true);
        yield return new WaitForSeconds(1f);
        bubble.SetActive(false);

        Destroy(GetComponent<BoxCollider2D>());

        StopCoroutine(BubbleToggle());
    }
}