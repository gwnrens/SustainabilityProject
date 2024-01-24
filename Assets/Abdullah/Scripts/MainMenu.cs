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
        SceneManager.LoadScene("Menu");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("abd_menu");
    }

    public void NextGame()
    {
        SceneManager.LoadScene("GetToWork");
    }
}
