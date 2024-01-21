using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public enum WeaponType
{
    Projectile,
    Raycast,
    Beam
}

public class Weapon : MonoBehaviour
{
    // Weapon Type
    public WeaponType type = WeaponType.Projectile;

    public int isTurret = 0;

    // Shooting
    public float rateOfFire = 10f; // Rounds per second
    private float nextFireTime = 0f;

    // Ammo
    public int ammoCapacity = 12;
    private int currentAmmo;
    public float reloadTime = 2.0f;
    private bool isReloading = false;

    // Projectile
    public GameObject projectile;
    public Transform projectileSpawnSpot;

    // Audio
    public AudioClip fireSound;
    public AudioClip reloadSound;
    public AudioClip dryFireSound;
    public AudioMixerGroup masterMixerGroup; // Voeg deze variabele toe
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = masterMixerGroup;
        currentAmmo = ammoCapacity;
    }

    void Update()
    {
        if (isTurret == 1)
            return;

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / rateOfFire;
            Shoot();
        }
    }

    public void Shoot()
    {
        currentAmmo--;

        // Fire logic based on weapon type
        switch (type)
        {
            case WeaponType.Projectile:
                Instantiate(projectile, projectileSpawnSpot.position, projectileSpawnSpot.rotation);
                break;
            case WeaponType.Raycast:
                // Add raycast shooting logic here
                break;
            case WeaponType.Beam:
                // Add beam weapon logic here
                break;
        }

        GetComponent<AudioSource>().PlayOneShot(fireSound);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        GetComponent<AudioSource>().PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = ammoCapacity;
        isReloading = false;
    }
}
