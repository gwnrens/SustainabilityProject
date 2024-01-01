using UnityEngine;
using TMPro; // Namespace for TextMeshPro

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    private float totalCoins = 100f; // Use float for more precise accumulation
    public int coins => Mathf.FloorToInt(totalCoins); // Public getter to return the integer part
    public TextMeshProUGUI coinText; // Reference to the TextMeshProUGUI that displays the coin count
    private float coinRate = 0f; // Coin generation rate per second

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinText();
    }

    private void Update()
    {
        // Generate coins based on the coin rate
        totalCoins += coinRate * Time.deltaTime;
        UpdateCoinText(); // You may want to limit how often this updates for performance reasons
    }

    public void AddCoin(int n = 1)
    {
        totalCoins += n;
        UpdateCoinText();
    }

    public bool RemoveCoin(int n)
    {
        if (totalCoins >= n)
        {
            totalCoins -= n;
            UpdateCoinText();
            return true;
        }
        else
        {
            return false;
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins; // Using the coins getter to display the integer part
        }
        else
        {
            Debug.LogWarning("Coin TextMeshProUGUI component not set.");
        }
    }

    public void IncreaseCoinRate(float amount)
    {
        coinRate += amount;
    }
}
