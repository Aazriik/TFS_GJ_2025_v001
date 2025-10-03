using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string toScene)
    {
        SceneManager.LoadScene(toScene);
    }
}