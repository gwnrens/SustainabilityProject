using TMPro;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public int cost = 20; // Cost of the item
    public float coinRatePerSecond = 2f; // Coins generated per second
    private int count_items = 0;
    public CO2Manager co2Manager;
    public TextMeshProUGUI count;
    public Healthbar healthbar;

    private void Update()
    {
        if (!healthbar.gameOver)
        {
            // Check for right-click to purchase
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the button was hit by the raycast
                    if (hit.transform == this.transform)
                    {
                        TryPurchaseItem();
                    }
                }
            }
        }
    }

    void TryPurchaseItem()
    {
        bool purchase = CoinManager.Instance.RemoveCoin(cost);
        // Check if the player has enough coins to purchase the item
        if (purchase)
        {
            // Increase coin rate
            CoinManager.Instance.IncreaseCoinRate(coinRatePerSecond);
            // Increase item count
            count_items++;
            // Decrease CO2
            co2Manager.DecreaseCO2(4);
            // Update the count text
            count.text = count_items.ToString();
        }
    }
}
