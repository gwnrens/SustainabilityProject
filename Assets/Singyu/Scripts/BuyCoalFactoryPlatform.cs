using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuyCoalFactoryPlatform : MonoBehaviour
{
    public int factoryCost = 40;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.coins >= factoryCost)
        {
            GameManager.Instance.ModifyCoins(-factoryCost);
            GameManager.Instance.AddCoalFactory();
        }
    }
}


