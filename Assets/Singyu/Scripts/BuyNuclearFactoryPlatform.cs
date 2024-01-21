using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyNuclearFactoryPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.coins >= GameManager.Instance.nuclearPlantCost)
        {
            GameManager.Instance.ModifyCoins(-GameManager.Instance.nuclearPlantCost);
            GameManager.Instance.AddNuclearPlant();
        }
    }
}