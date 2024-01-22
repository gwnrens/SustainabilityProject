using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGasFactory : MonoBehaviour
{
    public int factoryCost = 30;
    public GameManagerElec gameManagerElec;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManagerElec.coins >= factoryCost)
        {
            gameManagerElec.ModifyCoins(-factoryCost);
            gameManagerElec.AddGasFactory();
        }
    }
}
