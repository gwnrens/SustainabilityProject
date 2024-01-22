using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Player movement speed
    public float maxXPosition = 6f; // Maximum allowed x position
    public float minXPosition = -6f; // Minimum allowed x position
    private float currentSpeed;

    public SpawnManager spawnManager;

    private bool HitCollider = false;
    public bool isRunning = true;
    private bool isSprinting = false;

    public GameObject originalSkin;
    public GameObject replacementSkin;

    private bool isOriginal = true;

    public int numberOfBoosts;

    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float RunCost, ChargeRate;

    public float CollisionAsCarCounter = 0f;
    public float CollisionAsHumanCounter = 0f;


    void Start()
    {
        originalSkin.SetActive(true);
        replacementSkin.SetActive(false);
        currentSpeed = speed;
        
    }

    void Update()
    {
        if (isRunning)
        {

            float horizontalInput = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown("left shift") && isOriginal)
            {
                currentSpeed = speed * 1.5f;

                isSprinting = true;

            }
            else if (Input.GetKeyUp("left shift") && isOriginal)
            {
                currentSpeed = speed; isSprinting = false;

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (numberOfBoosts>0)
                {
                    numberOfBoosts--;
                    Stamina = MaxStamina;
                }
            }

            if (isSprinting)
            {
                Stamina -= RunCost * Time.deltaTime;
                if (Stamina < 0) { Stamina = 0; }
                StaminaBar.fillAmount = Stamina / MaxStamina;
            }
            if (!isSprinting)
            {
                Stamina += ChargeRate * Time.deltaTime;
                if (Stamina > MaxStamina) Stamina = MaxStamina;
                StaminaBar.fillAmount = Stamina / MaxStamina;
            }
            if (Stamina==0)
            {
                currentSpeed = speed;
            }

            Vector3 newPosition = transform.position + new Vector3(horizontalInput * currentSpeed * Time.deltaTime, 0f, currentSpeed * Time.deltaTime);
            newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);
            transform.position = newPosition;
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndPoint"))
        {
            isRunning = false;
        }
        else if (!HitCollider) 
        { 
            spawnManager.SpawnTriggerEntered();
            if (isOriginal)
            {
                CollisionAsHumanCounter++;
            }
            else
            {
                CollisionAsCarCounter++;
            }
            HitCollider = true;
            if (other.CompareTag("Keuze1"))
            {
                numberOfBoosts++;
            }
            if (other.CompareTag("Keuze2"))
            {
                isSprinting = false;
                if (isOriginal)
                {
                    originalSkin.SetActive(false);
                    replacementSkin.SetActive(true);
                    currentSpeed = speed * 5f;
                }
                else
                {
                    originalSkin.SetActive(true);
                    replacementSkin.SetActive(false);
                    currentSpeed = speed;
                }
                isOriginal = !isOriginal;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        HitCollider = false;
    }
}
