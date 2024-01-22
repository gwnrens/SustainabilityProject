using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFactory : MonoBehaviour
{
    public GameObject coalFactory; 
    public AudioClip activationSound; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = activationSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {

        }
    }
}
