
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int Coins { get; private set; }

    public void AddCoins(int amount)
    {
        Coins += amount;
        Debug.Log("Coins: " + Coins);
    }
}
