using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int teller;
    public GameObject eerstHulpText;

    public void PlayGame()
    {
       if (teller == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       else
        {
            eerstHulpText.SetActive(true);
            Invoke("HulpGame", 5f);
        }
    }

    public void HulpGame()
    {
        eerstHulpText.SetActive(false);
        teller++;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
