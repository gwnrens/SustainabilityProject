using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string LevelToLoad;
    public GameObject MainCanvas;
    public GameObject LevelSelectorCanvas;

    public void LevelSelector()
    {
            MainCanvas.SetActive(false);
            LevelSelectorCanvas.SetActive(true); 
    }
    public void MenuSelector()
    {
        MainCanvas.SetActive(true);
        LevelSelectorCanvas.SetActive(false);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
