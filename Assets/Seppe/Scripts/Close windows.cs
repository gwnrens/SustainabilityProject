using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public bool rotated;
    private Quaternion originalRotation = Quaternion.Euler(0f, 175f, 0f);
    private Quaternion closedRotation = Quaternion.Euler(0f, 0f, 0f);

    public AudioClip pressSound;
    private AudioSource audioSource;

    private void Start()
    {
        rotated = false;

        // AudioSource component 
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = pressSound;
    }

    private void OnMouseDown()
    {
        //Controlen of het object gedraaid is of niet
        if (!rotated)
        {
            transform.rotation = originalRotation;
            rotated = true;
        }
        else
        {
            transform.rotation = closedRotation;
            rotated = false;
        }
        // Geluid afspelen
        if (pressSound != null && audioSource != null)
        {
            audioSource.Play();
        }
    }
}
