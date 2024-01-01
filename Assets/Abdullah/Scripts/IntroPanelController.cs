using UnityEngine;
using UnityEngine.UI; // Importeer voor UI-componenten zoals Button

public class IntroPanelController : MonoBehaviour
{
    public GameObject[] introPanels; // Array voor de intro panelen
    public Button nextButton; // Referentie naar de 'Volgende' knop
    public Button previousButton; // Referentie naar de 'Terug' knop
    private int currentPanelIndex = 0; // Huidige paneelindex

    void Start()
    {
        // Verberg alle panelen behalve de eerste
        foreach (GameObject panel in introPanels)
        {
            panel.SetActive(false);
        }

        if (introPanels.Length > 0)
        {
            introPanels[currentPanelIndex].SetActive(true);
        }

        // Knop interactie instellen
        nextButton.onClick.AddListener(GoToNextPanel);
        previousButton.onClick.AddListener(GoToPreviousPanel);
    }

    public void GoToNextPanel()
    {
        if (currentPanelIndex < introPanels.Length - 1)
        {
            introPanels[currentPanelIndex].SetActive(false);
            currentPanelIndex++;
            introPanels[currentPanelIndex].SetActive(true);
        }
    }

    public void GoToPreviousPanel()
    {
        if (currentPanelIndex > 0)
        {
            introPanels[currentPanelIndex].SetActive(false);
            currentPanelIndex--;
            introPanels[currentPanelIndex].SetActive(true);
        }
    }
}
