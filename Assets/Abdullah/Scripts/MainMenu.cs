using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ABMainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("abd_scene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("abd_menu");
    }

    public void NextGame()
    {
        SceneManager.LoadScene("");
    }
}
