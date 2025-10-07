using System.Collections;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    // Variables //
    // Player Reference //
    public Player playerScript;
    public Sprite startSprite;
    public Transform start;

    // Game Manager Reference //
    public GameManager gameManager;

    // PreGame References //
    public Animator preGameTextBoxTextAnimator;
    public Animator preGameTextBoxAnimator;
    public GameObject preGameTextBox;
    public GameObject preGameDimmedBackground;
    public Animator persephonySketchPreGameAnimator;
    public PreGameDialogManager preGameDialogManager;
    public Animator preGameDimmedBGAnimator;

    // Note System References //
    public GameObject noteSprite;
    public GameObject noteText;
    public Button button;
    public int notePartCounter;
    [HideInInspector]
    public TextMeshProUGUI noteCounterText;

    // Dimmed Background References //
    public GameObject dimmedBackground;
    public Animator dimmedBGAnimator;

    // Interaction System References //
    public GameObject persephonySketch;
    public GameObject pickUpInstructions;

    // Pickups References //
    public GameObject flashLight;
    #endregion


    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(PreGameCutScene());

        TogglePickUpInstructions();
    }


    #region Update StickyNote System UI
    public void UpdateNoteSystemUISection(Stickynote note, int noteParts, Sprite[] expression, Sprite noteImage, string[] textToDisplay)
    {
        button.onClick.RemoveAllListeners();
        notePartCounter = 1;
        playerScript.enabled = false;

        ShowUIComponents();

        persephonySketch.GetComponent<Image>().sprite = expression[0];
        noteSprite.GetComponent<Image>().sprite = noteImage;
        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[0];
        //notePartCounter++;

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
            //Debug.Log("More than 1 note part");
            if (note.GetComponent<Interactable>().objectType == "PomBowl")
            {
                button.onClick.AddListener(() =>
                {
                    if (notePartCounter < noteParts)
                    {
                        persephonySketch.GetComponent<Image>().sprite = expression[notePartCounter];
                        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[notePartCounter];
                        notePartCounter++;
                    }
                    else
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
                    if (notePartCounter < noteParts - 1)
                    {
                        notePartCounter++;
                        if (expression[notePartCounter] != null)
                        {
                            persephonySketch.SetActive(true);
                            persephonySketch.GetComponent<Image>().sprite = expression[notePartCounter];
                        }
                        else
                        {
                            persephonySketch.SetActive(false);
                        }
                        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay[notePartCounter];
                    }
                    else
                    {
                        HideUIComponents(note);
                    }
                });
                /*button.onClick.AddListener(() =>
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
                });*/
            }
        }
    }
    #endregion


    #region Update Expressions, Text and Main Image UI
    public void UpdateNoteSystemUISection(Sprite expression, Sprite flashlightImage, string textToDisplay)
    {
        ShowUIComponents();
        persephonySketch.GetComponent<Image>().sprite = expression;
        noteSprite.GetComponent<Image>().sprite = flashlightImage;
        noteText.GetComponent<TextMeshProUGUI>().text = textToDisplay;
    }
    #endregion


    #region Show/Hide UI Components
    private void ShowUIComponents()
    {
        dimmedBackground.SetActive(true);
        persephonySketch.SetActive(true);
        noteSprite.SetActive(true);
        noteText.transform.parent.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        button.interactable = true;
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
            StartCoroutine(FadeOutAndShowTextBox());
        }
    }
    #endregion

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

    private IEnumerator FadeOutAndShowTextBox()
    {
        // Hide other UI elements
        persephonySketch.SetActive(false);
        noteSprite.SetActive(false);
        noteText.transform.parent.gameObject.SetActive(false);
        notePartCounter = 1;
        button.onClick.RemoveAllListeners();

        // Start fade out
        dimmedBackground.SetActive(true);
        dimmedBGAnimator.Play("DimmedBGFadeOut");

        // Wait for fade to complete
        yield return new WaitForSeconds(3f);

        // Toggle the pickup instructions box
        TogglePickUpInstructions();

        // Change the text of the pickup instructions textbox
        var textComponent = pickUpInstructions.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "Thank you for playing the Demo!\nPlease rate and leave a comment.\nTo exit the game, ALT+F4";
        }

        // Optionally play an animation for the textbox
        /*if (preGameTextBoxAnimator != null)
        {
            preGameTextBoxAnimator.Play("YourTextBoxFadeInAnimation");
        }*/
    }
}