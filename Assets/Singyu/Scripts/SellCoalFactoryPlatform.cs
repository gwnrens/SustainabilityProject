using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SellCoalFactory : MonoBehaviour
{
    public int factorySellValue = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ModifyCoins(factorySellValue);
            GameManager.Instance.RemoveCoalFactory();
        }
    }
}
