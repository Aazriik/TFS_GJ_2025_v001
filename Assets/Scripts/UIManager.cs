using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI noteCounterText;

    public GameObject dimmedBackground;

    public GameObject persephonySketch;

    public GameObject noteSprite;

    public GameObject noteText;

    public Button button;

    public int notePartCounter;

    private void Start()
    {
        notePartCounter = 1;
    }

    public void UpdateUI(int noteParts, Sprite[] expression, Sprite noteImage, string[] textToDisplay)
    {
        GameObject.Find("Player").GetComponent<Player>().enabled = false;

        dimmedBackground.SetActive(true);

        persephonySketch.SetActive(true);

        noteSprite.SetActive(true);

        noteText.transform.parent.gameObject.SetActive(true);

        persephonySketch.GetComponent<Image>().sprite = expression[0];

        noteSprite.GetComponent<Image>().sprite = noteImage;

        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[0];

        if(noteParts > 1)
        {
            button.onClick.AddListener(() =>
            {
                if (notePartCounter == 1)
                {
                    persephonySketch.GetComponent<Image>().sprite = expression[1];

                    noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[1];

                    notePartCounter++;
                }

                else if (notePartCounter == 2)
                {
                    dimmedBackground.SetActive(false);

                    persephonySketch.SetActive(false);

                    noteSprite.SetActive(false);

                    noteText.transform.parent.gameObject.SetActive(false);

                    GameObject.Find("Player").GetComponent<Player>().enabled = true;
                }
            });
        }

        else if (noteParts == 1) 
        {
            button.onClick.AddListener(() =>
            {
                if (notePartCounter == 1)
                {
                    dimmedBackground.SetActive(false);

                    persephonySketch.SetActive(false);

                    noteSprite.SetActive(false);

                    noteText.transform.parent.gameObject.SetActive(false);

                    GameObject.Find("Player").GetComponent<Player>().enabled = true;
                }
            });
        }
    }
}
