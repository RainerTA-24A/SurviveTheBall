
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject winText;
    private bool finished = false;

    private void Start()
    {
        if (winText != null)
        {
            winText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (finished || !other.CompareTag("Player"))
        {
            return;
        }

        finished = true;

        if (winText != null)
        {
            winText.SetActive(true);
        }

        Debug.Log("YOU WIN!");
        Time.timeScale = 0f;
    }
}
