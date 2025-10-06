using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PreGameDialogManager : MonoBehaviour
{
    public string text;

    public GameObject dimmedBackground;

    public GameObject persephonySketch;

    public Button button;

    public Player playerScript;

    public GameObject dialogText;

    public GameObject textBox;

    public GameManager gameManager;

    public UIManager uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        uiManager = GameObject.Find("UserInterface").GetComponent<UIManager>();

        button.onClick.AddListener(() =>
        {
            if (gameManager.realGameStart)
            {
                StartCoroutine(ProceedIntoGame());
            }
        });
    }

    public void ShowPreDialog()
    {
        persephonySketch.SetActive(true);

        button.gameObject.SetActive(true);

        dialogText.SetActive(true);
    }


    public IEnumerator ProceedIntoGame()
    {
        FadeOutPreGameDialog();

        yield return new WaitForSeconds(1f);

        dimmedBackground.SetActive(false);

        persephonySketch.SetActive(false);

        button.gameObject.SetActive(false);

        dialogText.SetActive(false);

        textBox.SetActive(false);

        playerScript.GetComponent<Animator>().enabled = true;

        playerScript.enabled = true;
    }

    private void FadeOutPreGameDialog()
    {
        uiManager.persephonySketchPreGameAnimator.Play("PersephoneSketchFadeOut");

        uiManager.preGameTextBoxTextAnimator.Play("PregameTextBoxTextFadeOut");

        uiManager.preGameTextBoxAnimator.Play("PreGameTextBoxFadeOut");
    }
}