using UnityEngine;

public class MinivanMovement : MonoBehaviour
{
    public float speed = 5f; // Initial speed
    public float speedIncrease = 0.1f; // Amount by which speed increases each second

    void Update()
    {
        // Moves the minivan forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Continuously increase the speed
        speed += speedIncrease * Time.deltaTime;
    }
}
