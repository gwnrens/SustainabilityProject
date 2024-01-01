using UnityEngine;
using TMPro; // TextMesh Pro namespace

public class TMPTextModifier : MonoBehaviour
{
    public enum OperationType { Multiply, Add } // Enum to select the operation type

    public TextMeshProUGUI sourceTextMesh; // Assign this in the inspector with your source TextMesh Pro UI object
    public TextMeshProUGUI targetTextMesh; // Assign this with your target TextMesh Pro UI object
    public OperationType operation = OperationType.Add; // Operation type, can be set in the inspector
    public int operationValue = 100; // Default value for operation, used if bonuses array is empty
    public TextMeshProUGUI[] bonusTextMeshes; // Array of TextMeshProUGUI for bonuses, can be set in the inspector

    void Start()
    {
        if (sourceTextMesh != null && targetTextMesh != null)
        {
            ModifyText();
        }
        else
        {
            Debug.LogError("Source and/or Target TextMesh Pro objects are not assigned.");
        }
    }

    private void ModifyText()
    {
        if (int.TryParse(sourceTextMesh.text, out int baseValue))
        {
            int result = baseValue;

            // Special handling for multiplication with a base value of 0
            if (operation == OperationType.Multiply && baseValue == 0)
            {
                targetTextMesh.text = "0";
                return;
            }

            if (bonusTextMeshes == null || bonusTextMeshes.Length == 0) // Check if the bonusTextMeshes array is empty or null
            {
                ApplyOperation(ref result, operationValue); // Apply operation with operationValue
            }
            else
            {
                foreach (TextMeshProUGUI bonusTextMesh in bonusTextMeshes)
                {
                    if (int.TryParse(bonusTextMesh.text, out int bonusValue))
                    {
                        ApplyOperation(ref result, bonusValue); // Apply operation with each parsed bonus value
                    }
                }
            }

            targetTextMesh.text = result.ToString();
        }
        else
        {
            Debug.LogError("Source TextMesh Pro text is not a valid integer.");
        }
    }

    private void ApplyOperation(ref int currentResult, int value)
    {
        switch (operation)
        {
            case OperationType.Multiply:
                currentResult *= value;
                break;
            case OperationType.Add:
                currentResult += value;
                break;
        }
    }
}
