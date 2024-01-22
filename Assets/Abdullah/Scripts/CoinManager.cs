using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    private float totalCoins = 3f; 
    public int coins => Mathf.FloorToInt(totalCoins); 
    public TextMeshProUGUI coinText; 
    private float coinRate = 0f; 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        UpdateCoinText();
    }

    private void Update()
    {
        totalCoins += coinRate * Time.deltaTime;
        UpdateCoinText();
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
            coinText.text = "Coins: " + coins;
        }
    }

    public void IncreaseCoinRate(float amount)
    {
        coinRate += amount;
    }
}
