using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject deathUI; 
    public GameObject scoreboardUI; 
    public bool isDead = false;
    public GameManagerElec gameManager;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        deathUI.SetActive(true); 
        scoreboardUI.SetActive(false); 
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


    }


}