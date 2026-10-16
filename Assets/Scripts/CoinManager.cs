using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int Coins { get; private set; }

    [SerializeField] private TMP_Text coinText;

    private void Start()
    {
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        Debug.Log("AddCoins called! Coins = " + Coins);
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + Coins;
            Debug.Log("Text updated to: " + coinText.text);
        }
        else
        {
            Debug.LogError("Coin Text is NULL!");
        }
    }
}
