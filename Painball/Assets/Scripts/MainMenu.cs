using UnityEngine;
using UnityEngine.SceneManagement; // Include SceneManager
using UnityEngine.UI; // Include UI for button

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadSceneAsync(0);

    }

    public void QuitGame()
    {

        Application.Quit();

    }
}