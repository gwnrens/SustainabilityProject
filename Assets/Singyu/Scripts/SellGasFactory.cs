using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellGasFactory : MonoBehaviour
{
    public int factorySellValue = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.GetNumberOfGasFactories() > 0)
        {
            GameManager.Instance.ModifyCoins(factorySellValue);
            GameManager.Instance.RemoveGasFactory();
        }
    }
}

