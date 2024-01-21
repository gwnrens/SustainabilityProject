using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellSolarPanelFactory : MonoBehaviour
{
    public int solarPanelSellValue = 50; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.GetNumberOfSolarPanels() > 0)
        {
            GameManager.Instance.ModifyCoins(solarPanelSellValue);
            GameManager.Instance.RemoveSolarPanel();
        }
    }
}
