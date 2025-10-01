using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Variables
    private int coins = 0;

    [SerializeField]
    private Text coinCounterText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            coins++;
            coinCounterText.text = "" + coins;
        }
    }
}
