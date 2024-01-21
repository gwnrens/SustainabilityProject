using UnityEngine;
using TMPro;

public class BonusCalculator : MonoBehaviour
{
    public TextMeshProUGUI[] sourceTextMeshes; // Bronnen: Array van 3 TextMesh Pro UI elementen met aantal items
    public TextMeshProUGUI[] targetTextMeshes; // Targets: Array van 3 TextMesh Pro UI elementen voor bonussen
    public TextMeshProUGUI totalTextMesh; // TextMesh Pro UI voor het tonen van het totaal
    private int[] bonusMultipliers = new int[] { 15, 20, 25 }; // Vermenigvuldigingsfactoren voor elke bonus

    void Start()
    {
        if (sourceTextMeshes.Length != 3 || targetTextMeshes.Length != 3)
        {
            Debug.LogError("Er moeten precies 3 source en 3 target TextMeshes zijn.");
            return;
        }

        int total = 0;
        for (int i = 0; i < sourceTextMeshes.Length; i++)
        {
            int bonus = CalculateBonus(sourceTextMeshes[i], bonusMultipliers[i]);
            targetTextMeshes[i].text = bonus.ToString();
            total += bonus;
        }

        totalTextMesh.text = total.ToString();
    }

    private int CalculateBonus(TextMeshProUGUI sourceTextMesh, int multiplier)
    {
        if (int.TryParse(sourceTextMesh.text, out int value))
        {
            return value * multiplier;
        }
        else
        {
            Debug.LogError($"Kan tekst niet omzetten naar getal: {sourceTextMesh.text}");
            return 0;
        }
    }
}
