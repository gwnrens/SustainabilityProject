using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float intervalSeconds = 30.0f; 
    public float audioRange = 10.0f; 
    public Transform playerTransform; 

    private AudioSource audioSource;
    private float timer;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        timer = intervalSeconds;
    }

    void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) <= audioRange)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                PlayRandomAudioClip();
                timer = intervalSeconds;
            }
        }
    }

 
    void PlayRandomAudioClip()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.PlayOneShot(audioClips[randomIndex]);
        }
    }
}