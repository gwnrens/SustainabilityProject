using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SellCoalFactory : MonoBehaviour
{
    public int factorySellValue = 20;
    public GameManagerElec gameManagerElec;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&gameManagerElec.GetNumberOfCoalPlants()>0)
        {
            gameManagerElec.ModifyCoins(factorySellValue);
            gameManagerElec.RemoveCoalFactory();
        }
    }
}
