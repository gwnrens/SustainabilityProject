using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public Camera introCam;
    public GameObject mainCanvas;
    public GameObject introCanvas;

    public void StartGame()
    {
        introCam.enabled = false;
        Time.timeScale = 1;
        mainCanvas.SetActive(true);
        introCanvas.SetActive(false);
    }
    
}
