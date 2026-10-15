
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        CoinManager manager = FindFirstObjectByType<CoinManager>();

        if (manager != null)
        {
            manager.AddCoins(value);
        }

        Destroy(gameObject);
    }
}
