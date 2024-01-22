using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySolarPanelFactory : MonoBehaviour
{
    public GameManagerElec gameManagerElec;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManagerElec.coins >= gameManagerElec.solarPanelCost)
        {
            gameManagerElec.ModifyCoins(-gameManagerElec.solarPanelCost);
            gameManagerElec.AddSolarPanel();
        }
    }
}
