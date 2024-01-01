/// <summary>
/// Explosion.cs
/// Author: MutantGopher
/// This script is for explosion effects. It handles damage for
/// nearby GameObjects with Health components and applies force to nearby rigidbodies.
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour
{
    public bool shooterAISupport = false;       // Enable compatibility with Shooter AI by Gateway Games
    public bool bloodyMessSupport = false;      // Enable compatibility with Bloody Mess by Heavy Diesel Softworks
    public int weaponType = 0;                  // Bloody Mess property

    public float explosionForce = 5.0f;         // The force of the explosion
    public float explosionRadius = 10.0f;       // The radius of the explosion
    public bool causeDamage = true;             // Should the explosion cause damage
    public float damage = 10.0f;                // Damage amount

    IEnumerator Start()
    {
        // Wait one frame for proper force application to debris
        yield return null;

        // Get nearby colliders
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);

        // Apply damage to nearby Health components
        if (causeDamage)
        {
            foreach (Collider col in cols)
            {
                float damageAmount = damage * (1 / Vector3.Distance(transform.position, col.transform.position));
                col.GetComponent<Collider>().gameObject.SendMessageUpwards("ChangeHealth", -damageAmount, SendMessageOptions.DontRequireReceiver);

                if (shooterAISupport)
                {
                    col.transform.SendMessageUpwards("Damage", damageAmount, SendMessageOptions.DontRequireReceiver);
                }

                if (bloodyMessSupport && col.gameObject.layer == LayerMask.NameToLayer("Limb"))
                {
                    // Additional Bloody Mess support code can be added here
                }
            }
        }

        // Apply explosion force to nearby rigidbodies
        List<Rigidbody> rigidbodies = new List<Rigidbody>();
        foreach (Collider col in cols)
        {
            if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
            {
                rigidbodies.Add(col.attachedRigidbody);
            }
        }

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }
    }
}
