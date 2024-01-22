using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellSolarPanelFactory : MonoBehaviour
{
    public int solarPanelSellValue = 50;
    public GameManagerElec gameManagerElec;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManagerElec.GetNumberOfSolarPanels() > 0)
        {
            gameManagerElec.ModifyCoins(solarPanelSellValue);
            gameManagerElec.RemoveSolarPanel();
        }
    }
}
