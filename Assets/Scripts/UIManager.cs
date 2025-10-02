using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI noteCounterText;

    public GameObject dimmedBackground;

    public Animator dimmedBGAnimator;

    public GameObject persephonySketch;

    public GameObject noteSprite;

    public GameObject noteText;

    public Button button;

    public int notePartCounter;

    public Player playerScript;

    public PreGameDialogManager preGameDialogManager;

    public GameObject flashLight;

    private void Start()
    {
        notePartCounter = 1;

        playerScript = GameObject.Find("Player").GetComponent<Player>();

        StartCoroutine(FadeIn());
    }

    public void UpdateNoteSystemUISection(Stickynote note, int noteParts, Sprite[] expression, Sprite noteImage, string[] textToDisplay)
    {
        playerScript.enabled = false;

        ShowUIComponents();

        persephonySketch.GetComponent<Image>().sprite = expression[0];

        noteSprite.GetComponent<Image>().sprite = noteImage;

        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[0];

        if(noteParts == 2)
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
                    HideUIComponents(note);

                    playerScript.enabled = true;

                    note.gameObject.SetActive(false);
                }
            });
        }

        else if (noteParts == 1) 
        {
            button.onClick.AddListener(() =>
            {
                if (notePartCounter == 1)
                {
                    HideUIComponents(note);

                    playerScript.enabled = true;

                    note.gameObject.SetActive(false);
                }
            });
        }
    }

    public void UpdateNoteSystemUISection(Sprite expression, Sprite flashlightImage, string textToDisplay)
    {
        ShowUIComponents();

        persephonySketch.GetComponent<Image>().sprite = expression;

        noteSprite.GetComponent<Image>().sprite = flashlightImage;

        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay;
    }

    private void ShowUIComponents()
    {
        dimmedBackground.SetActive(true);

        persephonySketch.SetActive(true);

        noteSprite.SetActive(true);

        noteText.transform.parent.gameObject.SetActive(true);
    }

    private void HideUIComponents(Stickynote note)
    {
        if (note.gameObject.GetComponent<Interactable>().objectType == "Stickynote")
        {
            dimmedBackground.SetActive(false);

            persephonySketch.SetActive(false);

            noteSprite.SetActive(false);

            noteText.transform.parent.gameObject.SetActive(false);

            notePartCounter = 1;

            button.onClick.RemoveAllListeners();

            if (GameObject.Find("GameManager").GetComponent<GameManager>().notesCollected == 5)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().ActivateNotes("Creepy");
            }

            else if (GameObject.Find("GameManager").GetComponent<GameManager>().notesCollected == 10)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().ActivateNotes("Final");
            }
        }

        else if(note.gameObject.GetComponent<Interactable>().objectType == "Flashlight")
        {
            dimmedBackground.SetActive(false);

            persephonySketch.SetActive(false);

            noteSprite.SetActive(false);

            noteText.transform.parent.gameObject.SetActive(false);

            button.onClick.RemoveAllListeners();

            flashLight.SetActive(true);
        }
    }

    public IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2f);

        dimmedBGAnimator.Play("DimmedBGFadeIn");

        preGameDialogManager.ShowPreDialog();
    }
}
