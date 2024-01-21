using UnityEngine;
using TMPro;

public class TMPTextModifier : MonoBehaviour
{
    public TextMeshProUGUI sourceTextMesh; // Optioneel
    public TextMeshProUGUI targetTextMesh; // Optioneel
    public TextMeshProUGUI Total;
    public int operationValue = 25; // Gebruikt voor vermenigvuldiging
    public TextMeshProUGUI[] bonusTextMeshes; // Optioneel, gebruikt voor optelling

    void Start()
    {
        if (sourceTextMesh != null && targetTextMesh != null)
        {
            PerformMultiplication();
        }
        else if (bonusTextMeshes.Length > 0)
        {
            PerformAddition();
        }
        else
        {
            Debug.LogError("Geen geldige configuratie van textmesh gevonden.");
        }
    }

    private void PerformMultiplication()
    {
        if (int.TryParse(sourceTextMesh.text, out int baseValue))
        {
            baseValue *= operationValue;
            targetTextMesh.text = baseValue.ToString();
        }
        else
        {
            Debug.LogError("Source TextMesh Pro text is not a valid integer.");
        }
    }

    private void PerformAddition()
    {
        int sum = 0;
        foreach (TextMeshProUGUI bonusTextMesh in bonusTextMeshes)
        {
            Debug.Log($"Bonus text (before parsing): '{bonusTextMesh.text}'");
            if (int.TryParse(bonusTextMesh.text, out int bonusValue))
            {
                sum += bonusValue;
            }
            else
            {
                Debug.LogError($"Failed to parse text: {bonusTextMesh.text}");
            }
        }
        Total.text = sum.ToString();
    }

}