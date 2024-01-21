using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySolarPanelFactory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.coins >= GameManager.Instance.solarPanelCost)
        {
            GameManager.Instance.ModifyCoins(-GameManager.Instance.solarPanelCost);
            GameManager.Instance.AddSolarPanel();
        }
    }
}
