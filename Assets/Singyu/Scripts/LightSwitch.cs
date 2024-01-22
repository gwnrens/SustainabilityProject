using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light associatedLight;
    public GameManagerElec gameManager; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && associatedLight.enabled)
        {
            associatedLight.enabled = false;
            gameManager.ModifyCoins(20);
        }
    }
}