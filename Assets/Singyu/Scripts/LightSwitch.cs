using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light associatedLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && associatedLight.enabled)
        {
            associatedLight.enabled = false; 
            GameManager.Instance.ModifyCoins(20); 
        }
    }
}