using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool eerstHulp = false;
    public GameObject eerstHulpText;

    public void PlayGame()
    {
       if (eerstHulp == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       else
        {
            eerstHulpText.SetActive(true);
        }
    }

    public void HulpGame()
    {
        eerstHulpText.SetActive(false);
        eerstHulp = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
