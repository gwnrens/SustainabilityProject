using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public bool gameOver = false;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
       if (slider.value <= 0)
        {
            Time.timeScale = 0;
            gameOver = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
