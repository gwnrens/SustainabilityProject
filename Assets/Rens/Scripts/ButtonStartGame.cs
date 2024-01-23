using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStartGame : MonoBehaviour
{
    public Camera introCam;
    public GameObject mainCanvas;
    public GameObject introCanvas;
    public GameObject ControlsExplaination;
    public string LevelToLoad;

    public void StartGame()
    {
        introCam.enabled = false;
        Time.timeScale = 1;
        mainCanvas.SetActive(true);
        introCanvas.SetActive(false);
    }
    public void ShowControls()
    {
        introCanvas.SetActive(false);
        ControlsExplaination.SetActive(true);

    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

}
