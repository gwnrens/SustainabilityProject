using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public Healthbar healthbar; // Assign your Healthbar script in the Inspector
    public CO2Manager CO2Manager; // Assign your CO2Manager script in the Inspector

    private void OnTriggerEnter(Collider other)
    {

        // Check if the object entering the trigger is a car
        if (other.CompareTag("enemy")) // Ensure your car GameObject has the tag "Car" in the Inspector
        {

            // Increase CO2
            CO2Manager.IncreaseCO2(2);

            // Reduce health
            int newHealth = Mathf.Max((int)healthbar.slider.value - 1, 0); // Prevents health from going below 0
            healthbar.SetHealth(newHealth);

            // Optionally deactivate the car GameObject
            other.gameObject.SetActive(false);
        }
    }
}
