using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyNuclearFactoryPlatform : MonoBehaviour
{

        public GameManagerElec gameManagerElec;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && gameManagerElec.coins >= gameManagerElec.nuclearPlantCost)
            {
                gameManagerElec.ModifyCoins(-gameManagerElec.nuclearPlantCost);
                gameManagerElec.AddNuclearPlant();
            }
        }
    }
