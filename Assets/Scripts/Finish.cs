
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool finished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (finished || !other.CompareTag("Player"))
        {
            return;
        }

        finished = true;
        Debug.Log("YOU WIN!");
        Time.timeScale = 0f;
    }
}
