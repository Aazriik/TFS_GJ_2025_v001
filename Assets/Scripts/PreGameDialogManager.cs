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

    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        button.onClick.AddListener(() =>
        {
            Skip();
        });
    }

    public void ShowPreDialog()
    {
        persephonySketch.SetActive(true);

        button.gameObject.SetActive(true);

        dialogText.SetActive(true);
    }


    public void Skip()
    {
        dimmedBackground.SetActive(false);

        persephonySketch.SetActive(false);

        button.gameObject.SetActive(false);

        dialogText.SetActive(false);

        playerScript.GetComponent<Animator>().enabled = true;

        playerScript.enabled = true;

        gameManager.realGameStart = true;
    }
}
