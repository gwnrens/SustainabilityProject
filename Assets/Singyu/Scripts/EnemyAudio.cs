using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioClip soundToPlay;
    private AudioSource audioSource;

    void Start()
    {
   
        audioSource = gameObject.AddComponent<AudioSource>();

 
        audioSource.clip = soundToPlay;
        audioSource.spatialBlend = 1.0f; 
        audioSource.loop = true; 
        audioSource.playOnAwake = true; 

        audioSource.minDistance = 1f; 
        audioSource.maxDistance = 10f; 

        audioSource.Play();
    }
}