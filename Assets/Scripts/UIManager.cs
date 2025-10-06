using System.Collections;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI noteCounterText;

    public GameObject dimmedBackground;

    public GameObject preGameDimmedBackground;

    public Animator dimmedBGAnimator;

    public Animator preGameDimmedBGAnimator;

    public GameObject persephonySketch;

    public GameObject noteSprite;

    public GameObject noteText;

    public Button button;

    public int notePartCounter;

    public Player playerScript;

    public Transform start;

    public Sprite startSprite;

    public PreGameDialogManager preGameDialogManager;

    public GameObject flashLight;

    public Animator persephonySketchPreGameAnimator;

    public Animator preGameTextBoxTextAnimator;

    public Animator preGameTextBoxAnimator;

    public GameObject preGameTextBox;

    public GameObject pickUpInstructions;

    public GameManager gameManager;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(PreGameCutScene());

        TogglePickUpInstructions();
    }

    public void UpdateNoteSystemUISection(Stickynote note, int noteParts, Sprite[] expression, Sprite noteImage, string[] textToDisplay)
    {
        notePartCounter = 1;

        playerScript.enabled = false;

        ShowUIComponents();

        persephonySketch.GetComponent<Image>().sprite = expression[0];

        noteSprite.GetComponent<Image>().sprite = noteImage;

        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[0];

        notePartCounter++;

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

        else if(noteParts > 2)
        {
            Debug.Log("More than 1 note part");
            if (note.GetComponent<Interactable>().objectType == "PomBowl")
            {
                button.onClick.AddListener(() =>
                {
                    if(notePartCounter == 2)
                    {
                        persephonySketch.GetComponent<Image>().sprite = expression[1];

                        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[1];

                        notePartCounter++;
                    }

                    else if(notePartCounter == 3)
                    {
                        persephonySketch.GetComponent<Image>().sprite = expression[2];

                        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[2];

                        notePartCounter++;
                    }

                    else if (notePartCounter == noteParts + 1)
                    {
                        HideUIComponents(note);

                        playerScript.enabled = true;

                        note.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                        gameManager.ActivateNotes("DoorToHell");
                    }
                });
            }

            else if(note.GetComponent<Interactable>().objectType == "DoorToHell")
            {
                button.onClick.AddListener(() =>
                {
                    if (notePartCounter == noteParts + 1)
                    {
                        HideUIComponents(note);
                    }

                    else
                    {
                        if (expression[notePartCounter - 1] != null)
                        {
                            persephonySketch.SetActive(true);

                            persephonySketch.GetComponent<Image>().sprite = expression[notePartCounter - 1];
                        }

                        else
                        {
                            persephonySketch.SetActive(false);
                        }

                        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[notePartCounter - 1];

                        notePartCounter++;
                    }
                });
            }
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

            if (gameManager.notesCollected == 5)
            {
                gameManager.ActivateNotes("Creepy");
            }

            else if (gameManager.notesCollected == 10)
            {
                gameManager.ActivateNotes("Final");
            }

            else if(gameManager.notesCollected == 13)
            {
                gameManager.ActivateNotes("PomBowl");
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

            playerScript.hasFlashlight = true;
        }

        else if(note.gameObject.GetComponent<Interactable>().objectType == "PomBowl")
        {
            dimmedBackground.SetActive(false);

            persephonySketch.SetActive(false);

            noteSprite.SetActive(false);

            noteText.transform.parent.gameObject.SetActive(false);

            notePartCounter = 1;

            button.onClick.RemoveAllListeners();
        }

        else if (note.gameObject.GetComponent<Interactable>().objectType == "DoorToHell")
        {
            dimmedBackground.SetActive(false);

            persephonySketch.SetActive(false);

            noteSprite.SetActive(false);

            noteText.transform.parent.gameObject.SetActive(false);

            notePartCounter = 1;

            button.onClick.RemoveAllListeners();
        }
    }

    public IEnumerator PreGameCutScene()
    {
        preGameDimmedBackground.SetActive(true);

        preGameDimmedBGAnimator.Play("DimmedBGFadeIn");

        yield return new WaitForSeconds(4f);

        preGameDimmedBGAnimator.Play("DimmedBGFadeOut");

        yield return new WaitForSeconds(2.1f);

        playerScript.gameObject.transform.position = start.position;

        playerScript.gameObject.GetComponent<SpriteRenderer>().sprite = startSprite;

        preGameDimmedBGAnimator.Play("DimmedBGFadeIn");

        gameManager.EnableCerbPlushie();

        yield return new WaitForSeconds(2f);

        preGameDialogManager.ShowPreDialog();

        persephonySketchPreGameAnimator.Play("PersephoneSketchFadeIn");

        preGameTextBoxTextAnimator.Play("PregameTextBoxTextFadeIn");

        yield return new WaitForSeconds(1f);

        gameManager.realGameStart = true;
    }

    public void TogglePickUpInstructions()
    {
        pickUpInstructions.SetActive(!pickUpInstructions.activeSelf);
    }
}