using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    private bool isFlashlightOn = false;
    private bool canToggle = true;
    public float toggleCooldown = 0.5f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canToggle)
        {
            ToggleFlashlight();
            StartCoroutine(StartCooldown());
        }
    }

    void ToggleFlashlight()
    {
        isFlashlightOn = !isFlashlightOn;

        flashlight.enabled = isFlashlightOn;
    }

    System.Collections.IEnumerator StartCooldown()
    {
        canToggle = false;
        yield return new WaitForSeconds(toggleCooldown);
        canToggle = true;
    }
}
