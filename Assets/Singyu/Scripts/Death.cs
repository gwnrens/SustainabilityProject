using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathUI; 
    public GameObject scoreboardUI; 
    public bool isDead = false; 

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        deathUI.SetActive(true); 
        scoreboardUI.SetActive(false); 
        Time.timeScale = 0; 
       
        
    }
}