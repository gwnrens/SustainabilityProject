using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public bool isFlashlightOn = false;
    private bool canToggle = true;
    public float toggleCooldown = 0.5f;
    
    //referentie naar audio scource component en de audio clips die afgespeeld moeten worden.
    public AudioSource audioSource;
    public AudioClip flashlightOnSound;
    public AudioClip flashlightOffSound;

    void Update()
    {
        //spatiebalk is ingedrukt?
        if (Input.GetKeyDown(KeyCode.Space) && canToggle)
        {
            //Zaklamp staat omkeren aan word uit en uit word aan.
            ToggleFlashlight();
            //Coroutine om over meerdere frames een cooldown te hebben dit om snel (spam) schakelen te voorkomen.
            StartCoroutine(StartCooldown());
        }
    }

    void ToggleFlashlight()
    {
        //Zaklamp veranderen
        isFlashlightOn = !isFlashlightOn;
        //Light component van de flashlight veranderen
        flashlight.enabled = isFlashlightOn;

        //Afspelen van de sound effects
        if (audioSource != null)
        {
            if (isFlashlightOn && flashlightOnSound != null)
            {
                audioSource.PlayOneShot(flashlightOnSound);
            }
            else if (!isFlashlightOn && flashlightOffSound != null)
            {
                audioSource.PlayOneShot(flashlightOffSound);
            }
        }
    }

    // Cooldown zodat flashlight niet mega snel aan en uit gaat (fix voor bug omdat zonder cooldown wnr je op spatie drukte de flashlight al 20 keer in 1 seconde aan en uit ging.)
    IEnumerator StartCooldown()
    {
        canToggle = false;
        yield return new WaitForSeconds(toggleCooldown);
        canToggle = true;
    }
}
