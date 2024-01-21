using UnityEngine;

public class BlockActivateTurret : MonoBehaviour
{
    public TurretController turret; // Assign the turret GameObject in the inspector


    void Update()
    {

        // Check for right-click on this block
        if (Input.GetMouseButtonDown(1)) // 1 is the mouse button index for the right button
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the block was hit by the raycast
                if (hit.transform == this.transform)
                {
                    TryActivateTurret();
                }
            }
        }
    }

    void TryActivateTurret()
    {
        bool activated = CoinManager.Instance.RemoveCoin(1);
        // Check if there's a reference to the CoinManager and the turret
        if (activated)
        {
            turret.ActivateTurret(true);
            turret.IncreaseFireRate(0.3f);
        }
    }
}