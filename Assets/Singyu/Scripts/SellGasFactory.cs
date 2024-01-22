using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellGasFactory : MonoBehaviour
{

    public int factorySellValue = 15;
    public GameManagerElec gameManagerElec;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManagerElec.GetNumberOfGasFactories() > 0)
        {
            gameManagerElec.ModifyCoins(factorySellValue);
            gameManagerElec.RemoveGasFactory();
        }
    }
}

