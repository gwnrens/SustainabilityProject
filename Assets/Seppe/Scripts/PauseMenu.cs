using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;

    void Start()
    {
        //geen pause menu tijdens start van het spel
        pauseMenu.SetActive(false);

        // Luisteraars toevoegen voor het pauzeren en hervatten van het spel
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void Update()
    {
       
    }

    public void GiveUp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PauseGame()
    {
        // Pauzemenu activeren
        pauseMenu.SetActive(true);
        //Tijd freezen zorgt dat er niks meer gebeurt van logica of physics in de game
        Time.timeScale = 0f;

        //Resume & pauze knoppen
        pauseButton.interactable = false;
        resumeButton.interactable = true;
    }

    public void ResumeGame()
    {
        //pause scherm verdwijnt
        pauseMenu.SetActive(false);
        // resume tijd
        Time.timeScale = 1f;

        pauseButton.interactable = true;

        resumeButton.interactable = false;
    }
}
