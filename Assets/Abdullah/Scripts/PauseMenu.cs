using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
