using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public Button startButton;

    public Image faderScreen;

    public Animator faderAnimator;

    public Animator startButtonAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            StartCoroutine(StartGame());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartGame()
    {
        faderAnimator.Play("Fade");

        startButtonAnimator.Play("StartButtonFade");

        yield return new WaitForSeconds(3.5f);

        GameObject.Find("SceneChanger").GetComponent<SceneChanger>().ChangeScene("Level_1");
    }
}
