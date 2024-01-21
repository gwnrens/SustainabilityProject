using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Weapon[] weapons; // Array of Weapon scripts attached to the turret
    float fireRate = 0.8f; // Time in seconds between each shot
    public bool isActivated = false; // Turret is activated and will start shooting

    private float nextFireTime = 0f;

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            weapon.isTurret = 1;
        }
    }

    void Update()
    {
        if (isActivated && Time.time >= nextFireTime)
        {
            FireAllWeapons();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FireAllWeapons()
    {
        foreach (var weapon in weapons)
        {
            if (weapon.type == WeaponType.Projectile && weapon.projectile != null)
            {
                Instantiate(weapon.projectile, weapon.projectileSpawnSpot.position, weapon.projectileSpawnSpot.rotation);
                // Play fire sound if available
                if (weapon.fireSound != null)
                {
                    weapon.GetComponent<AudioSource>().PlayOneShot(weapon.fireSound);
                }
            }
            // Add logic for Raycast or Beam type weapons if needed
        }
    }

    public void IncreaseFireRate(float increment)
    {
        fireRate += increment;
        if (fireRate <= 0) fireRate = 0.1f; // Prevents fire rate from being zero or negative
    }

    public void ActivateTurret(bool activate)
    {
        isActivated = activate;
    }
}
