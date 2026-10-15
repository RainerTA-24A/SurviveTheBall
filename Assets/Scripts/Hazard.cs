
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager =
                FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}
